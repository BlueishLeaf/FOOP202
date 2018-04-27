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
        //String arrays to populate the combo boxes
        private readonly string[] _cbxSortPeopleStrings = { "Name A-Z", "Name Z-A", "Age Asc", "Age Desc", "Gender A-Z", "Gender Z-A" };
        private readonly string[] _cbxFilterEventsStrings = { "All", "1 Week", "2 Weeks", "1 Month", "2 Months", "1 Year", "2 Years" };
        private readonly string[] _cbxSortGiftsStrings = { "Name A-Z", "Name Z-A", "Price Asc", "Price Desc" };

        //Constructor, populates combo boxes with string arraysand gets the people for the people list box
        public Dashboard(int userId)
        {
            InitializeComponent();
            DashCon = new DashboardControl(userId);
            LbxPeople.ItemsSource = DashCon.GetPeople();
            CbxSortPeople.ItemsSource = _cbxSortPeopleStrings;
            CbxFilterEvents.ItemsSource = _cbxFilterEventsStrings;
            CbxSortGifts.ItemsSource = _cbxSortGiftsStrings;
        }

        //When a person is selected, call the function that gets the events of that person
        private void LbxPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Single line to check if the selected item isnt null, then assigns it to selectedPerson. Used in a similar fashion elsewhere
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            LbxEvents.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
            LbxGifts.ItemsSource = null;
        }

        //When an event is selected, call the function that gets the gifts associated with that event
        private void LbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            LbxGifts.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

        //Call the sort function in the control, passing in the list of people as an enumerable
        private void CbxSortPeople_SelectionChanged(object sender, SelectionChangedEventArgs e) => LbxPeople.ItemsSource = DashCon.SortPeople(CbxSortPeople.SelectedIndex, LbxPeople.ItemsSource as IEnumerable<Person>);

        //Check if a person is selected (otherwise event list is empty) then calls the sort function
        private void CbxFilterEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            LbxEvents.ItemsSource = DashCon.SortEvents(CbxFilterEvents.SelectedIndex, DashCon.GetEvents(selectedPerson.Id));
        }

        //Check if an event is selected, then calls the sort function
        private void CbxSortGifts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbxEvents.SelectedItem==null) return;
            LbxGifts.ItemsSource = DashCon.SortGifts(CbxSortGifts.SelectedIndex, LbxGifts.ItemsSource as IEnumerable<Gift>);
        }

        //Call add person function and refresh the list box
        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            DashCon.AddPerson(this);
            LbxPeople.ItemsSource = DashCon.GetPeople();
        }

        //Check if person is selected, then call the add event function, then refresh the list box
        private void BtnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            DashCon.AddEvent(this, selectedPerson.Id);
            LbxEvents.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
        }

        //Check if an event is selected, then call the add gift function, then refresh the list box
        private void BtnAddGift_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            DashCon.AddGift(this, selectedEvent.Id);
            LbxGifts.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

        //Check if person is selected, then call delete person function, then refresh the list box
        private void BtnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            DashCon.DeletePerson(selectedPerson);
            LbxPeople.ItemsSource = DashCon.GetPeople();
        }

        //Check if an event is selected, then call delete person function, then refresh the list box
        private void BtnDeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            DashCon.DeleteEvent(selectedEvent);
            if (!(LbxPeople.SelectedItem is Person selectedPerson)) return;
            LbxEvents.ItemsSource = DashCon.GetEvents(selectedPerson.Id);
        }

        //Check if gift is selected, then call delete gift funtion, the refresh the list box
        private void BtnDeleteGift_Click(object sender, RoutedEventArgs e)
        {
            if (!(LbxGifts.SelectedItem is Gift selectedGift)) return;
            DashCon.DeleteGift(selectedGift);
            if (!(LbxEvents.SelectedItem is Event selectedEvent)) return;
            LbxGifts.ItemsSource = DashCon.GetGifts(selectedEvent.Id);
        }

    }
}
