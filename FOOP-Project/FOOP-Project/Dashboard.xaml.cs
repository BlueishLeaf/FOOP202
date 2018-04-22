using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            SortByCombo.ItemsSource = _dashboard.SortByStrings;
            ShowEventsCombo.ItemsSource = _dashboard.UpcomingEventsStrings;
            SortByGiftsCombo.ItemsSource = _dashboard.SortByGiftStrings;
        }

        private void PeopleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            EventBox.ItemsSource = _dashboard.GetEvents(selectedPerson.Id);
            GiftsBox.ItemsSource = null;
        }

        private void EventBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(EventBox.SelectedItem is Event selectedEvent)) return;
            GiftsBox.ItemsSource = _dashboard.GetGifts(selectedEvent.Id);
        }

        private void SortByCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PeopleBox.ItemsSource = _dashboard.SortPeople(SortByCombo.SelectedIndex, PeopleBox.ItemsSource as IEnumerable<Person>);
        }

        private void ShowEventsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            EventBox.ItemsSource = _dashboard.SortEvents(ShowEventsCombo.SelectedIndex, _dashboard.GetEvents(selectedPerson.Id));
        }

        private void SortByGiftsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EventBox.SelectedItem==null) return;
            GiftsBox.ItemsSource = _dashboard.SortGifts(SortByGiftsCombo.SelectedIndex, GiftsBox.ItemsSource as IEnumerable<Gift>);
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            _dashboard.AddPerson();
        }

        private void EditPerson_Click(object sender, RoutedEventArgs e)
        {
            _dashboard.EditPerson();
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            _dashboard.DeletePerson(selectedPerson);
        }
    }
}
