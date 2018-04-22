using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FOOP_Project
{
    internal class DashboardControl
    {
        private readonly int _userId;
        private readonly GiftAppDBEntities _db = new GiftAppDBEntities();
        public readonly string[] SortByStrings = {"Name A-Z","Name Z-A","Age Asc","Age Desc", "Gender M-F", "Gender F-M"};
        public readonly string[] UpcomingEventsStrings = { "All","1 Week", "2 Weeks", "1 Month", "2 Months", "1 Year", "2 Years" };
        public readonly string[] SortByGiftStrings = { "Name A-Z", "Name Z-A", "Price Asc", "Price Desc"};

        public DashboardControl(int userId)
        {
            _userId = userId;

        }

        public ObservableCollection<Person> GetPeople()
        {
            var myPeople = new ObservableCollection<Person>();
            foreach (var p in _db.PersonTbls.Select(p => new { p.PersonName, p.UserId, p.PersonDOB, p.PersonGender, p.PersonId }).Where(p => p.UserId.Equals(_userId)))
            {
                myPeople.Add(new Person() { Name = p.PersonName,Id = p.PersonId, Age = (DateTime.Now - p.PersonDOB).Days, Gender = p.PersonGender ? "male" : "female" });
            }

            return myPeople;
        }

        public ObservableCollection<Event> GetEvents(int personId)
        {
            var myEvents = new ObservableCollection<Event>();
            foreach (var e in _db.EventTbls.Select(e => new { e.EventName, e.PersonId, e.EventDate, e.EventId }).Where(e => e.PersonId.Equals(personId)))
            {
                myEvents.Add(new Event() { Name = e.EventName, Date = e.EventDate, Id = e.EventId});
            }

            return myEvents;
        }

        public ObservableCollection<Gift> GetGifts(int eventId)
        {
            var myGifts = new ObservableCollection<Gift>();
            foreach (var g in _db.GiftTbls.Select(g => new { g.GiftId, g.GiftName, g.GiftPrice }).Where(g => g.GiftId.Equals(eventId)))
            {
                myGifts.Add(new Gift() { Name = g.GiftName, Price = g.GiftPrice, Id = g.GiftId });
            }

            return myGifts;
        }

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
                    return list.OrderBy(p=>p);
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
                    {
                        if ((e.Date - DateTime.Now).Days <= 7)
                        {
                            filteredList.Add(e);
                        }
                    }
                    return filteredList;
                case 2:
                    foreach (var e in list)
                    {
                        if ((e.Date - DateTime.Now).Days <= 14)
                        {
                            filteredList.Add(e);
                        }
                    }
                    return filteredList;
                case 3:
                    foreach (var e in list)
                    {
                        if ((e.Date - DateTime.Now).Days <= 30)
                        {
                            filteredList.Add(e);
                        }
                    }
                    return filteredList;
                case 4:
                    foreach (var e in list)
                    {
                        if ((e.Date - DateTime.Now).Days <= 60)
                        {
                            filteredList.Add(e);
                        }
                    }
                    return filteredList;
                case 5:
                    foreach (var e in list)
                    {
                        if ((e.Date - DateTime.Now).Days <= 365)
                        {
                            filteredList.Add(e);
                        }
                    }
                    return filteredList;
                case 6:
                    foreach (var e in list)
                    {
                        if ((e.Date - DateTime.Now).Days <= 760)
                        {
                            filteredList.Add(e);
                        }
                    }
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

        public void EditPerson()
        {
            throw new NotImplementedException();
        }

        public void AddPerson()
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(Person selectedPerson)
        {
            throw new NotImplementedException();
        }
    }
}
