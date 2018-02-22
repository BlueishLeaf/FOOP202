using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace FOOP_CA1
{
    /// <summary>
    /// Interaction logic for EditVehicle.xaml
    /// </summary>
    public partial class EditVehicle : Window
    {
        public Vehicle NewVehicle { get; set; }
        public EditVehicle(Vehicle selectedVehicle)
        {
            InitializeComponent();
            if (selectedVehicle.GetType() == typeof(Car))
            {
                CarTypeRadio.IsChecked = true;
                if (selectedVehicle is Car tempCar) BodyTypeBox.Text = tempCar.BodyType.ToString();
            }
            else if (selectedVehicle.GetType() == typeof(Motorcycle))
            {
                BikeTypeRadio.IsChecked = true;
                if (selectedVehicle is Motorcycle tempBike) BikeTypeBox.Text = tempBike.Type.ToString();
            }
            else if (selectedVehicle.GetType() == typeof(Van))
            {
                VanTypeRadio.IsChecked = true;
                if (selectedVehicle is Van tempVan)
                {
                    VanTypeBox.Text = tempVan.Type.ToString();
                    WheelbaseBox.Text = tempVan.Wheelbase.ToString();
                }
            }
            MakeBox.Text = selectedVehicle.Make;
            ModelBox.Text = selectedVehicle.Model;
            PriceBox.Text = selectedVehicle.Price.ToString(CultureInfo.InvariantCulture);
            YearBox.Text = selectedVehicle.Year.ToString();
            ColourBox.Text = selectedVehicle.Colour;
            MileageBox.Text = selectedVehicle.Mileage.ToString();
            DescriptionBox.Text = selectedVehicle.Description;
            NewVehicle = selectedVehicle;
        }

        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Owner as MainWindow;

            if (main != null)
            {
                var path = main.AppInstance.SelectImage();
                NewVehicle.ImagePath = path;
                PreviewImg.Source = new BitmapImage(new Uri(NewVehicle.ImagePath, UriKind.Relative));
            }


        }

        private void SaveDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            NewVehicle = new Vehicle
            {
                Make = MakeBox.Text,
                Model = ModelBox.Text,
                Price = Convert.ToDecimal(PriceBox.Text),
                Year = Convert.ToInt32(YearBox.Text),
                Colour = ColourBox.Text,
                Mileage = Convert.ToInt32(MileageBox.Text),
                Description = DescriptionBox.Text
            };
            if (NewVehicle.GetType() == typeof(Car))
            {
                if (NewVehicle is Car tempCar) tempCar.BodyType = (BodyType) Enum.Parse(typeof(BodyType), BodyTypeBox.Text);
            }
            else if (NewVehicle.GetType() == typeof(Motorcycle))
            {
                if (NewVehicle is Motorcycle tempBike) tempBike.Type = (BikeType) Enum.Parse(typeof(BikeType), BikeTypeBox.Text);
            }
            else if (NewVehicle.GetType() == typeof(Van))
            {
                if (NewVehicle is Van tempVan)
                {
                    tempVan.Type = (VanType) Enum.Parse(typeof(VanType), VanTypeBox.Text);
                    tempVan.Wheelbase = (Wheelbase) Enum.Parse(typeof(Wheelbase), WheelbaseBox.Text);
                }
            }
            ((MainWindow)Application.Current.MainWindow)?.AppInstance.SaveDetails(NewVehicle);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
