using System;
using System.Linq;

namespace FOOP_Project
{
    internal class LoginControl
    {
        private readonly GiftAppDBEntities _db = new GiftAppDBEntities();
        public void RegisterUser(string username, string password)
        {
            if (CheckUser(username, password))
                Console.WriteLine(@"User already exists");
            else
                try
                {
                    _db.AddUser(username, password);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
        }

        public void LogIn(string username, string password, MainWindow main)
        {
            if (!CheckUser(username, password)) return;
            var dBoard = new Dashboard(GetUserId(username,password)){Owner = main};
            dBoard.Show();
        }

        private bool CheckUser(string username, string password) => _db.UserTbls.Select(u => u.UserName.ToLower()).SingleOrDefault(u => u.Equals(username.ToLower())) != null && _db.UserTbls.Select(u => u.UserPassword).SingleOrDefault(u => u.Equals(password)) != null;

        private int GetUserId(string username, string password) => _db.UserTbls.Select(u => new { u.UserId, u.UserName, u.UserPassword }).First(u => u.UserName.Equals(username) && u.UserPassword.Equals(password)).UserId;
    }
}
