using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> playerList = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayerBox.ItemsSource = null;
            playerList.Add(new Player(PlayerNameBox.Text, DOBPicker.SelectedDate.Value));
            PlayerBox.ItemsSource = playerList;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("players.json"))
            {
                writer.Write(JsonConvert.SerializeObject(playerList, Formatting.Indented));
            }
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayerBox.ItemsSource = null;
            playerList.Clear();
            using (StreamReader reader = new StreamReader("players.json"))
            {
                List<Player> players = JsonConvert.DeserializeObject<List<Player>>(reader.ReadToEnd());
                foreach (Player player in players)
                {
                    playerList.Add(player);
                }
            }
            PlayerBox.ItemsSource = playerList;
        }
    }
}
