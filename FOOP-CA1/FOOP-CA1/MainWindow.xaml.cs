using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace FOOP_CA1
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _appInstance.CreateVehicles();
            SortCombo.ItemsSource = _appInstance.ComboStrings;
            CarList.ItemsSource = _appInstance.VehicleCollection;
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            _appInstance.ReadJson();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            _appInstance.WriteJson();
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
            _appInstance.VehicleCollection = _appInstance.DeleteItem(selectedVehicle);
        }

        private void CarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarList.SelectedItem == null) return;
            var selectedVehicle = (Vehicle)CarList.SelectedItem;
            VehicleImg.Source = _appInstance.GetImage(selectedVehicle);
            MakeBlock.Text = selectedVehicle.Make;
            ModelBlock.Text = selectedVehicle.Model;
            PriceBlock.Text = selectedVehicle.Price.ToString(CultureInfo.CurrentCulture);
            YearBlock.Text = selectedVehicle.Year.ToString();
            MileageBlock.Text = selectedVehicle.Mileage.ToString();
            DescBlock.Text = selectedVehicle.ToString();
        }

        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarList.ItemsSource = _appInstance.SortBy(SortCombo.SelectedItem.ToString());
        }

        private void AllRadio_Checked(object sender, RoutedEventArgs e)
        {
           CarList.ItemsSource = _appInstance.FilterBy("All");
        }

        private void CarsRadio_Checked(object sender, RoutedEventArgs e)
        {
            CarList.ItemsSource = _appInstance.FilterBy("Cars");
        }

        private void BikesRadio_Checked(object sender, RoutedEventArgs e)
        {
            CarList.ItemsSource = _appInstance.FilterBy("Bikes");
        }

        private void VansRadio_Checked(object sender, RoutedEventArgs e)
        {
            CarList.ItemsSource = _appInstance.FilterBy("Vans");
        }
    }
}
