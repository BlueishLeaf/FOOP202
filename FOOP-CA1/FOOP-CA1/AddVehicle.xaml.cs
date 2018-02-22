﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FOOP_CA1
{
    /// <inheritdoc cref="Program" />
    /// <summary>
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        public Vehicle NewVehicle = new Vehicle();
        public AddVehicle()
        {
            InitializeComponent();
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
            NewVehicle.GetImage();
            if (CarTypeRadio.IsChecked == true)
            {
                var tempCar = (Car)NewVehicle;
                tempCar.BodyType = (BodyType)Enum.Parse(typeof(BodyType), BodyTypeBox.Text);
            }
            else if (BikeTypeRadio.IsChecked == true)
            {
                var tempBike = (Motorcycle)NewVehicle;
                tempBike.Type = (BikeType)Enum.Parse(typeof(BikeType), BikeTypeBox.Text);
            }
            else if (VanTypeRadio.IsChecked == true)
            {
                var tempVan = (Van)NewVehicle;
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
