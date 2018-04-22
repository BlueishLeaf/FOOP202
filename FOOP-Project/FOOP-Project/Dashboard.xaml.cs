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
using System.Windows.Shapes;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard
    {
        private readonly DashboardControl _dashboard;
        public Dashboard(int userId)
        {
            InitializeComponent();
            _dashboard = new DashboardControl(userId);
            PeopleBox.ItemsSource = _dashboard.GetPeople();
        }
    }
}
