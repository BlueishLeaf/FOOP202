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
        public MainWindow()
        {
            InitializeComponent();
        }

        public DateTime GetRandomDOB(int startYear, int endYear, Random random)
        {
            DateTime start = new DateTime(startYear, 1, 1);
            DateTime end = new DateTime(endYear, 1, 1);
            int range = (end - start).Days;
            DateTime newDate = start.AddDays(random.Next(range));
            return newDate;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            List<Player> playerList = new List<Player>();
            playerList.Add(new Player("Killian1",GetRandomDOB(2008,2018,random)));
            playerList.Add(new Player("Killian2", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian3", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian4", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian5", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian6", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian7", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian8", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian9", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian10", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian11", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian12", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian13", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian14", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian15", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian16", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian17", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian18", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian19", GetRandomDOB(2008, 2018, random)));
            playerList.Add(new Player("Killian20", GetRandomDOB(2008, 2018, random)));
            PlayerBox.ItemsSource = playerList;
        }

        private void PlayerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
