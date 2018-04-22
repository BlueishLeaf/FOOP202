using System;
using System.Collections;
using System.Collections.Generic;
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

        public DashboardControl(int userId)
        {
            _userId = userId;
            
        }

        public IEnumerable GetPeople()
        {
            return _db.PersonTbls.Select(p => new {p.PersonName, p.UserId}).Where(p => p.UserId.Equals(_userId)).ToList();
        }
    }
}
