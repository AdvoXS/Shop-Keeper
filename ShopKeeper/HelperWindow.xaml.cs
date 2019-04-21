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
using System.Windows.Media.Animation;
namespace ShopKeeper
{
    /// <summary>
    /// Логика взаимодействия для HelperWindow.xaml
    /// </summary>
    public partial class HelperWindow : Window
    {
        public HelperWindow()
        {
            InitializeComponent();
            initLabelStartAnimation();
        }







        //Animations methods

            //Start window
        public void initLabelStartAnimation()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = this.Opacity+25;
            da.Duration = TimeSpan.FromSeconds(5);
            welcomeLabel.BeginAnimation(Label.OpacityProperty, da);
            startLabel1.BeginAnimation(Label.OpacityProperty, da);
            initButtonStartAnimation();
        }
        public void initButtonStartAnimation()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = this.Opacity + 25;
            da.Duration = TimeSpan.FromSeconds(5);
            buttonNext.BeginAnimation(Button.OpacityProperty, da);
        }
        private void startWindowsNexted()
        {
            //Передвижение стартового экрана(закрытие)
            ThicknessAnimation da = new ThicknessAnimation();
            ThicknessAnimation da1 = new ThicknessAnimation();
            da.From = welcomeLabel.Margin;
            da.To =  new Thickness(welcomeLabel.Margin.Left+1250, welcomeLabel.Margin.Top, 0, 0);
            da.Duration = TimeSpan.FromSeconds(1);
            da1.From = startLabel1.Margin;
            da1.To = new Thickness(startLabel1.Margin.Left + 1250, startLabel1.Margin.Top, 0, 0);
            da1.Duration = TimeSpan.FromSeconds(1);
            welcomeLabel.BeginAnimation(Label.MarginProperty, da);
            startLabel1.BeginAnimation(Label.MarginProperty, da1);

            ThicknessAnimation da2 = new ThicknessAnimation();
            da2.From = buttonNext.Margin;
            da2.To = new Thickness(buttonNext.Margin.Left + 450, buttonNext.Margin.Top, 0, 0);
            da2.Duration = TimeSpan.FromSeconds(1);
            buttonNext.BeginAnimation(Button.MarginProperty, da2);
        }
            //Select helper window
        //private void

        //Events methods
        public void Label_Initialized(object sender, EventArgs e)
        {

        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            startWindowsNexted();
            welcomeLabel.IsEnabled = false;
            startLabel1.IsEnabled = false;
        }
    }
}
