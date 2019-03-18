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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Troinee : Window
    {
        public Troinee()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddTest();
            window.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var window = new deleteTest();
            window.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var window = new UpdateTest();
            window.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var window = new AllTest();
            window.ShowDialog();
        }
    }
}
