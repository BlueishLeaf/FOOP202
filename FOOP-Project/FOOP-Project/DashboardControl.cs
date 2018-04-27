using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FOOP_Project
{
    //Control class for the user dashboard. Controls everything that isnt the login screen
    public class DashboardControl
    {
        private readonly int _userId;
        //Instantiate new instance of the database
        private readonly GiftAppDBEntities _db = new GiftAppDBEntities();

        //Constructor assigns the user id (for DB purposes)
        public DashboardControl(int userId) => _userId = userId;

        //The following region involves retrieving data from the database
        #region GettingData

        //Linq expression to retrieve and return a collection of people associated with the user id of the user
        public ObservableCollection<Person> GetPeople()
        {
            var personCollection = new ObservableCollection<Person>();
            foreach (var p in _db.PersonTbls.Select(p => new { p.PersonName, p.UserId, p.PersonDOB, p.PersonGender, p.PersonId }).Where(p => p.UserId.Equals(_userId)))
                personCollection.Add(new Person
                {
                    Name = p.PersonName,
                    Id = p.PersonId,
                    Age = (DateTime.Now - p.PersonDOB).Days / 365,
                    Gender = p.PersonGender
                });
            return personCollection;
        }

        //Linq expression to retrive and return a collection of events associated with a particular person
        public ObservableCollection<Event> GetEvents(int personId)
        {
            var eventCollection = new ObservableCollection<Event>();
            foreach (var e in _db.EventTbls.Select(e => new { e.EventName, e.PersonId, e.EventDate, e.EventId }).Where(e => e.PersonId.Equals(personId)))
                eventCollection.Add(new Event { Name = e.EventName, Date = e.EventDate, DateString = e.EventDate.ToShortDateString(), Id = e.EventId });
            return eventCollection;
        }

        //Linq expression to retrieve and return a collection of gifts associate with a particular event
        public ObservableCollection<Gift> GetGifts(int eventId)
        {
            var giftCollection = new ObservableCollection<Gift>();
            foreach (var g in _db.GiftTbls.Select(g => new { g.GiftId, g.GiftName, g.GiftPrice, g.EventId }).Where(g => g.EventId.Equals(eventId)))
                giftCollection.Add(new Gift { Name = g.GiftName, Price = g.GiftPrice, PriceString = string.Format(CultureInfo.GetCultureInfo("en-IE"), "{0:C}", g.GiftPrice), Id = g.GiftId });
            return giftCollection;
        }

        #endregion

        //The following region deals with sorting and filtering the collections of data in the listboxes
        #region SortingData

        //Take in index of the combo box and use linq to sort the data based on the option selected
        public IOrderedEnumerable<Person> SortPeople(int index, IEnumerable<Person> list)
        {
            switch (index)
            {
                case 0:
                    return list.OrderBy(p => p.Name);
                case 1:
                    return list.OrderByDescending(p => p.Name);
                case 2:
                    return list.OrderBy(p => p.Age);
                case 3:
                    return list.OrderByDescending(p => p.Age);
                case 4:
                    return list.OrderBy(p => p.Gender);
                case 5:
                    return list.OrderByDescending(p => p.Gender);
                default:
                    return list.OrderBy(p => p);
            }
        }

        //Take in index of combo box and filter the data based on the option selected
        public ObservableCollection<Event> SortEvents(int index, ObservableCollection<Event> list)
        {
            var filteredList = new ObservableCollection<Event>();
            switch (index)
            {
                case 0:
                    return list;
                case 1:
                    //Checks the date of each event and compares it to the option selected
                    foreach (var e in list)
                        if ((e.Date - DateTime.Now).Days <= 7)
                            filteredList.Add(e);
                    return filteredList;
                case 2:
                    foreach (var e in list)
                        if ((e.Date - DateTime.Now).Days <= 14)
                            filteredList.Add(e);
                    return filteredList;
                case 3:
                    foreach (var e in list)
                        if ((e.Date - DateTime.Now).Days <= 30)
                            filteredList.Add(e);
                    return filteredList;
                case 4:
                    foreach (var e in list)
                        if ((e.Date - DateTime.Now).Days <= 60)
                            filteredList.Add(e);
                    return filteredList;
                case 5:
                    foreach (var e in list)
                        if ((e.Date - DateTime.Now).Days <= 365)
                            filteredList.Add(e);
                    return filteredList;
                case 6:
                    foreach (var e in list)
                        if ((e.Date - DateTime.Now).Days <= 760)
                            filteredList.Add(e);
                    return filteredList;
                default:
                    return list;
            }
        }

        //Takes in index of combo box, uses linq to sort data similarly to the SortPeople function
        public IOrderedEnumerable<Gift> SortGifts(int index, IEnumerable<Gift> list)
        {
            switch (index)
            {
                case 0:
                    return list.OrderBy(g => g.Name);
                case 1:
                    return list.OrderByDescending(g => g.Name);
                case 2:
                    return list.OrderBy(g => g.Price);
                case 3:
                    return list.OrderByDescending(g => g.Price);
                default:
                    return list.OrderBy(p => p);
            }
        }

        #endregion

        //The following region involves opening the "add x" windows and calling sprocs in the database to add objects to tables
        #region AddingObjects

        //Instantiates new window to add a new person,event or gift
        public void AddPerson(Dashboard dash)
        {
            var addPersonWin = new AddPerson { Owner = dash };
            addPersonWin.ShowDialog();
        }

        public void AddEvent(Dashboard dash, int id)
        {
            var addEventWin = new AddEvent(id) { Owner = dash };
            addEventWin.ShowDialog();
        }

        public void AddGift(Dashboard dash, int id)
        {
            var addGiftWin = new AddGift(id) { Owner = dash };
            addGiftWin.ShowDialog();
        }

        //Called from within the add windows, calls a sproc in the DB to add the corresponding object to the table
        public void SavePerson(string name, DateTime dob, string gender) => _db.AddPerson(_userId, name, dob, gender);

        public void SaveEvent(string eventName, DateTime eventDate, int id) => _db.AddEvent(eventName, eventDate, id);

        public void SaveGift(string giftName, string giftPrice, int id) => _db.AddGift(giftName, Convert.ToDecimal(giftPrice), id);

        #endregion

        //The following region involves calling sprocs to remove an item from the DB
        #region DeleteObjects

        //Calls sproc in DB to delete the person,event, or gift
        public void DeletePerson(Person selectedPerson) => _db.DeletePerson(selectedPerson.Id);

        public void DeleteEvent(Event selectedEvent) => _db.DeleteEvent(selectedEvent.Id);

        public void DeleteGift(Gift selectedGift) => _db.DeleteGift(selectedGift.Id);

        #endregion

        //The following region involves the JSON (gifts.json) used to generate random gift suggestions
        #region JSON

        //Returns a random string array (name and price) to populate the text boxes in the add gift window
        public string[] RandomizeGift()
        {
            var giftList = DeserializeJson(File.ReadAllText("gifts.json"));
            var rndm = new Random();
            var rndmIndex = rndm.Next(giftList.Count);
            string[] rndmValues = { giftList[rndmIndex].Name, giftList[rndmIndex].PriceString };
            return rndmValues;
        }

        //Deserialise the json passed into it and return a list of the object
        public static List<Gift> DeserializeJson(string json) => JsonConvert.DeserializeObject<List<Gift>>(json);

        #endregion

    }
}
