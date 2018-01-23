using System;
using System.Collections.Generic;
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
        List<Band> bandArray = new List<Band>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            Random geneRandom = new Random();
            Album a1 = new Album(){AlbumName = "Californication",ReleaseYear = geneRandom.Next(1980,2000),Sales = geneRandom.Next(1000000,2000000)};
            Album a2 = new Album() { AlbumName = "Fragile", ReleaseYear = geneRandom.Next(1980, 2000), Sales = geneRandom.Next(1000000, 2000000) };
            Album a3 = new Album() { AlbumName = "Ritchie Blackmore's Rainbow", ReleaseYear = geneRandom.Next(1980, 2000), Sales = geneRandom.Next(1000000, 2000000) };
            Album a4 = new Album() { AlbumName = "Court of the Crimson King", ReleaseYear = geneRandom.Next(1980, 2000), Sales = geneRandom.Next(1000000, 2000000) };
            Album a5 = new Album() { AlbumName = "The Dark Side of the Moon", ReleaseYear = geneRandom.Next(1980, 2000), Sales = geneRandom.Next(1000000, 2000000) };
            Album a6 = new Album() { AlbumName = "Love Gun", ReleaseYear = geneRandom.Next(1980, 2000), Sales = geneRandom.Next(1000000, 2000000) };

            bandArray.Add(new PopBand() { BandName = "Red Hot Chilli Peppers", YearFormed = "1983", Members = new List<string> { "Flea", "Anthony Kiedis", "Chad Smith", "Josh Klinghoffer" },Albums = new List<Album>{a1}});
            bandArray.Add(new RockBand() { BandName = "Rainbow", YearFormed = "1975", Members = new List<string> { "Ritchie Blackmore", "Ronnie James Dio", "Joe Lynn Turner" },Albums = new List<Album>{a2}});
            bandArray.Add(new IndieBand() { BandName = "King Crimson", YearFormed = "1968", Members = new List<string> { "Robert Fripp", "Mel Collins", "Tony Levin", "Pat Mastelotto","Jakko Jakszyk","Bill Rieflin","Jeremy Stacey" }, Albums = new List<Album> { a3 } });
            bandArray.Add(new RockBand() { BandName = "Yes", YearFormed = "1968", Members = new List<string> { "Steve Howe", "Alan White", "Geoff Downes", "Billy Sherwood","Jon Davison" }, Albums = new List<Album> { a4 } });
            bandArray.Add(new IndieBand() { BandName = "Pink Floyd", YearFormed = "1965", Members = new List<string> { "David Gilmour", "Roger Waters", "Syd Barrett","Richard Wright","Nick Mason" }, Albums = new List<Album> { a5 } });
            bandArray.Add(new PopBand() { BandName = "KISS", YearFormed = "1973", Members = new List<string> { "Paul Stanley", "Gene Simmons", "Tommy THayer","Eric Singer"}, Albums = new List<Album> { a6 } });
            bandArray.Sort();
            BandListBox.ItemsSource = bandArray;
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
    }
}
