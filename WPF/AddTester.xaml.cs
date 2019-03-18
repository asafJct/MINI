using BL_3300;
using DAL;
using BE;
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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        BE.Tester tester;
        BL.IBL bl;
        public AddTester()
        {
            InitializeComponent();
            tester = new BE.Tester();
            this.gridAddTester.DataContext = tester;
            bl = BL.FactoryBL.getBL();
            this.comboBox1.ItemsSource = Enum.GetValues(typeof(BE.gender));
            this.comboBox2.ItemsSource = Enum.GetValues(typeof(BE.vehicle));
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTester(tester);

                MessageBox.Show("the Tester \"" + tester.id + "\" added to the list", "");
                tester = new BE.Tester();
                this.gridAddTester.DataContext = tester;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region CheckBoxes
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void checkBox31_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[0, 5] = (bool)checkBox31.IsChecked;
        }

        private void checkBox5_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[0, 0] = (bool)checkBox5.IsChecked;
        }
        

        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[0, 1] = (bool)checkBox4.IsChecked;
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[0, 2] = (bool)checkBox3.IsChecked;
        }

        private void checkBox13_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[0, 3] = (bool)checkBox13.IsChecked;
        }

        private void checkBox8_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[0, 4] = (bool)checkBox8.IsChecked;
        }

        private void checkBox6_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[1, 0] = (bool)checkBox6.IsChecked;
        }

        private void checkBox18_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[1, 1] = (bool)checkBox18.IsChecked;
        }

        private void checkBox16_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[1, 2] = (bool)checkBox16.IsChecked;
        }

        private void checkBox12_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[1, 3] = (bool)checkBox12.IsChecked;
        }

        private void checkBox9_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[1, 4] = (bool)checkBox9.IsChecked;
        }

        private void checkBox21_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[1, 5] = (bool)checkBox21.IsChecked;
        }

        private void checkBox17_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[2, 1] = (bool)checkBox17.IsChecked;
        }

        private void checkBox15_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[2, 2] = (bool)checkBox15.IsChecked;
        }

        private void checkBox11_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[2, 3] = (bool)checkBox11.IsChecked;
        }

        private void checkBox10_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[2, 4] = (bool)checkBox10.IsChecked;
        }

        private void checkBox22_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[2, 5] = (bool)checkBox22.IsChecked;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[3, 0] = (bool)checkBox2.IsChecked;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[3, 1] = (bool)checkBox.IsChecked;
        }

        private void checkBox26_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[3, 2] = (bool)checkBox26.IsChecked;
        }

        private void checkBox28_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[3, 3] = (bool)checkBox28.IsChecked;
        }

        private void checkBox14_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[3, 4] = (bool)checkBox14.IsChecked;
        }

        private void checkBox23_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[3, 5] = (bool)checkBox23.IsChecked;
        }

        private void checkBox7_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[4, 0] = (bool)checkBox7.IsChecked;
        }

        private void checkBox19_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[4, 1] = (bool)checkBox19.IsChecked;
        }

        private void checkBox30_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[4, 2] = (bool)checkBox30.IsChecked;
        }

        private void checkBox29_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[4, 3] = (bool)checkBox29.IsChecked;
        }

        private void checkBox25_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[4, 4] = (bool)checkBox25.IsChecked;
        }

        private void checkBox24_Checked(object sender, RoutedEventArgs e)
        {
            tester.valid[4, 5] = (bool)checkBox24.IsChecked;
        }
        #endregion
        #region set up
        private void freeDeliverNumTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.Name = FirstNameTextBox.Text;
        }

        private void branchPhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.familyName = TesterLastNameTextBox.Text;
        }

        private void IDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tester.id = Convert.ToInt32(IDTextBox.Text);
        }

        private void BirthdayTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(BirthdayTextBox.Text.Length==10)
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
        #endregion
    }
}