using System.Windows;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        private readonly int _personId;
        public AddEvent(int personId)
        {
            InitializeComponent();
            _personId = personId;
        }

        //Pass the text in the text box and the date back to the SaveEvent function in the dashboard control
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            if (DpkrDate.SelectedDate != null)
                main.DashCon.SaveEvent(TbxName.Text, DpkrDate.SelectedDate.Value, _personId);
            Close();
        }

        //Close the window
        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
