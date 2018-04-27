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

        //Pass the text in the text boxes back to the SaveGift function in the Dashboard control
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            main.DashCon.SaveGift(TbxGiftName.Text, TbxGiftPrice.Text,_eventId);
            Close();
        }

        //Close the Window
        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Close();

        //Calls the random function in the dashboard control and populates the text boxes with the values
        private void BtnRandom_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            var randomizedValues = main.DashCon.RandomizeGift();
            TbxGiftName.Text = randomizedValues[0];
            TbxGiftPrice.Text = randomizedValues[1];
        }
    }
}
