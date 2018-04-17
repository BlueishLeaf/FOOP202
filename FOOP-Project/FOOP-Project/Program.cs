using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_Project
{
    internal class Program
    {
        private GiftAppDBEntities _db = new GiftAppDBEntities();
        public void RegisterUser(string username, string password)
        {
            if (!CheckUser(username, password))
            {
                _db.UserTbls.Add(new UserTbl{UserName = username, UserPassword = password});
                _db.SaveChanges();
                Console.WriteLine(@"User registered");
            }
            else
            {
                Console.WriteLine(@"User already exists");
            }
        }

        public void LogIn(string username, string password)
        {
            if (CheckUser(username, password))
            {
                Console.WriteLine(@"User Exists");
            }
        }

        private bool CheckUser(string username, string password) => _db.UserTbls.Select(u => u.UserName.ToLower()).SingleOrDefault(u => u.Equals(username.ToLower())) != null && _db.UserTbls.Select(u => u.UserPassword).SingleOrDefault(u => u.Equals(password)) != null;
    }
}
