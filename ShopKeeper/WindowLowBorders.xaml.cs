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
    }
}
