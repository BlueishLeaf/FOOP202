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

namespace Week8_Tasks
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
            StockLevelBox.ItemsSource = Enum.GetNames(typeof(Program.StockLevel));
            SuppliersBox.ItemsSource = _appInstance.GetSuppliers();
            CountryBox.ItemsSource = _appInstance.GetCountries();
            ProductsBox.ItemsSource = _appInstance.GetProducts();
        }

        private void StockLevelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOption = StockLevelBox.SelectedItem;

        }

        private void SuppliersBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CountryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
