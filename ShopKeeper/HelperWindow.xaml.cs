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
        Image subOptimisationImage;
        Label selectWindowLabelSelect;
        Label lowBorderName;
        Label lowBorderDescription;
        Label subOptimisationDescription;
        Button selectWindowNextButton;



        public HelperWindow()
        {
            InitializeComponent();
            initElements();
            initLabelStartAnimation();
        }
        private void initElements()
        {
            lowBorderImage = new Image();
            lowBorderImage.Margin = new Thickness(Width/20,Height/5,0,0);
            lowBorderImage.Opacity = 0;
            lowBorderImage.HorizontalAlignment = HorizontalAlignment.Left;
            lowBorderImage.VerticalAlignment = VerticalAlignment.Top;
            lowBorderImage.Width = 150;
            lowBorderImage.Height = 150;
            lowBorderImage.Cursor = Cursors.Hand;
            lowBorderImage.Source = new BitmapImage(new Uri("helpersImages/LowBroderImage2.png", UriKind.Relative));
            lowBorderImage.MouseEnter += lowBorderImage_MouseOn;
            lowBorderImage.MouseLeave += lowBorderImage_MouseOut;
            mainCanvas.Children.Add(lowBorderImage);
            lowBorderImage.Visibility = Visibility.Hidden;

            subOptimisationImage = new Image();
            subOptimisationImage.Margin = new Thickness(Width / 3, Height / 5, 0, 0);
            subOptimisationImage.Opacity = 0;
            subOptimisationImage.HorizontalAlignment = HorizontalAlignment.Left;
            subOptimisationImage.VerticalAlignment = VerticalAlignment.Top;
            subOptimisationImage.Width = 150;
            subOptimisationImage.Height = 150;
            subOptimisationImage.Cursor = Cursors.Hand;
            subOptimisationImage.Source = new BitmapImage(new Uri("helpersImages/suboptimisationImage.png", UriKind.Relative));
            mainCanvas.Children.Add(subOptimisationImage);

            selectWindowLabelSelect = new Label();
            selectWindowLabelSelect.Margin = new Thickness(this.Width/3.5,this.Height/16,0,0);
            selectWindowLabelSelect.Style = welcomeLabel.Style;
            selectWindowLabelSelect.FontFamily = welcomeLabel.FontFamily;
            selectWindowLabelSelect.FontSize = welcomeLabel.FontSize;
            selectWindowLabelSelect.FontStyle = welcomeLabel.FontStyle;
            selectWindowLabelSelect.Content = "Выберите алгоритм подбора";
            selectWindowLabelSelect.Foreground = welcomeLabel.Foreground;
            selectWindowLabelSelect.FontWeight = welcomeLabel.FontWeight;
            selectWindowLabelSelect.Opacity = 0;
            mainCanvas.Children.Add(selectWindowLabelSelect);


            lowBorderName = new Label();
            lowBorderName.Margin = new Thickness(Width / 45, Height / 1.45, 0, 0);
            lowBorderName.Style = welcomeLabel.Style;
            lowBorderName.FontFamily = welcomeLabel.FontFamily;
            lowBorderName.FontSize = welcomeLabel.FontSize -12;
            lowBorderName.FontStyle = welcomeLabel.FontStyle;
            lowBorderName.Content = "Метод указания нижних границ";
            lowBorderName.Foreground = welcomeLabel.Foreground;
            lowBorderName.FontWeight = welcomeLabel.FontWeight;
            lowBorderName.Opacity = 0;
            mainCanvas.Children.Add(lowBorderName);

            lowBorderDescription = new Label();
            lowBorderDescription.Margin = new Thickness(Width / 25, Height / 1.45, 0, 0);
            lowBorderDescription.Style = welcomeLabel.Style;
            lowBorderDescription.FontFamily = welcomeLabel.FontFamily;
            lowBorderDescription.FontSize = welcomeLabel.FontSize - 14;
            lowBorderDescription.FontStyle = welcomeLabel.FontStyle;
            lowBorderDescription.Content = "Вам следует указать границы \nпараметров товара  вплоть до \nнахождения нужного.";
            lowBorderDescription.Foreground = welcomeLabel.Foreground;
            lowBorderDescription.Visibility = Visibility.Hidden;
            mainCanvas.Children.Add(lowBorderDescription);

            subOptimisationDescription = new Label();
            subOptimisationDescription.Margin = new Thickness(Width / 3.5, Height / 1.45, 0, 0);
            subOptimisationDescription.Style = welcomeLabel.Style;
            subOptimisationDescription.FontFamily = welcomeLabel.FontFamily;
            subOptimisationDescription.FontSize = welcomeLabel.FontSize - 14;
            subOptimisationDescription.FontStyle = welcomeLabel.FontStyle;
            subOptimisationDescription.Content = "Вам следует указать главный критерий\n и границы параметров товара \nвплоть до нахождения \nнужного.";
            subOptimisationDescription.Foreground = welcomeLabel.Foreground;
            subOptimisationDescription.Visibility = Visibility.Hidden;
            mainCanvas.Children.Add(subOptimisationDescription);
        }






        //Animations methods

            //Start window
        public void initLabelStartAnimation()
        {//появление надписей на старте
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = this.Opacity+25;
            da.Duration = TimeSpan.FromSeconds(5);
            welcomeLabel.BeginAnimation(Label.OpacityProperty, da);
            startLabel1.BeginAnimation(Label.OpacityProperty, da);
            initButtonStartAnimation();
        }
        public void initButtonStartAnimation()
        {//появление кнопки далее на старте
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
        private void selectWindowStartAnimation()
        { //появление элементов на экране выбора
            lowBorderImage.Visibility = Visibility.Visible;
            selectWindowNextButton.IsEnabled = true;
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = this.Opacity + 10;
            da.Duration = TimeSpan.FromSeconds(10);
            selectWindowLabelSelect.BeginAnimation(Label.OpacityProperty, da);

            da.From = 0;
            da.To = this.Opacity + 15;
            da.Duration = TimeSpan.FromSeconds(20);
            lowBorderImage.BeginAnimation(Image.OpacityProperty, da);

            da.From = 0;
            da.To = this.Opacity + 10;
            da.Duration = TimeSpan.FromSeconds(30);
            lowBorderName.BeginAnimation(Label.OpacityProperty, da);

            da.From = 0;
            da.To = this.Opacity + 15;
            da.Duration = TimeSpan.FromSeconds(20);
            subOptimisationImage.BeginAnimation(Image.OpacityProperty, da);
            

        }

        //Events methods
        public void Label_Initialized(object sender, EventArgs e)
        {

        }
        Image lowBorderImage;
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            startWindowsNexted();
            welcomeLabel.IsEnabled = false;
            startLabel1.IsEnabled = false;
            mainCanvas.IsEnabled = true;
            selectWindowStartAnimation();
        }
        private void lowBorderImage_MouseOn(object sender, RoutedEventArgs e)
        {
            lowBorderName.Opacity = 0;
            lowBorderName.Visibility = Visibility.Hidden;
            lowBorderDescription.Visibility = Visibility.Visible;
        }
        private void lowBorderImage_MouseOut(object sender, RoutedEventArgs e)
        {
            lowBorderName.Opacity = 100;
            lowBorderName.Visibility = Visibility.Visible;
            lowBorderDescription.Visibility = Visibility.Hidden;
        }
    }
}
