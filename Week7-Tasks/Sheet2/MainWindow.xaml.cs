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

namespace Sheet2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NORTHWNDEntities1 _db = new NORTHWNDEntities1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Qry1_Click(object sender, RoutedEventArgs e)
        {
            var query = _db.Customers.Select(c => c.CompanyName);
            DataBox1.ItemsSource = query.ToList();
        }

        private void Qry2_Click(object sender, RoutedEventArgs e)
        {
            var query = _db.Customers.Select(c => c);
            DataBox2.ItemsSource = query.ToList();
        }

        private void Qry3_Click(object sender, RoutedEventArgs e)
        {
            var query = _db.Orders.Where(o => o.Customer.City.Equals("London") || o.Customer.City.Equals("Paris") || o.Customer.City.Equals("USA")).OrderBy(o => o.Customer.CompanyName).Select(o => new { o.Customer.CompanyName, o.Customer.City, o.Customer.Address });
            DataBox3.ItemsSource = query.ToList().Distinct();
        }

        private void Qry4_Click(object sender, RoutedEventArgs e)
        {
            var query = _db.Products.Where(p => p.Category.CategoryName.Equals("Beverages")).OrderByDescending(p => p.ProductID).Select(p => new { p.ProductID, p.ProductName, p.Category.CategoryName, p.UnitPrice });
            DataBox4.ItemsSource = query.ToList();
        }

        private void Qry5_Click(object sender, RoutedEventArgs e)
        {
            var prod = new Product()
            {
                ProductName = "Kick",
                UnitPrice = 12.49m,
                CategoryID = 1
            };
            _db.Products.Add(prod);
            _db.SaveChanges();
            var query = _db.Products.Where(p => p.Category.CategoryName.Equals("Beverages")).OrderByDescending(p => p.ProductID).Select(p => new { p.ProductID, p.ProductName, p.Category.CategoryName, p.UnitPrice });
            DataBox5.ItemsSource = query.ToList();
        }

        private void Qry6_Click(object sender, RoutedEventArgs e)
        {
            var p1 = _db.Products.Where(p => p.ProductName.StartsWith("Kick")).Select(p => p).First();
            p1.UnitPrice = 100m;
            _db.SaveChanges();
            var query = _db.Products.Where(p => p.Category.CategoryName.Equals("Beverages")).OrderByDescending(p => p.ProductID).Select(p => new { p.ProductID, p.ProductName, p.Category.CategoryName, p.UnitPrice });
            DataBox6.ItemsSource = query.ToList();
        }

        private void Qry7_Click(object sender, RoutedEventArgs e)
        {
            var products = _db.Products.Where(p => p.ProductName.StartsWith("Kick")).Select(p => p);
            foreach (var product in products)
            {
                product.UnitPrice = 100m;
            }

            _db.SaveChanges();
            var query = _db.Products.Where(p => p.Category.CategoryName.Equals("Beverages")).OrderByDescending(p => p.ProductID).Select(p => new { p.ProductID, p.ProductName, p.Category.CategoryName, p.UnitPrice });
            DataBox7.ItemsSource = query.ToList();
        }

        private void Qry8_Click(object sender, RoutedEventArgs e)
        {
            var products = _db.Products.Where(p => p.ProductName.StartsWith("Kick")).Select(p => p);
            _db.Products.RemoveRange(products);
            _db.SaveChanges();
            var query = _db.Products.Where(p => p.Category.CategoryName.Equals("Beverages")).OrderByDescending(p => p.ProductID).Select(p => new { p.ProductID, p.ProductName, p.Category.CategoryName, p.UnitPrice });
            DataBox8.ItemsSource = query.ToList();
        }

        private void Qry9_Click(object sender, RoutedEventArgs e)
        {
            var query = _db.Customers.Select(c => c);
            DataBox9.ItemsSource = query.ToList();
        }

        private void Qry10_Click(object sender, RoutedEventArgs e)
        {
            var query = _db.Customers.Select(c => c);
            DataBox10.ItemsSource = query.ToList();
        }
    }
}
