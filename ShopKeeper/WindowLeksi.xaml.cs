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
    /// Логика взаимодействия для WindowLeksi.xaml
    /// </summary>
    public partial class WindowLeksi : Window
    {
        Window parentForm;
        Dictionary<int, Grid> gridStatus;
        public WindowLeksi(Window parentWindow)
        {
            InitializeComponent();
            parentForm = parentWindow;
            gridStatus = new Dictionary<int, Grid>();
            gridStatus.Add(1, multiGrid);
            gridStatus.Add(2, speedGrid);
            gridStatus.Add(3, gameGrid);

            multiBtnDown.Click += buttonDown_Click;
            speedBtnDown.Click+= buttonDown_Click;
            gameBtnDown.Click+= buttonDown_Click;

            multiBtnUp.Click += buttonUp_Click;
            speedBtnUp.Click += buttonUp_Click;
            gameBtnUp.Click += buttonUp_Click;
        }
        private void buttonDown_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            for(int i = 0; i < gridStatus.Count; i++)
            {
                if (gridStatus.ElementAt(i).Value == but.Parent)
                {
                    if (gridStatus.ElementAt(i).Key != gridStatus.Keys.Max())
                    {


                        Grid n = gridStatus.ElementAt(i).Value;
                        gridStatus[gridStatus.ElementAt(i).Key] = gridStatus.ElementAt(i + 1).Value;
                        gridStatus[gridStatus.ElementAt(i+1).Key] = n;
                        mainStackPanel.Children.Clear();
                        for(int j=0;j < gridStatus.Count; j++)
                        {
                            mainStackPanel.Children.Add(gridStatus.ElementAt(j).Value);
                        }
                    }
                    break;
                }
            }
        }
        private void buttonUp_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            for (int i = 0; i < gridStatus.Count; i++)
            {
                if (gridStatus.ElementAt(i).Value == but.Parent)
                {
                    if (gridStatus.ElementAt(i).Key != gridStatus.Keys.Min())
                    {


                        Grid n = gridStatus.ElementAt(i-1).Value;
                        gridStatus[gridStatus.ElementAt(i-1).Key] = gridStatus.ElementAt(i).Value;
                        gridStatus[gridStatus.ElementAt(i).Key] = n;
                        mainStackPanel.Children.Clear();
                        for (int j = 0; j < gridStatus.Count; j++)
                        {
                            mainStackPanel.Children.Add(gridStatus.ElementAt(j).Value);
                        }
                    }
                    break;
                }
            }
        }
        private void WinLeksi_Closed(object sender, EventArgs e)
        {

            parentForm.IsEnabled = true;
            parentForm.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            leksiCalcClass calc = new leksiCalcClass(gridStatus);
            calc.Calc();
            if (calc.countFounded == 1)
            {
                WindowShowProduct shower = new WindowShowProduct(calc.indexFounded, this);
                shower.Show();
                Hide();
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            parentForm.IsEnabled = true;
            parentForm.Show();
            Close();
        }
    }
}
