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

namespace Question1
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
            EmployeeBox.ItemsSource = _appInstance.GetEmployees();
        }

        private void EmployeeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = EmployeeBox.SelectedItem;
            if (selectedItem != null)
            {
                var selectedEmployee = selectedItem as Employee;
                NameBlock.Text = selectedEmployee.FirstName + " " + selectedEmployee.LastName;
                PPSNBlock.Text = selectedEmployee.PPS;
                MonthlyPayBlock.Text = string.Format("{0} {1:C}","Monthly Pay:",selectedEmployee.GetMonthlyPay());
            }
        }
    }
}
