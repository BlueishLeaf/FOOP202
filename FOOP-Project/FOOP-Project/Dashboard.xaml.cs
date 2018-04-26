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
        public readonly DashboardControl DashCon;
        public Dashboard(int userId)
        {
            InitializeComponent();
            DashCon = new DashboardControl(userId);
            PeopleBox.ItemsSource = DashCon.GetPeople();
            SortByCombo.ItemsSource = DashCon.SortByStrings;
            ShowEventsCombo.ItemsSource = DashCon.UpcomingEventsStrings;
            SortByGiftsCombo.ItemsSource = DashCon.SortByGiftStrings;
        }

        private void PeopleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            EventBox.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
            GiftsBox.ItemsSource = null;
        }

        private void EventBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(EventBox.SelectedItem is Event selectedEvent)) return;
            GiftsBox.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

        private void SortByCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PeopleBox.ItemsSource = DashCon.SortPeople(SortByCombo.SelectedIndex, PeopleBox.ItemsSource as IEnumerable<Person>);
        }

        private void ShowEventsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            EventBox.ItemsSource = DashCon.SortEvents(ShowEventsCombo.SelectedIndex, DashCon.GetEvents(selectedPerson.Id));
        }

        private void SortByGiftsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EventBox.SelectedItem==null) return;
            GiftsBox.ItemsSource = DashCon.SortGifts(SortByGiftsCombo.SelectedIndex, GiftsBox.ItemsSource as IEnumerable<Gift>);
        }


        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            DashCon.AddPerson(this);
            PeopleBox.ItemsSource = DashCon.GetPeople();
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            DashCon.AddEvent(this, selectedPerson.Id);
            EventBox.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
        }

        private void AddGift_Click(object sender, RoutedEventArgs e)
        {
            if (!(EventBox.SelectedItem is Event selectedEvent)) return;
            DashCon.AddGift(this, selectedEvent.Id);
            GiftsBox.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            DashCon.DeletePerson(selectedPerson);
            PeopleBox.ItemsSource = DashCon.GetPeople();
        }

        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!(EventBox.SelectedItem is Event selectedEvent)) return;
            DashCon.DeleteEvent(selectedEvent);
            if (!(PeopleBox.SelectedItem is Person selectedPerson)) return;
            EventBox.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
        }

        private void DeleteGift_Click(object sender, RoutedEventArgs e)
        {
            if (!(GiftsBox.SelectedItem is Gift selectedGift)) return;
            DashCon.DeleteGift(selectedGift);
            if (!(EventBox.SelectedItem is Event selectedEvent)) return;
            GiftsBox.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

    }
}
