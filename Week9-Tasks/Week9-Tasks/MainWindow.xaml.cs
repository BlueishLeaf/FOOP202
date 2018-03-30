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

namespace Week9_Tasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NORTHWNDEntities _db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Qry1_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in _db.Customers
                        group c by c.Country into g
                        orderby g.Count() descending
                        select new
                        {
                            CustomerCountry = g.Key,
                            NumCustomers = g.Count()
                        };
            DataBox1.ItemsSource = query.ToList();


        }

        private void Qry2_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in _db.Customers
                        where c.Country == "Italy"
                        select new
                        {
                            c.Orders,
                            c.CustomerDemographics,
                            c.CustomerID,
                            c.CompanyName,
                            c.ContactName
                        };
            DataBox2.ItemsSource = query.ToList();
        }

        private void Qry3_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in _db.Products
                        where p.UnitsInStock > 0
                        select new
                        {
                            p.ProductName,
                            p.UnitsInStock
                        };
            DataBox3.ItemsSource = query.ToList();
        }

        private void Qry4_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in _db.Orders
                        join d in _db.Order_Details on o.OrderID equals d.OrderID into oj
                        from suborder in oj
                        orderby suborder.OrderID
                        where suborder.Discount != 0
                        select new
                        {
                            suborder.Product.ProductName,
                            suborder.Discount,
                            suborder.OrderID
                        };
            DataBox4.ItemsSource = query.ToList();
        }

        private void Qry5_Click(object sender, RoutedEventArgs e)
        {
            var query = (from o in _db.Orders
                         select o.Freight).Sum();
            DataBox5.Text = $"Total value of freight is: {query:C}"; ;
        }

        private void Qry6_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in _db.Products
                        join c in _db.Categories on p.CategoryID equals c.CategoryID into oj
                        from sub in oj
                        orderby sub.CategoryID, p.UnitPrice descending
                        select new
                        {
                            sub.CategoryID,
                            sub.CategoryName,
                            p.ProductName,
                            p.UnitPrice
                        };
            DataBox6.ItemsSource = query.ToList();
        }

        private void Qry7_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in _db.Orders
                        group o by o.CustomerID into g
                        orderby g.Count() descending
                        select new
                        {
                            g.Key,
                            NumOfOrders = g.Count()
                        };
            DataBox7.ItemsSource = query.ToList();
        }

        private void Qry8_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in _db.Orders
                        join c in _db.Customers on o.CustomerID equals c.CustomerID into oj
                        from sub in oj
                        orderby sub.CustomerID
                        group sub by sub.CompanyName into g
                        orderby g.Count() descending
                        select new
                        {
                            g.Key,
                            NumOfOrders = g.Count()
                        };
            DataBox8.ItemsSource = query.ToList();
        }

        private void Qry9_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in _db.Customers
                        join o in _db.Orders on c.CustomerID equals o.CustomerID into oj
                        from sub in oj
                        orderby sub.Customer.CompanyName

                        select new
                        {
                            sub.Customer.CompanyName,
                            NumOfOrders = 0
                        };
            DataBox9.ItemsSource = query.ToList();
        }
    }
}
