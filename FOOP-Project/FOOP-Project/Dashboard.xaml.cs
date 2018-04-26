using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FOOP_Project
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard
    {
        public readonly DashboardControl DashCon;
        private readonly string[] _cbxSortPeopleStrings = { "Name A-Z", "Name Z-A", "Age Asc", "Age Desc", "Gender A-Z", "Gender Z-A" };
        private readonly string[] _cbxFilterEventsStrings = { "All", "1 Week", "2 Weeks", "1 Month", "2 Months", "1 Year", "2 Years" };
        private readonly string[] _cbxSortGiftsStrings = { "Name A-Z", "Name Z-A", "Price Asc", "Price Desc" };
        public Dashboard(int userId)
        {
            InitializeComponent();
            DashCon = new DashboardControl(userId);
            LbxPeople.ItemsSource = DashCon.GetPeople();
            CbxSortPeople.ItemsSource = _cbxSortPeopleStrings;
            CbxFilterEvents.ItemsSource = _cbxFilterEventsStrings;
            CbxSortGifts.ItemsSource = _cbxSortGiftsStrings;
        }

        private void LbxPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            LbxEvents.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
            LbxGifts.ItemsSource = null;
        }

        private void LbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            LbxGifts.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

        private void CbxSortPeople_SelectionChanged(object sender, SelectionChangedEventArgs e) => LbxPeople.ItemsSource = DashCon.SortPeople(CbxSortPeople.SelectedIndex, LbxPeople.ItemsSource as IEnumerable<Person>);

        private void CbxFilterEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            LbxEvents.ItemsSource = DashCon.SortEvents(CbxFilterEvents.SelectedIndex, DashCon.GetEvents(selectedPerson.Id));
        }

        private void CbxSortGifts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxEvents.SelectedItem==null) return;
            LbxGifts.ItemsSource = DashCon.SortGifts(CbxSortGifts.SelectedIndex, LbxGifts.ItemsSource as IEnumerable<Gift>);
        }


        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            DashCon.AddPerson(this);
            LbxPeople.ItemsSource = DashCon.GetPeople();
        }

        private void BtnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            DashCon.AddEvent(this, selectedPerson.Id);
            LbxEvents.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
        }

        private void BtnAddGift_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            DashCon.AddGift(this, selectedEvent.Id);
            LbxGifts.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            DashCon.DeletePerson(selectedPerson);
            LbxPeople.ItemsSource = DashCon.GetPeople();
        }

        private void BtnDeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            DashCon.DeleteEvent(selectedEvent);
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            LbxEvents.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
        }

        private void BtnDeleteGift_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxGifts.SelectedItem is Gift selectedGift)) return;
            DashCon.DeleteGift(selectedGift);
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            LbxGifts.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

    }
}
