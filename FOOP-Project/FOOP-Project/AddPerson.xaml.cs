using System.Windows;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson
    {
        public AddPerson() => InitializeComponent();

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            if (PersonDob.SelectedDate != null)
                main.DashCon.SavePerson(NameTbx.Text, PersonDob.SelectedDate.Value, GenderTbx.Text);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
