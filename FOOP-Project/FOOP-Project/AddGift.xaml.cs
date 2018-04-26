using System.Windows;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for AddGift.xaml
    /// </summary>
    public partial class AddGift : Window
    {
        private readonly int _eventId;
        public AddGift(int eventId)
        {
            InitializeComponent();
            _eventId = eventId;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            main.DashCon.SaveGift(GiftNameTbx.Text, GiftPriceTbx.Text,_eventId);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
