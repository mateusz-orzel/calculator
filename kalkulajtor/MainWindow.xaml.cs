using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace kalkulajtor
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Double first = 0;
        Double second = 0;
        char a = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        

        bool p = false; // blokowanie podwójnych działań
        bool q = false; // automatyczne równa się
        Double result = 0;
        char op;
        public MainWindow()
        {
            InitializeComponent();
            this.dot_button.Content = a;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (TxtResult.Text.Length < 10)
            {
                Button btn = (Button)sender;
               
                TxtResult.Text += btn.Content.ToString();
                second = Double.Parse(TxtResult.Text);
                p = true;
                if (TxtResult.Text.Length > 1)
                {
                    if (TxtResult.Text[0] == '0' && TxtResult.Text[1] != a)
                        TxtResult.Text = TxtResult.Text.Remove(0, 1);
                }
            }
            else
            {
                MessageBox.Show("Przekroczono limit");
            }
        }

        private void mul_button_Click(object sender, RoutedEventArgs e)
        {
            if (q)
            {
                equ_button_Click(sender, e);
                q = false;
            }
            if (p)
            {
                first = Double.Parse(TxtResult.Text);
                op = '*';
                TxtResult.Clear();
                p = false;
                q = true;
            }
          

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            if (q)
            {
                equ_button_Click(sender, e);
                q = false;
            }
            if (p)
            {
                first = Double.Parse(TxtResult.Text);
                op = '+';
                TxtResult.Clear();
                p = false;
                q = true;
            }
            
        }

        private void sub_button_Click(object sender, RoutedEventArgs e)
        {
            if (q)
            {
                equ_button_Click(sender, e);
                q = false;
            }
            if (p)
            {
                first = Double.Parse(TxtResult.Text);
                op = '-';
                TxtResult.Clear();
                p = false;
                q = true;
            }
            
        }

        private void div_button_Click(object sender, RoutedEventArgs e)
        {
            if (q)
            {
                equ_button_Click(sender, e);
                q = false;
            }
            if (p)
            {
                first = Double.Parse(TxtResult.Text);
                op = '/';
                TxtResult.Clear();
                p = false;
                q = true;
            }

        }
        private void equ_button_Click(object sender, RoutedEventArgs e)
        {

            if (p)
            {
                second = Double.Parse(TxtResult.Text);

                if (op == '*')
                {
                    result = first * second;
                }
                else if (op == '+')
                {
                    result = first + second;
                }
                else if (op == '-')
                {
                    result = first - second;
                }
                else if (op == '/')
                {
                    if(second != 0)
                    result = first / second;
                    else
                    MessageBox.Show("Nie można dzielić przez 0!");

                }
                if (TxtResult.Text == "0")
                {
                    TxtResult.Clear();
                }
                TxtResult.Text = result.ToString();
                p = true;
                q = false;
            }
        

        }
        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Clear();
            result = 0;
            first = 0;
            second = 0;
            p = false;
        }
        private void dot_button_Click(object sender, RoutedEventArgs e)
        {
                
                for(int i = 0; i< TxtResult.Text.Length; i++)
                {
                if(TxtResult.Text[i] == a)
                {
                    return;
                }
                }
                if (TxtResult.Text.Length < 10)
                {
                    TxtResult.Text = TxtResult.Text + a;
                   
                }
                else
                {
                    MessageBox.Show("Przekroczono limit");
                }

          
        }

        private void sign_button_Click(object sender, RoutedEventArgs e)
        {


            if (p == true)
            {
                
                
                    if (TxtResult.Text[0] != '-' && TxtResult.Text != "0")
                    {
                        TxtResult.Text = "-" + TxtResult.Text;
                       



                    }
                    else if (TxtResult.Text[0] == '-' && TxtResult.Text != "0")
                    {
                        TxtResult.Text = TxtResult.Text.Remove(0, 1);
                       

                    }
                        
            }
            
        }
    }
       
}
