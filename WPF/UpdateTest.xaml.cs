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
    /// Interaction logic for UpdateTest.xaml
    /// </summary>
    public partial class UpdateTest : Window
    {
        BE.Test test;
        BL.IBL bl;        
        public UpdateTest()
        {
            InitializeComponent();
            bl = BL.FactoryBL.getBL();
            test = new BE.Test();
            comboBox.ItemsSource = from item in bl.getAllTest()
                                   select item.TestNumber;
            #region Init With The Former value
            textBox9.Text = Convert.ToString(test.studentId);
            textBox10.Text = Convert.ToString(test.TesterId);
            DestinationTextBox.Text = Convert.ToString(test.address);
            TestDateTextBox.Text = Convert.ToString(test.testDate);
            DestinationTextBox.Text = Convert.ToString(test.address);
            LightsTextBox.Text = Convert.ToString(test.signal);
            textBox4.Text = Convert.ToString(test.keepingDistance);
            textBox3.Text = Convert.ToString(test.Parking);
            textBox.Text = Convert.ToString(test.keepingDistance);
            textBox6.Text = Convert.ToString(test.StopCrossWalk);
            textBox5.Text = Convert.ToString(test.pouncing);
            #endregion
        }
    

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                bl.updateTest(test);
                test = new BE.Test();
                MessageBox.Show("the Test " + test.TestNumber + " update ", "");
                this.DataContext = test;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            test = bl.getAllTest(b => b.TestNumber == test.TestNumber).FirstOrDefault();
            this.DataContext = test;
        }
        #region setUp
             
     
        private void TestDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.testDate = Convert.ToDateTime(TestDateTextBox.Text);
        }

        private void branchNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.address = Convert.ToString(DestinationTextBox.Text);
        }
        

        private void textBox9_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.studentId = Convert.ToInt32(textBox9.Text);
        }


        private void branchAddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.signal = Convert.ToBoolean(LightsTextBox.Text);
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.keepingDistance = Convert.ToBoolean(textBox4.Text);
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.Parking = Convert.ToBoolean(textBox3.Text);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.keepingDistance = Convert.ToBoolean(textBox.Text);
        }

        private void textBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.StopCrossWalk = Convert.ToBoolean(textBox6.Text);
        }

        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            test.pouncing = Convert.ToBoolean(textBox5.Text);
        }

        #endregion
        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
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
    }




   

   
}

