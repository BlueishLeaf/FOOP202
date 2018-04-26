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
    /// Interaction logic for AddGift.xaml
    /// </summary>
    public partial class AddGift : Window
    {
        private int _eventId;
        public AddGift(int eventId)
        {
            InitializeComponent();
            _eventId = eventId;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            main.DashCon.SaveGift(GiftNameTbx.Text, GiftPriceTbx.Text,_eventId);
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
