using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Question1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Band> bandList = new List<Band>();
        string[] comboOptions = { "All","Pop","Rock","Indie"};
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            Random geneRandom = new Random();
            Album a1 = new Album(GetRandomYear(1980, 2000, geneRandom)) {AlbumName = "Californication", Sales = geneRandom.Next(1000000,2000000)};
            Album a2 = new Album(GetRandomYear(1980, 2000, geneRandom)) { AlbumName = "Fragile", Sales = geneRandom.Next(1000000, 2000000) };
            Album a3 = new Album(GetRandomYear(1980, 2000, geneRandom)) { AlbumName = "Ritchie Blackmore's Rainbow", Sales = geneRandom.Next(1000000, 2000000) };
            Album a4 = new Album(GetRandomYear(1980, 2000, geneRandom)) { AlbumName = "Court of the Crimson King", Sales = geneRandom.Next(1000000, 2000000) };
            Album a5 = new Album(GetRandomYear(1980, 2000, geneRandom)) { AlbumName = "The Dark Side of the Moon", Sales = geneRandom.Next(1000000, 2000000) };
            Album a6 = new Album(GetRandomYear(1980, 2000, geneRandom)) { AlbumName = "Love Gun", Sales = geneRandom.Next(1000000, 2000000) };

            bandList.Add(new PopBand() { BandName = "Red Hot Chilli Peppers", YearFormed = "1983", Members = new List<string> { "Flea", "Anthony Kiedis", "Chad Smith", "Josh Klinghoffer" },Albums = new List<Album>{a1}});
            bandList.Add(new RockBand() { BandName = "Rainbow", YearFormed = "1975", Members = new List<string> { "Ritchie Blackmore", "Ronnie James Dio", "Joe Lynn Turner" },Albums = new List<Album>{a2}});
            bandList.Add(new IndieBand() { BandName = "King Crimson", YearFormed = "1968", Members = new List<string> { "Robert Fripp", "Mel Collins", "Tony Levin", "Pat Mastelotto","Jakko Jakszyk","Bill Rieflin","Jeremy Stacey" }, Albums = new List<Album> { a3 } });
            bandList.Add(new RockBand() { BandName = "Yes", YearFormed = "1968", Members = new List<string> { "Steve Howe", "Alan White", "Geoff Downes", "Billy Sherwood","Jon Davison" }, Albums = new List<Album> { a4 } });
            bandList.Add(new IndieBand() { BandName = "Pink Floyd", YearFormed = "1965", Members = new List<string> { "David Gilmour", "Roger Waters", "Syd Barrett","Richard Wright","Nick Mason" }, Albums = new List<Album> { a5 } });
            bandList.Add(new PopBand() { BandName = "KISS", YearFormed = "1973", Members = new List<string> { "Paul Stanley", "Gene Simmons", "Tommy THayer","Eric Singer"}, Albums = new List<Album> { a6 } });
            bandList.Sort();
            BandListBox.ItemsSource = bandList;
            GenreCombo.ItemsSource = comboOptions;
        }

        private DateTime GetRandomYear(int startYear, int endYear, Random random)
        {
            DateTime start = new DateTime(startYear,1,1);
            DateTime end = new DateTime(endYear, 1, 1);
            int range = (end - start).Days;
            DateTime newDate = start.AddDays(random.Next(range));
            return newDate;
        }

        private void BandListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            YearFormedBlock.Text = null;
            MembersBlock.Text = null;
            AlbumListBox.ItemsSource = null;
            if (BandListBox.SelectedItem!=null)
            {
                Band selectedBand = (Band)BandListBox.SelectedItem;
                YearFormedBlock.Text = selectedBand.YearFormed;
                MembersBlock.Text = String.Join(",",selectedBand.Members);
                AlbumListBox.ItemsSource = selectedBand.Albums;
            }
        }

        private void GenreCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BandListBox.ItemsSource = null;
            List<Band> filteredList = new List<Band>();
            switch (GenreCombo.SelectedIndex)
            {
                case 0:
                    BandListBox.ItemsSource = bandList;
                    break;
                case 1:
                    foreach (Band t in bandList)
                    {
                        if(t is PopBand)
                        {
                            filteredList.Add(t);
                        }
                    }
                    BandListBox.ItemsSource = filteredList;
                    break;
                case 2:
                    foreach (Band t in bandList)
                    {
                        if (t is RockBand)
                        {
                            filteredList.Add(t);
                        }
                    }
                    BandListBox.ItemsSource = filteredList;
                    break;
                case 3:
                    foreach (Band t in bandList)
                    {
                        if (t is IndieBand)
                        {
                            filteredList.Add(t);
                        }
                    }
                    BandListBox.ItemsSource = filteredList;

                    break;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Band selectedBand = (Band)BandListBox.SelectedItem;
            using (StreamWriter writer =
                new StreamWriter("BandInfo.txt"))
            {
                writer.WriteLine(selectedBand.BandName);
                foreach (string t in selectedBand.Members)
                {
                    writer.WriteLine(t);
                }
                writer.WriteLine(selectedBand.YearFormed);
                foreach (Album t in selectedBand.Albums)
                {
                    writer.WriteLine(t.AlbumName);
                }
            }
        }
    }
}
