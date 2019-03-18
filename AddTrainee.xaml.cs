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
    /// Interaction logic for AddTrainee.xaml
    /// </summary>
    public partial class AddTrainee : Window
    {
        BE.Trainee trainee;
        BL.IBL bl;
        public AddTrainee()
        {
            InitializeComponent();
            trainee = new BE.Trainee();
            this.gridAddTrainee.DataContext = trainee;
            bl = BL.FactoryBL.getBL();
            this.comboBox1.ItemsSource = Enum.GetValues(typeof(BE.gender));
            this.comboBox2.ItemsSource = Enum.GetValues(typeof(BE.vehicle));
        }

        private void addBranchButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTrainee(trainee);

                MessageBox.Show("the trainee \"" + trainee.id);
                trainee = new BE.Trainee();
                this.gridAddTrainee.DataContext = trainee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region set up
        private void FirstBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.firstName = Convert.ToString(FirstBox.Text);
        }
       

        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.lastName = Convert.ToString(LastNameTextBox.Text);
        }

        private void StudentIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.id = Convert.ToInt32(StudentIDTextBox.Text);
        }

        private void BirthdayTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BirthdayTextBox.Text.Length==10)
               trainee.birthday = Convert.ToDateTime(BirthdayTextBox.Text);
        }

        private void TelephoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.phoneNum = Convert.ToString(TelephoneNumberTextBox.Text);
        }

        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.Adress = Convert.ToString(AddressTextBox.Text);
        }

        private void SchoolTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.school = Convert.ToString(SchoolTextBox.Text);
        }

        private void NumberOfLessons_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.numOfLessons = Convert.ToInt32(NumberOfLessons.Text);
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.teacher = Convert.ToString(Teacher.Text);
        }
        #endregion
    }
}
