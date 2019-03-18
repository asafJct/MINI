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
    /// Interaction logic for UpdateTrainee.xaml
    /// </summary>
    public partial class UpdateTrainee : Window
    {
        BL.IBL bl;
        BE.Trainee trainee;
        public UpdateTrainee()
        {
            InitializeComponent();
            trainee = new BE.Trainee();
            bl = BL.FactoryBL.getBL();
            comboBox.ItemsSource = from item in bl.getAllTrainee()
                                    select item.id;
            trainee = bl.FindTrainee(Convert.ToInt32(comboBox.ItemsSource));
            #region
            FristBox.Text = trainee.firstName;
            LastNameTextBox.Text = trainee.lastName;
            BirthdayTextBox.Text = Convert.ToString(trainee.birthday);
            AddressTextBox.Text = Convert.ToString(trainee.Adress) ;
            SchoolTextBox.Text = trainee.school;
            Teacher.Text = trainee.teacher;
            NumberOfLessons.Text = Convert.ToString(trainee.numOfLessons);
            #endregion
            this.comboBox1.ItemsSource = Enum.GetValues(typeof(BE.gender));
            this.comboBox2.ItemsSource = Enum.GetValues(typeof(BE.vehicle));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateTrainee(trainee);
                trainee = new BE.Trainee();
                MessageBox.Show("the trainee's details " + trainee.id + " update ", "");
                this.gridUpdateTrainee.DataContext = trainee;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            trainee = bl.getAllTrainee(b => b.id == trainee.id).FirstOrDefault();
            this.gridUpdateTrainee.DataContext = trainee;
        }

        private void freeDeliverNumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #region set up
        private void FirstBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.firstName = Convert.ToString(FristBox.Text);
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
            trainee.birthday = Convert.ToDateTime(BirthdayTextBox.Text);
        }

        private void TelephoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            trainee.phoneNum = Convert.ToString(TelephonenumberTextBox.Text);
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
