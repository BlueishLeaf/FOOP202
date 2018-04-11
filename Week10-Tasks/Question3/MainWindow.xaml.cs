using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace Question3
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

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            var a = Convert.ToDouble(ABox.Text);
            var b = Convert.ToDouble(BBox.Text);
            var c = Convert.ToDouble(CBox.Text);
            Solve(ref a, ref b, ref c);
        }

        private void Solve(ref double a, ref double b, ref double c)
        {

            var root1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);

            var root2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            if (root2 < 0)
            {
                
                throw (new ArithmeticException("Cant be negativo"));
            }
            Root1Box.Text = root1.ToString();
            Root2Box.Text = root2.ToString();



        }
    }
}
