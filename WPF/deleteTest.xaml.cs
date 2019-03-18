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
    /// Interaction logic for deleteTest.xaml
    /// </summary>
    public partial class deleteTest : Window
    {
        BE.Test test;
        BL.IBL bl;
        public deleteTest()
        {
            InitializeComponent();
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            test = new BE.Test();
            this.DataContext = test;
            TestNameComboBox.ItemsSource = from item in bl.getAllTest()
                                            select item.TestNumber;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try { 
            bl.deleteTest(test);
            BE.Test or = new BE.Test();
            MessageBox.Show(test.TestNumber + "'s \n" + "is Deleted");
            TestNameComboBox.ItemsSource = from item in bl.getAllTest()
                                            select item.TestNumber;
            this.DataContext = test;
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}
    }
}
