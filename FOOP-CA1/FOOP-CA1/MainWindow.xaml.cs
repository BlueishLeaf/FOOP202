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

namespace FOOP_CA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Program appInstance = new Program();
        List<Vehicle> vehicleList = new List<Vehicle>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vehicleList = appInstance.CreateVehicles();
            CarList.ItemsSource = vehicleList;
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            CarList.ItemsSource = null;
            if (CarList.SelectedItem != null)
            {
                Vehicle selectedVehicle = (Vehicle)CarList.SelectedItem;
                vehicleList = appInstance.DeleteItem(vehicleList,selectedVehicle);
            }
            CarList.ItemsSource = vehicleList;
        }

        private void CarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarList.SelectedItem != null)
            {
                Vehicle selectedVehicle = (Vehicle)CarList.SelectedItem;

            }
        }
    }
}
