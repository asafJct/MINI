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
    /// Interaction logic for DeleteTester.xaml
    /// </summary>
    public partial class DeleteTester : Window
    {
        BE.Tester tester;
        BL.IBL bl;
           
        public DeleteTester()
        {
            InitializeComponent();
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            tester = new BE.Tester();
            this.DataContext = tester;
            TesterNameComboBox.ItemsSource = from item in bl.getAllTester()
                                           select item.id;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteTester(tester);
                BE.Tester or = new BE.Tester();
                MessageBox.Show(tester.id + "'s \n" + "is Deleted");
                TesterNameComboBox.ItemsSource = from item in bl.getAllTester()
                                               select item.id;
                this.DataContext = tester;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
