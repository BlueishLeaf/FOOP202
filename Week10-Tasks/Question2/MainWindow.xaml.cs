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

namespace Question2
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

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {
            var names = new List<string>();
            var salaries = new List<decimal>();
            try
            {
                foreach (string line in File.ReadLines("salary.txt"))
                {
                    var values = line.Split(',');
                    names.Add(values[0]);
                    salaries.Add(Convert.ToDecimal(values[1]));
                }

                for (var i = 0; i < names.Count; i++)
                {
                    DataBox.Items.Add(string.Format(names[i] + '-' + salaries[i]));
                }
            }
            
            catch (FileNotFoundException nf)
            {
                MessageBox.Show(nf.Message);
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }
    }
}
