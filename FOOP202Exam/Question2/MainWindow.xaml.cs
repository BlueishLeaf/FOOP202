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

namespace Question2
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
            Query1();
        }

        private void LbxEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxEmployees.SelectedItem != null)
            {
                var selectedEmployeeId = Convert.ToInt32(LbxEmployees.SelectedValue);
                Query3(selectedEmployeeId);
            }
        }

        private void LbxManagers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxManagers.SelectedItem != null)
            {
                var selectedManagerId = Convert.ToInt32(LbxManagers.SelectedValue);
                Query2(selectedManagerId);

            }
        }

        public class EmployeeSummary : Employee
        {
            public override string ToString()
            {
                return $"{LastName},{FirstName}";
            }
        }

        private void Query1()
        {
            var query = from emp in _db.Employees
                        where emp.Title.Contains("Manager")
                        orderby emp.LastName ascending 
                        select new EmployeeSummary()
                        {
                            EmployeeID = emp.EmployeeID,
                            LastName = emp.LastName,
                            FirstName = emp.FirstName
                        };

            LbxManagers.ItemsSource = query.ToList();
        }

        private void Query2(int id)
        {
            var query = from emp in _db.Employees
                        where emp.ReportsTo == id
                        orderby emp.LastName ascending 
                        select new EmployeeSummary()
                        {
                            EmployeeID = emp.EmployeeID,
                            LastName = emp.LastName,
                            FirstName = emp.FirstName
                        };
            LbxEmployees.ItemsSource = query.ToList();
        }

        private void Query3(int id)
        {
            var query = from order in _db.Orders
                        where order.EmployeeID==id
                        group order by order.OrderID into g
                        join od in _db.Order_Details on g.Key equals od.OrderID
                        select new
                        {
                            OrderID = od.OrderID,
                            Customer = g.Key,
                            OrderTotal = (od.UnitPrice * od.Quantity) //* (1 - Convert.ToDecimal(od.Discount))
                        };
            DgOrders.ItemsSource = query.ToList();

        }
    }
}
