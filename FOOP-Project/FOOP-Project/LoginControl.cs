using System;
using System.Linq;

namespace FOOP_Project
{
    internal class LoginControl
    {
        //Instantiate an instance of the database
        private readonly GiftAppDBEntities _db = new GiftAppDBEntities();
        
        //Check if the user already exists, then call a proc to add the user to the database
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

        //Check to see if the credentials are correct then instantiate the user's dashboard
        public void LogIn(string username, string password, MainWindow main)
        {
            //Single line check to exit the function if the user doesnt exist
            if (!CheckUser(username, password)) return;
            var dBoard = new Dashboard(GetUserId(username,password)){Owner = main};
            dBoard.ShowDialog();
        }

        //Linq expression to check the users credentials agains the database. Returns true if the user exists, and false if they don't
        private bool CheckUser(string username, string password) => _db.UserTbls.Select(u => u.UserName.ToLower()).SingleOrDefault(u => u.Equals(username.ToLower())) != null && _db.UserTbls.Select(u => u.UserPassword).SingleOrDefault(u => u.Equals(password)) != null;

        //Linq expression to get the id of the user so as to pass into the dashboard
        private int GetUserId(string username, string password) => _db.UserTbls.Select(u => new { u.UserId, u.UserName, u.UserPassword }).First(u => u.UserName.Equals(username) && u.UserPassword.Equals(password)).UserId;
    }
}
