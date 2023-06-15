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

            }
            Screen.Text += value;
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

        //PUTOSECH

    }
    
}
