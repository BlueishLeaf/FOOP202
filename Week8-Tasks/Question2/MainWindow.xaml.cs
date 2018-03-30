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

namespace Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Program _appInstance = new Program();
        public MainWindow()
        {
            InitializeComponent();
            CustomerBox.ItemsSource = _appInstance.GetCustomers();
        }

        private void CustomerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderBox.ItemsSource = _appInstance.GetOrders(CustomerBox.SelectedItem.ToString());
        }

        private void OrderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
