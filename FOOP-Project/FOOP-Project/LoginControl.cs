using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOP_Project
{
    internal class LoginControl
    {
        private readonly GiftAppDBEntities2 _db = new GiftAppDBEntities2();
        public void RegisterUser(string username, string password)
        {
            if (!CheckUser(username, password))
            {
                Console.WriteLine(@"User registered");
                _db.AddUser(username,password);
            }
            else
            {
                Console.WriteLine(@"User already exists");
            }
        }

        public void LogIn(string username, string password, MainWindow main)
        {
            if (CheckUser(username, password))
            {
                var dBoard = new Dashboard(GetUserId(username,password)){Owner = main};
                dBoard.Show();
            }
        }

        private bool CheckUser(string username, string password) => _db.UserTbls.Select(u => u.UserName.ToLower()).SingleOrDefault(u => u.Equals(username.ToLower())) != null && _db.UserTbls.Select(u => u.UserPassword).SingleOrDefault(u => u.Equals(password)) != null;

        private int GetUserId(string username, string password) => _db.UserTbls.Select(u => new { u.UserId, u.UserName, u.UserPassword }).First(u => u.UserName.Equals(username) && u.UserPassword.Equals(password)).UserId;
    }
}
