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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double? num1, num2;
        private string num1tmp ="", num2tmp="";
        private string operator_tag ="";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void update_display()
        {
            if(operator_tag == "")
            {
                displayField.Text = num1tmp;
            } else
            {
                displayField.Text = num2tmp;
            }
        }

        private void under_construction(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Out of Order!");
        }
        private void term_Click(object sender, RoutedEventArgs e)
        {
            string c = ((Button)sender).Content.ToString();
            if (operator_tag == "")
            {
                num1tmp += c;
            }
            else
            {
                num2tmp += c;
            }
            displayField.Text += c;
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            if(num1tmp == "")
            {
                MessageBox.Show("You need to enter the first term!");
                return;
            } else
            {
                if(num2tmp == "")
                {
                    num1 = Convert.ToDouble(num1tmp);
                    operator_tag = ((Button)sender).Content.ToString();
                    displayField.Text += operator_tag;
                } else
                {
                    MessageBox.Show("Only two operands are supported currently!");
                }
            }
        }

        private void InputEquals_Click(object sender, RoutedEventArgs e)
        {
            if(num1 == null)
            {
                MessageBox.Show("You haven't entered the first term yet!");
            } else if(num2tmp == "")
            {
                MessageBox.Show("You haven't entered the second term yet!");
            } else
            {
                num2 = Convert.ToDouble(num2tmp);
                switch (operator_tag)
                {
                    case "/": ans.Text = (num1 / num2).ToString(); break;
                    case "*": ans.Text = (num1 * num2).ToString(); break;
                    case "+": ans.Text = (num1 + num2).ToString(); break;
                    case "-": ans.Text = (num1 - num2).ToString(); break;
                }
                num1 = null; num2 = null; num1tmp = ""; num2tmp = ""; operator_tag = ""; displayField.Text = "";
            }
        }

        private void InputDel_Click(object sender, RoutedEventArgs e)
        {
            if(operator_tag == "")
            {
                if(num1tmp != "")
                {
                    num1tmp = num1tmp.Remove(num1tmp.Length - 1);
                    displayField.Text = displayField.Text.Remove(displayField.Text.Length - 1);
                }
            } else
            {
                if(num2tmp != "")
                {
                    num2tmp = num2tmp.Remove(num2tmp.Length - 1);
                    displayField.Text = displayField.Text.Remove(displayField.Text.Length - 1);
                }
            }
        }
    }
}
