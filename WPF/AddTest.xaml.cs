using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for AddTest.xaml
    /// </summary>
    public partial class AddTest : Window
    {
        
        BE.Test test;
        BL.IBL bl;
        public AddTest()
        {
            InitializeComponent();
            
            test = new BE.Test();            
            bl = BL.FactoryBL.getBL();
            comboBox.ItemsSource = from item in bl.getAllTester()
                                   select item.id;
            comboBox1.ItemsSource = from item in bl.getAllTrainee()
                                   select item.id;

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addTest(test);
                MessageBox.Show("the Test \"" + test.TestNumber + "\" added to the list", "");
                test = new BE.Test();
                this.gridAddTester.DataContext = test;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            test = bl.getAllTest(c => c.TesterId  == test.TesterId).FirstOrDefault();
            this.DataContext = test;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (bl.eligible(test.studentId ))
            {
                this.Content = "yes";
                test.succeeded = true;
            }
            else
            {
                this.Content = "no";
                test.succeeded = false;
            }
            
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            test = bl.getAllTest(c => c.studentId == test.studentId).FirstOrDefault();
            this.DataContext = test;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (bl.eligible(test.studentId))
            {
                textBox1.Text = "yes";
                test.succeeded = true;
            }
            else
            {
                textBox1.Text = "no";
                test.succeeded = false;
            }
        }

        private void branchPhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.TestNumber = Convert.ToInt32(branchPhoneTextBox.Text);
        }

        private void branchResponsNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.currentDate = Convert.ToDateTime(branchResponsNameTextBox.Text);
        }

        private void TestTimeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.testDate = Convert.ToDateTime(TestTimeTextBox.Text);
        }

        private void branchNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.currentDate = Convert.ToDateTime(branchNumberTextBox.Text);
        }

        private void DestinationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.address = Convert.ToString(DestinationTextBox.Text);
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.mirror = Convert.ToBoolean(textBox4.Text);
        }

        private void LightsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.signal = Convert.ToBoolean(LightsTextBox.Text);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.keepingDistance= Convert.ToBoolean(textBox.Text);
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.Parking = Convert.ToBoolean(textBox3.Text);
        }

        private void textBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.StopCrossWalk = Convert.ToBoolean(textBox6.Text);
        }
      
        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.pouncing = Convert.ToBoolean(textBox5.Text);
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.keepingDistance = Convert.ToBoolean(textBox.Text);
        }
    }

        
    }

