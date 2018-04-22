using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly LoginControl _appInstance = new LoginControl();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            _appInstance.LogIn(UsernameBox.Text, PasswordBox.Text, this);
            Hide();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e) => _appInstance.RegisterUser(UsernameBox.Text, PasswordBox.Text);
    }
}
