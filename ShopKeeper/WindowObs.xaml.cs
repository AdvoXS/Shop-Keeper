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

namespace ShopKeeper
{
    /// <summary>
    /// Логика взаимодействия для WindowObs.xaml
    /// </summary>
    public partial class WindowObs : Window
    {
        obsCalcClass calc;
        Window parentForm;
        public WindowObs(Window parentWindow)
        {
            InitializeComponent();
            parentForm = parentWindow;
        }

        private void PreviousButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (coresTextBox.Text != "" && taktTextBox.Text != "" && priceTextBox.Text!="")
            {
                calc = new obsCalcClass(float.Parse(coresTextBox.Text), float.Parse(taktTextBox.Text), float.Parse(priceTextBox.Text));
                WindowShowProduct shower = new WindowShowProduct(calc.indexFounded,this);
                Hide();
                shower.Show();
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            parentForm.IsEnabled = true;
            parentForm.Show();
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parentForm.IsEnabled = true;
            parentForm.Show();
        }
    }
}
