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
    /// Interaction logic for AllTesters.xaml
    /// </summary>
    public partial class AllTesters : Window
    {
        BL.IBL bl;
        public AllTesters()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            Testers.ItemsSource = bl.getAllTester();
        }

        private void Testers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
