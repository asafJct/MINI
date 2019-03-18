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
    /// Interaction logic for AllTrainee.xaml
    /// </summary>
    public partial class AllTrainee : Window
    {
        BL.IBL bl;
        public AllTrainee()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            Trainees.ItemsSource = bl.getAllTrainee();
        }

        private void Testers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
