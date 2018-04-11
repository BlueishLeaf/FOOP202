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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var num1 = Convert.ToInt32(Num1Box.Text);
                var num2 = Convert.ToInt32(Num2Box.Text);
                Res1Block.Text = (num1 / num2).ToString();
                Res2Block.Text = (num2 / num1).ToString();
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
            catch (DivideByZeroException dz)
            {
                MessageBox.Show(dz.Message);
            }
        }
    }
}
