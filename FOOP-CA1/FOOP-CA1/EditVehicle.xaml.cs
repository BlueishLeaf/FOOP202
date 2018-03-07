using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xceed.Wpf.Toolkit;
using Uri = System.Uri;

namespace FOOP_CA1
{
    /// <inheritdoc cref="Program" />
    /// <summary>
    /// Interaction logic for EditVehicle.xaml
    /// </summary>
    public partial class EditVehicle
    {
        #region Properties
        public Vehicle NewVehicle { get; set; }
        // For the preview
        private string _imagePath;
        #endregion

        #region OnLoadLogic
        // Constructor sets the item sources of the combo box and sets the values of the relevant fields if it detects that
        // there was a valid selectedVehicle passed in. 
        public EditVehicle(Vehicle selectedVehicle = null)
        {
            InitializeComponent();
            BodyTypeCombo.ItemsSource = Enum.GetValues(typeof(BodyType));
            BikeTypeCombo.ItemsSource = Enum.GetValues(typeof(BikeType));
            VanTypeCombo.ItemsSource = Enum.GetValues(typeof(VanType));
            WheelbaseCombo.ItemsSource = Enum.GetValues(typeof(Wheelbase));
            ColourPicker.ColorMode = ColorMode.ColorCanvas;
            if (selectedVehicle == null) return;
            // Disabling ability to change the type if editing a vehicle
            CarTypeRadio.IsEnabled = false;
            VanTypeRadio.IsEnabled = false;
            BikeTypeRadio.IsEnabled = false;
            // Figure out the type of vehicle selectedVehicle is and retrieve its type-specific property
            if (selectedVehicle.GetType() == typeof(Car))
            {
                CarTypeRadio.IsChecked = true;
                if (selectedVehicle is Car tempCar) BodyTypeCombo.SelectedItem = tempCar.BodyType;
            }
            else if (selectedVehicle.GetType() == typeof(Motorcycle))
            {
                BikeTypeRadio.IsChecked = true;
                if (selectedVehicle is Motorcycle tempBike) BikeTypeCombo.SelectedItem = tempBike.Type;
            }
            else if (selectedVehicle.GetType() == typeof(Van))
            {
                VanTypeRadio.IsChecked = true;
                if (selectedVehicle is Van tempVan)
                {
                    VanTypeCombo.SelectedItem = tempVan.Type;
                    WheelbaseCombo.SelectedItem = tempVan.Wheelbase;
                }
            }
            MakeBox.Text = selectedVehicle.Make;
            ModelBox.Text = selectedVehicle.Model;
            PriceBox.Text = selectedVehicle.Price.ToString(CultureInfo.InvariantCulture);
            YearBox.Text = selectedVehicle.Year.ToString();
            ColourPicker.SelectedColor = (Color?)ColorConverter.ConvertFromString(selectedVehicle.Colour);
            MileageBox.Text = selectedVehicle.Mileage.ToString();
            DescriptionBox.Text = selectedVehicle.Description;
            _imagePath = selectedVehicle.ImagePath;
            PreviewImg.Source = new BitmapImage(new Uri(_imagePath, UriKind.Relative));
            NewVehicle = selectedVehicle;
        }
        #endregion

        #region ButtonEvents
        // The preview image below and the color selection are my Additional Features
        // Sets the imagePath field as well as displays a preview of what it will look like
        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check to make sure Owner is of type MainWindow and is not null
            if (!(Owner is MainWindow main)) return;
            _imagePath = main.AppInstance.SelectImage();
            PreviewImg.Source = new BitmapImage(new Uri(_imagePath, UriKind.Relative));
        }

        // Instantiates the correct type of vehicle based on what radio button is checked. If the user is editing a vehicle
        // then NewVehicle overrites the old one in the collection
        private void SaveDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            // Assigning the extra options(bodytype,vantype,etc) of the vehicle depending on what type it is
            if (CarTypeRadio.IsChecked == true)
                NewVehicle = new Car
                {
                    BodyType = (BodyType)Enum.Parse(typeof(BodyType), BodyTypeCombo.SelectedItem.ToString())
                };
            else if (BikeTypeRadio.IsChecked == true)
                NewVehicle = new Motorcycle
                {
                    Type = (BikeType)Enum.Parse(typeof(BikeType), BikeTypeCombo.SelectedItem.ToString())
                };
            else if (VanTypeRadio.IsChecked == true)
                NewVehicle = new Van
                {
                    Type = (VanType)Enum.Parse(typeof(VanType), VanTypeCombo.SelectedItem.ToString()),
                    Wheelbase = (Wheelbase)Enum.Parse(typeof(Wheelbase), WheelbaseCombo.SelectedItem.ToString())
                };

            NewVehicle.Make = MakeBox.Text;
            NewVehicle.Make = MakeBox.Text;
            NewVehicle.Model = ModelBox.Text;
            NewVehicle.Price = Convert.ToDecimal(PriceBox.Text);
            NewVehicle.Year = Convert.ToInt32(YearBox.Text);
            NewVehicle.Colour = ColourPicker.SelectedColorText;
            NewVehicle.Mileage = Convert.ToInt32(MileageBox.Text);
            NewVehicle.Description = DescriptionBox.Text;
            // Check to make sure imagePath is not null before assigning it
            if (_imagePath != null)
                NewVehicle.ImagePath = _imagePath;
            // Check to make sure Owner is of type MainWindow and is not null
            if (!(Owner is MainWindow main)) return;
            main.AppInstance.SaveDetails(NewVehicle);
            Close();
        }

        // Closes EditWindow without saving any changes
        private void CancelBtn_Click(object sender, RoutedEventArgs e) => Close();
        #endregion



    }
}
