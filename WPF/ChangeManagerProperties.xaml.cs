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
    /// Interaction logic for ChangeManagerProperties.xaml
    /// </summary>
    public partial class ChangeManagerProperties : Window
    {
        
        public ChangeManagerProperties()
        {
            InitializeComponent();
            textBox2.Text = Convert.ToString(BE.Configuration.minimum_NumberOfLessos);
            textBox1.Text = Convert.ToString(BE.Configuration.maximum_TesterAge);
            textBox.Text = Convert.ToString(BE.Configuration.minimum_TraineeAge);
            textBox3.Text = Convert.ToString(BE.Configuration.Range);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BE.Configuration.minimum_NumberOfLessos = Convert.ToInt32(textBox2.Text);
            BE.Configuration.maximum_TesterAge = Convert.ToInt32(textBox1.Text);
            BE.Configuration.minimum_TraineeAge = Convert.ToInt32(textBox.Text);
            BE.Configuration.Range = Convert.ToInt32(textBox3.Text);
            MessageBox.Show("Your changes was recived  " );
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
