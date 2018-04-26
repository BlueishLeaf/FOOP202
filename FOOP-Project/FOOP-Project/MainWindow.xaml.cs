using System.Windows;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly LoginControl _logCon = new LoginControl();
        public MainWindow() => InitializeComponent();

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            _logCon.LogIn(TbxUsername.Text, PbxPassword.Password, this);
            Hide();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            _logCon.RegisterUser(TbxUsername.Text, PbxPassword.Password);
            MessageBox.Show("User Registered! Logging you in...");
            _logCon.LogIn(TbxUsername.Text, PbxPassword.Password, this);
            Hide();
        }
    }
}
