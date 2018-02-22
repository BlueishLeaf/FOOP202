using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace FOOP_CA1
{
    /// <inheritdoc cref="Program" />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Properties
        // The control class "Program" is instantiated
        public  Program AppInstance = new Program();
        #endregion

        #region OnLoadLogic
        // The combo box options are added to the combo box and the
        // initial few vehicle objects are displayed in the list box
        public MainWindow()
        {
            InitializeComponent();
            SortCombo.ItemsSource = AppInstance.ComboStrings;
            CarList.ItemsSource = AppInstance.VehicleCollection;
        }
        #endregion

        #region ButtonEvents
        // Click events for each button. Each event has a lamda expression
        // calling the relevant method in the control class
        private void LoadBtn_Click(object sender, RoutedEventArgs e) => AppInstance.ParseJsonItems();
        private void SaveBtn_Click(object sender, RoutedEventArgs e) => AppInstance.SaveToJson();
        private void AddBtn_Click(object sender, RoutedEventArgs e) => AppInstance.AddVehicle(this);
        private void EditBtn_Click(object sender, RoutedEventArgs e) => AppInstance.EditVehicle(this, CarList.SelectedItem as Vehicle);
        private void DeleteBtn_Click(object sender, RoutedEventArgs e) => AppInstance.DeleteItem((Vehicle)CarList.SelectedItem);
        #endregion

        #region SortEvents
        // Check events for the filter radio buttons and the "sort by" combo box.
        // Each followed by a lambda expression in which the sort option is passed to a method in the control
        private void SortCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) => CarList.ItemsSource = AppInstance.SortBy(SortCombo.SelectedItem.ToString());
        private void AllRadio_Checked(object sender, RoutedEventArgs e) => CarList.ItemsSource = AppInstance.FilterBy("All");
        private void CarsRadio_Checked(object sender, RoutedEventArgs e) => CarList.ItemsSource = AppInstance.FilterBy("Cars");
        private void BikesRadio_Checked(object sender, RoutedEventArgs e) => CarList.ItemsSource = AppInstance.FilterBy("Bikes");
        private void VansRadio_Checked(object sender, RoutedEventArgs e) => CarList.ItemsSource = AppInstance.FilterBy("Vans");
        #endregion

        #region ListBoxEvents
        // When an item is selected in the vehicle list box, it's information
        // is displayed in the rightmost section
        private void CarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CarList.SelectedItem == null) return;
            var selectedVehicle = (Vehicle)CarList.SelectedItem;
            VehicleImg.Source = selectedVehicle.GetImage();
            MakeBlock.Text = selectedVehicle.Make;
            ModelBlock.Text = selectedVehicle.Model;
            PriceBlock.Text = selectedVehicle.Price.ToString("C", CultureInfo.GetCultureInfo("en-IE"));
            YearBlock.Text = selectedVehicle.Year.ToString();
            MileageBlock.Text = selectedVehicle.Mileage.ToString();
            DescBlock.Text = selectedVehicle.ToString();
        }
        #endregion
    }
}
