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
                var tempCar = selectedVehicle as Car;
                BodyTypeBox.Text = tempCar.BodyType.ToString();
            }
            else if (selectedVehicle.GetType() == typeof(Motorcycle))
            {
                BikeTypeRadio.IsChecked = true;
                var tempBike = selectedVehicle as Motorcycle;
                BikeTypeBox.Text = tempBike.Type.ToString();
            }
            else if (selectedVehicle.GetType() == typeof(Van))
            {
                VanTypeRadio.IsChecked = true;
                var tempVan = selectedVehicle as Van;
                VanTypeBox.Text = tempVan.Type.ToString();
                WheelbaseBox.Text = tempVan.Wheelbase.ToString();
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
            NewVehicle.ImagePath = ((MainWindow)Application.Current.MainWindow)?.AppInstance.SelectImage();
            PreviewImg.Source = new BitmapImage(new Uri(NewVehicle.ImagePath));
        }

        private void SaveDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            NewVehicle.Make = MakeBox.Text;
            NewVehicle.Model = ModelBox.Text;
            NewVehicle.Price = Convert.ToDecimal(PriceBox.Text);
            NewVehicle.Year = Convert.ToInt32(YearBox.Text);
            NewVehicle.Colour = ColourBox.Text;
            NewVehicle.Mileage = Convert.ToInt32(MileageBox.Text);
            NewVehicle.Description = DescriptionBox.Text;
            if (NewVehicle.GetType() == typeof(Car))
            {
                var tempCar = NewVehicle as Car;
                tempCar.BodyType = (BodyType)Enum.Parse(typeof(BodyType), BodyTypeBox.Text);
            }
            else if (NewVehicle.GetType() == typeof(Motorcycle))
            {
                var tempBike = NewVehicle as Motorcycle;
                tempBike.Type = (BikeType)Enum.Parse(typeof(BikeType), BikeTypeBox.Text);
            }
            else if (NewVehicle.GetType() == typeof(Van))
            {
                var tempVan = NewVehicle as Van;
                tempVan.Type = (VanType)Enum.Parse(typeof(VanType), VanTypeBox.Text);
                tempVan.Wheelbase = (Wheelbase)Enum.Parse(typeof(Wheelbase), WheelbaseBox.Text);
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
