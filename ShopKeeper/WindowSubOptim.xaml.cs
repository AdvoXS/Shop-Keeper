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
    /// Логика взаимодействия для WindowSubOptim.xaml
    /// </summary>
    public partial class WindowSubOptim : Window
    {
        Window parentForm;
        public WindowSubOptim(Window parentWindow)
        {
            InitializeComponent();
            parentForm = parentWindow;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parentForm.IsEnabled = true;
            parentForm.Show();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            parentForm.IsEnabled = true;
            parentForm.Show();
            Close();
        }

        private void PreviousButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cmb = mainKriteriiBox.SelectedValue as ComboBoxItem;
            SubOptimCalcClass calc = null;
            if (Convert.ToString(cmb.Content)=="Количество ядер"){
                calc = new SubOptimCalcClass(Convert.ToString(cmb.Content), int.Parse(taktTextBox1.Text),
                    int.Parse(taktTextBox2.Text), int.Parse(priceTextBox1.Text), int.Parse(priceTextBox2.Text));
            }
            if (Convert.ToString(cmb.Content) == "Тактовая частота")
            {
                calc = new SubOptimCalcClass(Convert.ToString(cmb.Content), int.Parse(coresTextBox1.Text),
                    int.Parse(coresTextBox2.Text), int.Parse(priceTextBox1.Text), int.Parse(priceTextBox2.Text));
            }
            if (Convert.ToString(cmb.Content) == "Цена")
            {
                calc = new SubOptimCalcClass(Convert.ToString(cmb.Content), int.Parse(coresTextBox1.Text),
                    int.Parse(coresTextBox2.Text), int.Parse(taktTextBox1.Text), int.Parse(taktTextBox2.Text));
            }
            if (calc.oneCPU)
            {
                foundedLabel.Content = "Найден подходящий товар, \nчтобы увидеть его - \nнажмите кнопку продолжить, \nповторно!";
                foundedLabel.Background = Brushes.Green;
                foundedLabel.Opacity = 100;
                WindowShowProduct shower = new WindowShowProduct(calc.foundedIndexCpus[0], this);
                shower.Show();
                Hide();
            }
            else if(calc.countFounded>1)
            {
                foundedLabel.Content = "Найдено несколько(" + calc.countFounded + ") \nсоответствующих критериям \nтоваров. \nCузьте границы!";
                foundedLabel.Background = Brushes.Orange;
                foundedLabel.Opacity = 100;
            }
            else if (calc.countFounded == 0)
            {
                foundedLabel.Opacity = 100;
                foundedLabel.Content = "Не найдено подходящих \nтоваров. \nРасширьте границы!";
                foundedLabel.Background = Brushes.OrangeRed;
            }
        }

        private void FoundedLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ComboBoxItem cmb = mainKriteriiBox.SelectedValue as ComboBoxItem;
            if (Convert.ToString(cmb.Content) != "")
            {
                string s = Convert.ToString(Convert.ToString(cmb.Content));
                switch (s)
                {
                    case "Количество ядер":
                        taktDo.IsEnabled = true;
                        taktOt.IsEnabled = true;
                        taktTextBox1.IsEnabled = true;
                        taktTextBox2.IsEnabled = true;
                        coresTextBox1.IsEnabled = false;
                        coresCheck.IsEnabled = false;
                        
                        coresCheck_Copy.IsEnabled = true;
                        coresCheck_Copy.IsChecked = true;
                        coresCheck_Copy1.IsChecked = true;
                        coresCheck_Copy1.IsEnabled = true;
                        coresTextBox1.Text = "1";
                        coresTextBox2.Text = "32";
                        coresTextBox2.IsEnabled = false;
                        taktLabel.IsEnabled = true;
                        priceTextBox1.IsEnabled = true;
                        priceTextBox2.IsEnabled = true;
                        PreviousButton_Copy.IsEnabled = true;
                        coresMainNowLabel.Opacity = 100;
                        taktMainNowLabel.Opacity = 0;
                        priceNowMainLabel.Opacity = 0;
                        break;
                    case "Тактовая частота":
                        coresTextBox1.IsEnabled = true;
                        coresTextBox2.IsEnabled = true;
                        taktTextBox1.IsEnabled = false;
                        taktTextBox2.IsEnabled = false;
                        coresCheck_Copy.IsEnabled = false;

                        coresCheck_Copy1.IsEnabled = true;
                        coresCheck_Copy1.IsChecked = true;
                        coresCheck.IsChecked = true;
                        coresCheck.IsEnabled = true;
                        taktTextBox1.Text = "0";
                        taktTextBox2.Text = "4000";
                        priceTextBox1.IsEnabled = true;
                        priceTextBox2.IsEnabled = true;
                        PreviousButton_Copy.IsEnabled = true;
                        coresMainNowLabel.Opacity = 0;
                        taktMainNowLabel.Opacity = 100;
                        priceNowMainLabel.Opacity = 0;
                        break;
                    case "Цена":
                        coresTextBox1.IsEnabled = true;
                        coresTextBox2.IsEnabled = true;
                        priceTextBox1.IsEnabled = false;
                        priceTextBox2.IsEnabled = false;
                        priceTextBox1.Text = "0";
                        priceTextBox2.Text = "30000";
                        coresCheck_Copy1.IsEnabled = false;
                        coresCheck.IsEnabled = true;
                        coresCheck.IsChecked = true;
                        coresCheck_Copy.IsChecked = true;
                        coresCheck_Copy.IsEnabled = true;
                        coresMainNowLabel.Opacity = 0;
                        taktMainNowLabel.Opacity = 0;
                        priceNowMainLabel.Opacity = 100;
                        taktTextBox1.IsEnabled = true;
                        taktTextBox2.IsEnabled = true;
                        PreviousButton_Copy.IsEnabled = true;
                        break;
                    default:

                        break;
                }
            }
        }

        private void CoresCheck_Click(object sender, RoutedEventArgs e)
        {
            if((bool)coresCheck.IsChecked)
            {
                coresTextBox1.IsEnabled = true;
                coresTextBox2.IsEnabled = true;
            }
            else if ((bool)!coresCheck.IsChecked)
            {
                coresTextBox1.IsEnabled = false;
                coresTextBox2.IsEnabled = false;
                coresTextBox1.Text = "1";
                coresTextBox2.Text = "32";
            }
        }

        private void CoresCheck_Copy_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)coresCheck_Copy.IsChecked)
            {
                taktTextBox1.IsEnabled = true;
                taktTextBox2.IsEnabled = true;
            }
            else if ((bool)!coresCheck_Copy.IsChecked)
            {
                taktTextBox1.IsEnabled = false;
                taktTextBox2.IsEnabled = false;
                taktTextBox1.Text = "0";
                taktTextBox2.Text = "4000";
            }
        }

        private void CoresCheck_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)coresCheck_Copy1.IsChecked)
            {
                priceTextBox1.IsEnabled = true;
                priceTextBox2.IsEnabled = true;
            }
            else if ((bool)!coresCheck_Copy1.IsChecked)
            {
                priceTextBox1.IsEnabled = false;
                priceTextBox2.IsEnabled = false;
                priceTextBox1.Text = "0";
                priceTextBox2.Text = "30000";
            }
        }
    }
}
