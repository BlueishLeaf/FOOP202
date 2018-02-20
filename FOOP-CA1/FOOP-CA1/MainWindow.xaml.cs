using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        public MainWindow()
        {
            InitializeComponent();
            SortCombo.ItemsSource = appInstance.ComboStrings;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            appInstance.CreateVehicles();
            CarList.ItemsSource = appInstance.VehicleCollection;
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            appInstance.ReadJson();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            appInstance.WriteJson();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CarList.SelectedItem == null) return;
            var selectedVehicle = (Vehicle)CarList.SelectedItem;
            appInstance.VehicleCollection = appInstance.DeleteItem(selectedVehicle);
        }

        private void CarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarList.SelectedItem == null) return;
            var selectedVehicle = (Vehicle)CarList.SelectedItem;
            VehicleImg.Source = selectedVehicle.GenericImage;
            MakeBlock.Text = selectedVehicle.Make;
            ModelBlock.Text = selectedVehicle.Model;
            PriceBlock.Text = selectedVehicle.Price.ToString(CultureInfo.CurrentCulture);
            YearBlock.Text = selectedVehicle.Year.ToString();
            MileageBlock.Text = selectedVehicle.Mileage.ToString();
            DescBlock.Text = selectedVehicle.Description;
        }

        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            appInstance.SortBy(SortCombo.SelectedItem.ToString());
        }
    }
}
