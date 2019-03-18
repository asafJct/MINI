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
    /// Interaction logic for DeleteTrainee.xaml
    /// </summary>
    public partial class DeleteTrainee : Window
    {
        BE.Trainee trainee;
        BL.IBL bl;

      
        public DeleteTrainee()
        {
            InitializeComponent();
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            trainee = new BE.Trainee();
            this.DataContext = trainee;
            TraineeNameComboBox.ItemsSource = from item in bl.getAllTester()
                                             select item.id;

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.deleteTrainee(trainee);
                BE.Trainee or = new BE.Trainee();
                MessageBox.Show(trainee.id + "'s \n" + "is Deleted");
                TraineeNameComboBox.ItemsSource = from item in bl.getAllTester()
                                                 select item.id;
                this.DataContext = trainee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
