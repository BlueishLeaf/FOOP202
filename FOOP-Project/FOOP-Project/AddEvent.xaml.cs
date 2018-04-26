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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            if (DateBx.SelectedDate != null)
                main.DashCon.SaveEvent(NameTbx.Text, DateBx.SelectedDate.Value, _personId);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
