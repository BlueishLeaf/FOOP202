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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Foop202CA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Instantiate the database object
        private NORTHWNDEntities1 _db = new NORTHWNDEntities1();
        public MainWindow()
        {
            InitializeComponent();
            //Call query to populate product list box
            Query1();
        }

        private void Query1()
        {
            //Fetches distinct products from order details table and sorts them
            //in descending order by their number of orders
            var query = from od in _db.Order_Details
                        group od by od.ProductID into g
                        join p in _db.Products on g.Key equals p.ProductID
                        orderby g.Count() descending
                        select new ProductSummary
                        {
                            ProductID = p.ProductID,
                            ProductName = p.ProductName
                        };
            ProductBox.ItemsSource = query.ToList().Distinct();
        }
        //A class to provide a tostring override for the above query
        public class ProductSummary : Product
        {
            public override string ToString()
            {
                return string.Format("ID: {0}, Name: {1}", ProductID, ProductName);
            }
        }

        
        private void ProductBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Fetch productID from the selectedValuePath in the listbox
            int productID = Convert.ToInt32(ProductBox.SelectedValue);
            if (productID > 0)
            {
                //Group products that match the ID together in the order details table 
                //and counts them
                var query = from od in _db.Order_Details
                            where od.ProductID == productID
                            group od by od.ProductID into g
                            select g.Count();
                numOrdersBlock.Text = query.First().ToString();

                //Gets the quantity and unitprice of each order and multiplies them together for the order total
                //Then sums them all up to get the total order value for that product
                var query2 = from od in _db.Order_Details
                             where od.ProductID == productID
                             select (od.UnitPrice*od.Quantity);
                var sum = query2.Sum();
                //Format for euro
                var culture = CultureInfo.GetCultureInfo("en-IE");
                totalValueBlock.Text = String.Format(culture,"{0:C}", Convert.ToDecimal(sum));
                Console.WriteLine(totalValueBlock.Text);

                //Get the average cost of an order for a product by dividing the total order value by the number of orders
                var query3 = sum / query.First();
                orderAvgBlock.Text = String.Format(culture,"{0:C}", Convert.ToDecimal(query3));

                //Populate the data grid with the order details for every order on a product, including the total cost of every order
                var query4 = from od in _db.Order_Details
                             where od.ProductID == productID
                             select new
                             {
                                 OrderID = od.OrderID,
                                 Quantity = od.Quantity,
                                 UnitPrice = od.UnitPrice,
                                 Total = (od.UnitPrice * od.Quantity)
                             };
                OrderGrid.ItemsSource = query4.ToList();
            }
        }
    }
}
