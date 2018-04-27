using System.Windows;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        //Instantiate control class for the login screen
        private readonly LoginControl _logCon = new LoginControl();
        public MainWindow() => InitializeComponent();

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //Pass login details to the login function
            _logCon.LogIn(TbxUsername.Text, PbxPassword.Password, this);
            Close();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            //Try to register user and then log them in
            _logCon.RegisterUser(TbxUsername.Text, PbxPassword.Password);
            MessageBox.Show("User Registered! Logging you in...");
            _logCon.LogIn(TbxUsername.Text, PbxPassword.Password, this);
            Close();
        }
    }
}
