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

namespace FOOP202Exam
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
            //Set the list box item source when components are initialised
            LbxProducts.ItemsSource = _appInstance.CreateTestProducts();

        }

        private void LbxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected product is a product and is not null then assign it to selectedProduct
            // Set the textblock equal to the product details
            if (!(LbxProducts.SelectedItem is Product selectedProduct)) return;
            TbkProductDetails.Text = selectedProduct.ToString();
        }

        //Event handlers for radio buttons
        private void RadAll_Checked(object sender, RoutedEventArgs e)
        {
            //Call FilterProducts method and set the listbox itemsource
            LbxProducts.ItemsSource = _appInstance.FilterProducts("All");
        }

        private void RadBooks_Checked(object sender, RoutedEventArgs e)
        {
            LbxProducts.ItemsSource = _appInstance.FilterProducts("Books");
        }

        private void RadDvds_Checked(object sender, RoutedEventArgs e)
        {
            LbxProducts.ItemsSource = _appInstance.FilterProducts("DVDs");
        }

        private void RadGames_Checked(object sender, RoutedEventArgs e)
        {
            LbxProducts.ItemsSource = _appInstance.FilterProducts("Games");
        }
    }
}
