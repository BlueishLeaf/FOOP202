using System.Windows;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson
    {
        public AddPerson() => InitializeComponent();

        //Pass the data in the text box and date picker back to the SavePerson function in the dashboard control
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!(Owner is Dashboard main)) return;
            if (DpkrDob.SelectedDate != null)
                main.DashCon.SavePerson(TbxName.Text, DpkrDob.SelectedDate.Value, TbxGender.Text);
            Close();
        }

        //Close the window
        private void BtnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
