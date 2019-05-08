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
    /// Логика взаимодействия для WindowLowBorders.xaml
    /// </summary>
    public partial class WindowLowBorders : Window
    {
        HelperWindow windowSelect;
        public WindowLowBorders(HelperWindow windowParent)
        {
            InitializeComponent();
            windowSelect = windowParent;
            //searched = false;
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            
            windowSelect.IsEnabled = true;
            windowSelect.Show();
            Close();

        }

        private void WinLowBorders_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            windowSelect.IsEnabled = true;
            windowSelect.Show();
        }
        //bool searched;
        lowBorderCalc tmpCalc;
        private void PreviousButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if(coresTextBox1.Text!="" && coresTextBox2.Text!=""&& frenqTextBox1.Text!="" 
                && frenqTextBox2.Text != "" && priceTextBox1.Text!="" && priceTextBox2.Text!="")
            {
                lowBorderCalc calc = new lowBorderCalc(int.Parse(coresTextBox1.Text), int.Parse(coresTextBox2.Text),
                    int.Parse(frenqTextBox1.Text), int.Parse(frenqTextBox2.Text), int.Parse(priceTextBox1.Text),
                    int.Parse(priceTextBox2.Text));
                foundedLabel.Opacity = 100;

                if (calc.countFoundedCPUs == 1)
                {
                    foundedLabel.Content = "Найден подходящий товар, \nчтобы увидеть его - \nнажмите кнопку продолжить, \nповторно!";
                    foundedLabel.Background = Brushes.Green;
                    fountLabel.Visibility = Visibility.Hidden;
                    WindowShowProduct shower = new WindowShowProduct(calc.indexFoundedCPUs[0],this);
                    shower.Show();
                    Hide();
                }
                else if (calc.countFoundedCPUs <= 0)
                {
                    foundedLabel.Content = "Не найдено подходящих \nтоваров. \nРасширьте границы!";
                    fountLabel.Visibility = Visibility.Hidden;
                    foundedLabel.Background = Brushes.OrangeRed;
                }
                else
                {
                    foundedLabel.Content = "Найдено несколько("+calc.countFoundedCPUs+") \nсоответствующих критериям \nтоваров. \nCузьте границы!";
                    fountLabel.Visibility = Visibility.Visible;
                    tmpCalc = calc;
                    foundedLabel.Background = Brushes.Orange;
                }
            }
        }

        private void FoundedLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            foundedLabel.Opacity = 0;
        }

        private void CoresCheck_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)CoresCheck.IsChecked)
            {
                coresTextBox1.IsEnabled = true;
                coresTextBox2.IsEnabled = true;
            }
            else if ((bool)!CoresCheck.IsChecked)
            {
                coresTextBox1.IsEnabled = false;
                coresTextBox2.IsEnabled = false;
                coresTextBox1.Text = "1";
                coresTextBox2.Text = "32";
            }
        }

        private void CoresCheck_Copy_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)CoresCheck_Copy.IsChecked)
            {
                frenqTextBox1.IsEnabled = true;
                frenqTextBox2.IsEnabled = true;
            }
            else if ((bool)!CoresCheck_Copy.IsChecked)
            {
                frenqTextBox1.IsEnabled = false;
                frenqTextBox2.IsEnabled = false;
                frenqTextBox1.Text = "0";
                frenqTextBox2.Text = "4000";
            }
        }

        private void CoresCheck_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)CoresCheck_Copy1.IsChecked)
            {
                priceTextBox1.IsEnabled = true;
                priceTextBox2.IsEnabled = true;
            }
            else if ((bool)!CoresCheck_Copy1.IsChecked)
            {
                priceTextBox1.IsEnabled = false;
                priceTextBox2.IsEnabled = false;
                priceTextBox1.Text = "0";
                priceTextBox2.Text = "30000";
            }
        }
        MainWindow main;
        private void FountLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
           main =new MainWindow(true);
                main.Show();
                main.Show_Cpus(Convert.ToInt32(coresTextBox1.Text), Convert.ToInt32(coresTextBox2.Text),
                    Convert.ToInt32(frenqTextBox1.Text), Convert.ToInt32(frenqTextBox2.Text),
                     Convert.ToInt32(priceTextBox1.Text), Convert.ToInt32(priceTextBox2.Text),tmpCalc.countFoundedCPUs);
            
        }
    }
}
