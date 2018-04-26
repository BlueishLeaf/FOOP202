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
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        private int _personId;
        public AddEvent(int personId)
        {
            InitializeComponent();
            _personId = personId;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            if (DateBx.SelectedDate != null)
                main.DashCon.SaveEvent(NameTbx.Text, DateBx.SelectedDate.Value, _personId);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
