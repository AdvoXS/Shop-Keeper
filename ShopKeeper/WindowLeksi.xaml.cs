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
        public WindowLeksi(Window parentWindow)
        {
            InitializeComponent();
            parentForm = parentWindow;
        }

        private void WinLeksi_Closed(object sender, EventArgs e)
        {

            parentForm.IsEnabled = true;
            parentForm.Show();
        }
    }
}
