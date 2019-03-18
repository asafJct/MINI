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
    /// Interaction logic for UpdateTester.xaml
    /// </summary>
    public partial class UpdateTester : Window
    {
        BE.Tester tester;
        BL.IBL bl;
        public UpdateTester()
        {
            InitializeComponent();
            tester = new BE.Tester();
            bl = BL.FactoryBL.getBL();
            tester = bl.getAllTester(b => b.id == tester.id).FirstOrDefault();
            #region set up with the former value .
            BirthdayTextBox.Text = Convert.ToString(tester.birthday);
            TelephoneTextBox.Text= Convert.ToString(tester.phoneNum);
            TextBox.Text = Convert.ToString(tester.Experience);
            MaximumTextBox.Text = Convert.ToString(tester.MaxTests);
            textBox1.Text = Convert.ToString(tester.distance);
            FirstNameTextBox.Text = Convert.ToString(tester.Name);
            TesterLastNameTextBox.Text = Convert.ToString(tester.familyName);
                                 
       #endregion           
            comboBox6.ItemsSource = from item in bl.getAllTester()
                                               select item.id;
            this.comboBox1.ItemsSource = Enum.GetValues(typeof(BE.gender));
            this.comboBox2.ItemsSource = Enum.GetValues(typeof(BE.vehicle));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateTester(tester);
                tester = new BE.Tester();
                MessageBox.Show("the branch " + tester.id + " update ", "");
                this.DataContext = tester;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region set up
        private void comboBox6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tester = bl.getAllTester(b => b.id == tester.id).FirstOrDefault();
            this.DataContext = tester;
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BirthdayTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.birthday = Convert.ToDateTime(BirthdayTextBox.Text);
        }

        private void TelephoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.phoneNum = Convert.ToInt32(TelephoneTextBox.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.Experience = Convert.ToInt32(TextBox.Text);
        }

        private void MaximumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.MaxTests = Convert.ToInt32(MaximumTextBox.Text);
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.distance = Convert.ToInt32(textBox1.Text);
        }
        private void freeDeliverNumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.Name = FirstNameTextBox.Text;
        }

        private void branchPhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.familyName = TesterLastNameTextBox.Text;
        }
        #endregion

    }
}
