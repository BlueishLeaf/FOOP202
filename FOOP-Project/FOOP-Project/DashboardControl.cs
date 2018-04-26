using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace FOOP_Project
{
    public class DashboardControl
    {
        private readonly int _userId;
        private readonly GiftAppDBEntities _db = new GiftAppDBEntities();
        public DashboardControl(int userId) => _userId = userId;

        #region GettingData

        public ObservableCollection<Person> GetPeople()
        {
            var personCollection = new ObservableCollection<Person>();
            foreach (var p in _db.PersonTbls.Select(p => new { p.PersonName, p.UserId, p.PersonDOB, p.PersonGender, p.PersonId }).Where(p => p.UserId.Equals(_userId)))
                personCollection.Add(new Person
                {
                    Name = p.PersonName,
                    Id = p.PersonId,
                    Age = (DateTime.Now - p.PersonDOB).Days/365,
                    Gender = p.PersonGender
                });
            return personCollection;
        }

        public ObservableCollection<Event> GetEvents(int personId)
        {
            var eventCollection = new ObservableCollection<Event>();
            foreach (var e in _db.EventTbls.Select(e => new { e.EventName, e.PersonId, e.EventDate, e.EventId }).Where(e => e.PersonId.Equals(personId)))
                eventCollection.Add(new Event { Name = e.EventName, Date = e.EventDate, DateString = e.EventDate.ToShortDateString(), Id = e.EventId });
            return eventCollection;
        }

        public ObservableCollection<Gift> GetGifts(int eventId)
        {
            var giftCollection = new ObservableCollection<Gift>();
            foreach (var g in _db.GiftTbls.Select(g => new { g.GiftId, g.GiftName, g.GiftPrice, g.EventId }).Where(g => g.EventId.Equals(eventId)))
                giftCollection.Add(new Gift { Name = g.GiftName, Price = g.GiftPrice, PriceString = string.Format(CultureInfo.GetCultureInfo("en-IE"),"{0:C}",g.GiftPrice),Id = g.GiftId });
            return giftCollection;
        }

        #endregion

        #region SortingData

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

        public ObservableCollection<Event> SortEvents(int index, ObservableCollection<Event> list)
        {
            var filteredList = new ObservableCollection<Event>();
            switch (index)
            {
                case 0:
                    return list;
                case 1:
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

        #region AddingObjects

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

        public void SavePerson(string name, DateTime dob, string gender) => _db.AddPerson(_userId, name, dob, gender);

        public void SaveEvent(string eventName, DateTime eventDate, int id) => _db.AddEvent(eventName, eventDate, id);

        public void SaveGift(string giftName, string giftPrice, int id) => _db.AddGift(giftName, Convert.ToDecimal(giftPrice), id);

        #endregion

        #region DeleteObjects

        public void DeletePerson(Person selectedPerson) => _db.DeletePerson(selectedPerson.Id);

        public void DeleteEvent(Event selectedEvent) => _db.DeleteEvent(selectedEvent.Id);

        public void DeleteGift(Gift selectedGift) => _db.DeleteGift(selectedGift.Id);

        #endregion

    }
}
