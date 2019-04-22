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
            searched = false;
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
        bool searched;
        private void PreviousButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if(coresTextBox1.Text!="" && coresTextBox2.Text!=""&& frenqTextBox1.Text!="" 
                && frenqTextBox2.Text != "" && priceTextBox1.Text!="" && priceTextBox2.Text!="")
            {
                bool isChBox1 = true, isChBox2;
                isChBox1 = (bool)checkSO.IsChecked ? true : false;
                isChBox2 = (bool)checkVideo.IsChecked ? true : false;
                lowBorderCalc calc = new lowBorderCalc(int.Parse(coresTextBox1.Text), int.Parse(coresTextBox2.Text),
                    int.Parse(frenqTextBox1.Text), int.Parse(frenqTextBox2.Text), int.Parse(priceTextBox1.Text),
                    int.Parse(priceTextBox2.Text),isChBox2,isChBox1);
                foundedLabel.Opacity = 100;

                if (calc.countFoundedCPUs == 1)
                {
                    foundedLabel.Content = "Найден подходящий товар, \nчтобы увидеть его - \nнажмите кнопку продолжить, \nповторно!";
                    foundedLabel.Background = Brushes.Green;
                    WindowShowProduct shower = new WindowShowProduct(calc.indexFoundedCPUs[0],this);
                    shower.Show();
                    Hide();
                }
                else if (calc.countFoundedCPUs <= 0)
                {
                    foundedLabel.Content = "Не найдено подходящих \nтоваров. \nРасширьте границы!";
                    foundedLabel.Background = Brushes.OrangeRed;
                }
                else
                {
                    foundedLabel.Content = "Найдено несколько("+calc.countFoundedCPUs+") \nсоответствующих критериям \nтоваров. \nCузьте границы!";
                    foundedLabel.Background = Brushes.Orange;
                }
            }
        }

        private void FoundedLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            foundedLabel.Opacity = 0;
        }
    }
}
