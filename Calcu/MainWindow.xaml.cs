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

namespace Calcu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ButtonClick(object sender, RoutedEventArgs e)
        {

            try
            {
                Button button = (Button)sender;

                string value = (string)button.Content;

                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperator(value);
                }

                else if (value=="CE")
                {
                    Screen.Clear();
                }
                else if (value == "C")
                {
                    Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
                }
                else if (value == "=")
                {
                    HandleEquals(Screen.Text);
                }
                else if (value == ",")
                {
                    Screen.Text += ".";
                }


            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }

        }

        private bool IsNumber(string num)
        {
            return double.TryParse(num, out _);
        }


        private void HandleNumbers(string value)
        {
            if (String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;

            } else
            {
                Screen.Text += value;
            }
            
        }

        private bool IsOperator (string possibleOperative)
        {
            //if (possibleOperative == "+" || possibleOperative == "-" || possibleOperative == "*" || possibleOperative == "/")
            //{
            //    return true;
            //} else
            //{
            //    return false;
            //}


            return possibleOperative == "+" || possibleOperative == "-" || possibleOperative == "*" || possibleOperative == "/";
        }

        private void HandleOperator (string value)
        {
            if (!String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text += value;
            }
        }

        //Validar que no se repita el signo

        //contains


        private void HandleEquals (string screenConten)
        {
            string op = FindOperator(screenConten);

            if (!String.IsNullOrEmpty(op))
            {
                switch (op)
                {
                    case "+":
                        Screen.Text = sum();

                        break;

                    case "-":
                        Screen.Text = res();
                        break;

                    case "*":
                        Screen.Text= mult();
                        break;

                    case "/":
                        Screen.Text = divi();
                        break;

                    default: 
                        break;
                }
            }
        }

        private string FindOperator (string screenContent)
        {
            foreach (var c in screenContent) {
                if (IsOperator(c.ToString())) {

                return c.ToString();
            }
            }
            return "No hay nada";
        }

    private string sum()
    {
        string[] number = Screen.Text.Split('+');
            double.TryParse(number[0], out double n1);

            double.TryParse(number[1], out double n2);

            return Math.Round(n1 + n2, 12).ToString();
    }
        private string res()
        {
            string[] number = Screen.Text.Split('-');
            double.TryParse(number[0], out double n1);

            double.TryParse(number[1], out double n2);

            return Math.Round(n1 - n2, 12).ToString();
        }
        private string mult()
        {
            string[] number = Screen.Text.Split('*');
            double.TryParse(number[0], out double n1);

            double.TryParse(number[1], out double n2);

            return Math.Round(n1 * n2, 12).ToString();
        }
        private string divi()
        {
            string[] number = Screen.Text.Split('/');
            double.TryParse(number[0], out double n1);

            double.TryParse(number[1], out double n2);

            return Math.Round(n1 / n2, 12).ToString();
            //KDFGNDSKFG
        }

        //JOLA DEMONIO
        //AMOALADETERAPIA

    }
    
}
