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
    /// Interaction logic for AllTest.xaml
    /// </summary>
    public partial class AllTest : Window
    {
        BL.IBL bl;
        public AllTest()
        {
            InitializeComponent();                                
            bl = BL.FactoryBL.getBL();
            Tests.ItemsSource = bl.getAllTest();
        
    }

        private void brancesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
