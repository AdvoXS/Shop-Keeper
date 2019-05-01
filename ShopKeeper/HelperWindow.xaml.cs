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
        Image leksiImage;
        Image obsImage;
        Label selectWindowLabelSelect;
        Label lowBorderName, lowBorderDescription;
        Label leksiName, leksiDescription;
        Label subOptimisationDescription, subOptimisationName;
        Label obsName, obsDescription;

        Window parentForm;
        public HelperWindow(Window parentWindow)
        {
            InitializeComponent();
            parentForm = parentWindow;
            initElements();
            initLabelStartAnimation();
        }

        private void initElements()
        {//инициализация элементов управления

            isShowAll = false;


            okrezhim = true;
            selectWindowLabelSelect = new Label();
            selectWindowLabelSelect.Margin = new Thickness(this.Width / 3.5, this.Height / 36, 0, 0);
            selectWindowLabelSelect.Style = welcomeLabel.Style;
            selectWindowLabelSelect.FontFamily = welcomeLabel.FontFamily;
            selectWindowLabelSelect.FontSize = welcomeLabel.FontSize;
            selectWindowLabelSelect.FontStyle = welcomeLabel.FontStyle;
            selectWindowLabelSelect.Content = "Выберите алгоритм подбора";
            selectWindowLabelSelect.Foreground = buttonNext.Foreground;
            selectWindowLabelSelect.FontWeight = welcomeLabel.FontWeight;
            selectWindowLabelSelect.Opacity = 0;
            mainCanvas.Children.Add(selectWindowLabelSelect);

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
            lowBorderImage.MouseUp += lowBorderImage_Click;
            mainCanvas.Children.Add(lowBorderImage);
            lowBorderImage.Visibility = Visibility.Hidden;

            lowBorderName = new Label();
            lowBorderName.Margin = new Thickness(Width / 45, Height / 1.45, 0, 0);
            lowBorderName.Style = welcomeLabel.Style;
            lowBorderName.FontFamily = welcomeLabel.FontFamily;
            lowBorderName.FontSize = welcomeLabel.FontSize -12;
            lowBorderName.FontStyle = welcomeLabel.FontStyle;
            lowBorderName.Content = "Метод указания нижних границ";
            lowBorderName.Foreground = buttonNext.Foreground;
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
            lowBorderDescription.Foreground = buttonNext.Foreground;
            lowBorderDescription.Visibility = Visibility.Hidden;
            mainCanvas.Children.Add(lowBorderDescription);

            subOptimisationImage = new Image();
            subOptimisationImage.Margin = new Thickness(Width / 3.3, Height / 5, 0, 0);
            subOptimisationImage.Opacity = 0;
            subOptimisationImage.HorizontalAlignment = HorizontalAlignment.Left;
            subOptimisationImage.VerticalAlignment = VerticalAlignment.Top;
            subOptimisationImage.Width = 150;
            subOptimisationImage.Height = 150;
            subOptimisationImage.Cursor = Cursors.Hand;
            subOptimisationImage.Source = new BitmapImage(new Uri("helpersImages/suboptimisationImage.png", UriKind.Relative));
            subOptimisationImage.MouseEnter += subOptimisationImage_MouseOn;
            subOptimisationImage.MouseLeave += subOptimisationImage_MouseOut;
            subOptimisationImage.MouseUp += subOptimImage_Click;
            mainCanvas.Children.Add(subOptimisationImage);

            subOptimisationName = new Label();
            subOptimisationName.Margin = new Thickness(Width / 3.3, Height / 1.45, 0, 0);
            subOptimisationName.Style = welcomeLabel.Style;
            subOptimisationName.FontFamily = welcomeLabel.FontFamily;
            subOptimisationName.FontSize = welcomeLabel.FontSize - 12;
            subOptimisationName.FontStyle = welcomeLabel.FontStyle;
            subOptimisationName.Content = "Метод субоптимизации";
            subOptimisationName.Foreground = buttonNext.Foreground;
            subOptimisationName.FontWeight = welcomeLabel.FontWeight;
            subOptimisationName.Opacity = 0;
            mainCanvas.Children.Add(subOptimisationName);

            subOptimisationDescription = new Label();
            subOptimisationDescription.Margin = new Thickness(Width / 3.5, Height / 1.45, 0, 0);
            subOptimisationDescription.Style = welcomeLabel.Style;
            subOptimisationDescription.FontFamily = welcomeLabel.FontFamily;
            subOptimisationDescription.FontSize = welcomeLabel.FontSize - 14;
            subOptimisationDescription.FontStyle = welcomeLabel.FontStyle;
            subOptimisationDescription.Content = "Вам следует указать главный критерий\nи границы параметров товара \nвплоть до нахождения нужного.";
            subOptimisationDescription.Foreground = buttonNext.Foreground;
            subOptimisationDescription.Visibility = Visibility.Hidden;
            mainCanvas.Children.Add(subOptimisationDescription);

            leksiImage = new Image();
            leksiImage.Margin = new Thickness(Width / 1.8, Height / 5, 0, 0);
            leksiImage.Opacity = 0;
            leksiImage.HorizontalAlignment = HorizontalAlignment.Left;
            leksiImage.VerticalAlignment = VerticalAlignment.Top;
            leksiImage.Width = 150;
            leksiImage.Height = 150;
            leksiImage.Cursor = Cursors.Hand;

            leksiImage.MouseEnter += leksiImage_MouseOn;
            leksiImage.MouseLeave += leksiImage_MouseOut;
            leksiImage.MouseUp += leksiImage_Click;
            leksiImage.Source = new BitmapImage(new Uri("helpersImages/47.png", UriKind.Relative));
            mainCanvas.Children.Add(leksiImage);

            leksiName = new Label();
            leksiName.Margin = new Thickness(Width / 1.85, Height / 1.45, 0, 0);
            leksiName.Style = welcomeLabel.Style;
            leksiName.FontFamily = welcomeLabel.FontFamily;
            leksiName.FontSize = welcomeLabel.FontSize - 12;
            leksiName.FontStyle = welcomeLabel.FontStyle;
            leksiName.Content = "Лексикографический метод";
            leksiName.Foreground = buttonNext.Foreground;
            leksiName.FontWeight = welcomeLabel.FontWeight;
            leksiName.Opacity = 0;
            mainCanvas.Children.Add(leksiName);

            leksiDescription = new Label();
            leksiDescription.Margin = new Thickness(Width / 1.85, Height / 1.45, 0, 0);
            leksiDescription.Style = welcomeLabel.Style;
            leksiDescription.FontFamily = welcomeLabel.FontFamily;
            leksiDescription.FontSize = welcomeLabel.FontSize - 14;
            leksiDescription.FontStyle = welcomeLabel.FontStyle;
            leksiDescription.Content = "Вам следует расставить приоритеты\nсреди параметров товара.";
            leksiDescription.Foreground = buttonNext.Foreground;
            leksiDescription.Visibility = Visibility.Hidden;
            mainCanvas.Children.Add(leksiDescription);

            obsImage = new Image();
            obsImage.Margin = new Thickness(Width / 1.27, Height / 5, 0, 0);
            obsImage.Opacity = 0;
            obsImage.HorizontalAlignment = HorizontalAlignment.Left;
            obsImage.VerticalAlignment = VerticalAlignment.Top;
            obsImage.Width = 150;
            obsImage.Height = 150;
            obsImage.Cursor = Cursors.Hand;
            obsImage.MouseEnter += obsImage_MouseOn;
            obsImage.MouseLeave += obsImage_MouseOut;
            obsImage.MouseUp += obsImage_Click;
            obsImage.Source = new BitmapImage(new Uri("helpersImages/obs1.png", UriKind.Relative));
            mainCanvas.Children.Add(obsImage);

            obsName = new Label();
            obsName.Margin = new Thickness(Width / 1.25, Height / 1.45, 0, 0);
            obsName.Style = welcomeLabel.Style;
            obsName.FontFamily = welcomeLabel.FontFamily;
            obsName.FontSize = welcomeLabel.FontSize - 12;
            obsName.FontStyle = welcomeLabel.FontStyle;
            obsName.Content = "Обобщенный метод";
            obsName.Foreground = buttonNext.Foreground;
            obsName.FontWeight = welcomeLabel.FontWeight;
            obsName.Opacity = 0;
            mainCanvas.Children.Add(obsName);

            obsDescription = new Label();
            obsDescription.Margin = new Thickness(Width / 1.26, Height / 1.45, 0, 0);
            obsDescription.Style = welcomeLabel.Style;
            obsDescription.FontFamily = welcomeLabel.FontFamily;
            obsDescription.FontSize = welcomeLabel.FontSize - 14;
            obsDescription.FontStyle = welcomeLabel.FontStyle;
            obsDescription.Content = "Вам следует расставить веса \nпараметрам.\nЧем больше вес, тем приоритетней.";
            obsDescription.Foreground = buttonNext.Foreground;
            obsDescription.Visibility = Visibility.Hidden;
            mainCanvas.Children.Add(obsDescription);
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
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = this.Opacity + 10;
            da.Duration = TimeSpan.FromSeconds(5);
            selectWindowLabelSelect.BeginAnimation(Label.OpacityProperty, da);

            da.From = 0;
            da.To = this.Opacity + 15;
            da.Duration = TimeSpan.FromSeconds(10);
            lowBorderImage.BeginAnimation(Image.OpacityProperty, da);

            da.From = 0;
            da.To = this.Opacity + 10;
            da.Duration = TimeSpan.FromSeconds(10);
            lowBorderName.BeginAnimation(Label.OpacityProperty, da);
            subOptimisationName.BeginAnimation(Label.OpacityProperty, da);
            leksiName.BeginAnimation(Label.OpacityProperty, da);
            obsName.BeginAnimation(Label.OpacityProperty, da);

            da.From = 0;
            da.To = this.Opacity + 15;
            da.Duration = TimeSpan.FromSeconds(10);
            subOptimisationImage.BeginAnimation(Image.OpacityProperty, da);

            leksiImage.BeginAnimation(Image.OpacityProperty, da);
            obsImage.BeginAnimation(Image.OpacityProperty, da);
        }

        //Events methods
        public void Label_Initialized(object sender, EventArgs e)
        {

        }
        Image lowBorderImage;
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            startWindowsNexted();
            showerCpusLabel.Visibility = Visibility.Visible;
            welcomeLabel.IsEnabled = false;
            startLabel1.IsEnabled = false;
            mainCanvas.IsEnabled = true;
            rezhim.Opacity = 100;
            selectWindowStartAnimation();
        }

        //LowBorderAlgorithm
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
        private void lowBorderImage_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            this.IsEnabled = false;
            WindowLowBorders windowLow = new WindowLowBorders(this);
            windowLow.Show();
        }

        //subOptim
        private void subOptimisationImage_MouseOn(object sender, RoutedEventArgs e)
        {
            subOptimisationName.Opacity = 0;
            subOptimisationName.Visibility = Visibility.Hidden;
            subOptimisationDescription.Visibility = Visibility.Visible;
        }
        bool okrezhim;
        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (okrezhim)
            {
                DoubleAnimation da2 = new DoubleAnimation();
                da2.From = helps.Height;
                da2.To = helps.Height + 100;
                da2.Duration = TimeSpan.FromSeconds(1);
                helps.BeginAnimation(Window.HeightProperty, da2);
                rezhim.Content = "Режим эксперта";
                okrezhim = false;
            }
            else
            {
                DoubleAnimation da2 = new DoubleAnimation();
                da2.From = helps.Height;
                da2.To = helps.Height - 100;
                da2.Duration = TimeSpan.FromSeconds(1);
                helps.BeginAnimation(Window.HeightProperty, da2);
                rezhim.Content = "Обычный режим";
                okrezhim = true;
            }
        }

        private void subOptimisationImage_MouseOut(object sender, RoutedEventArgs e)
        {
            subOptimisationName.Opacity = 100;
            subOptimisationName.Visibility = Visibility.Visible;
            subOptimisationDescription.Visibility = Visibility.Hidden;
        }

        private void leksiImage_MouseOn(object sender, RoutedEventArgs e)
        {
            leksiName.Opacity = 0;
            leksiName.Visibility = Visibility.Hidden;
            leksiDescription.Visibility = Visibility.Visible;
        }
        private void leksiImage_MouseOut(object sender, RoutedEventArgs e)
        {
            leksiName.Opacity = 100;
            leksiName.Visibility = Visibility.Visible;
            leksiDescription.Visibility = Visibility.Hidden;
        }
        private void leksiImage_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            this.IsEnabled = false;
            WindowLeksi windowLow = new WindowLeksi(this);
            windowLow.Show();
        }
        bool isShowAll;
        private void Label_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            if (!isShowAll)
            {
                if (parentForm != null)
                {
                    parentForm.Show();
                }
                else
                {
                    MainWindow win = new MainWindow();
                    win.Show_Cpus();
                    win.Show();
                }
                isShowAll = true;
                showerCpusLabel.Content = "Скрыть все продукты";
            }
            else
            {
                parentForm.Hide();
                isShowAll = false;
                showerCpusLabel.Content = "Показать все продукты";
            }
        }

        private void Helps_Closed(object sender, EventArgs e)
        {
            if (parentForm != null) parentForm.Close();
        }

        private void subOptimImage_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            this.IsEnabled = false;
            WindowSubOptim windowLow = new WindowSubOptim(this);
            windowLow.Show();
        }

        //Обобщенный метод Events

        private void obsImage_MouseOn(object sender, RoutedEventArgs e)
        {
            obsName.Opacity = 0;
            obsName.Visibility = Visibility.Hidden;
            obsDescription.Visibility = Visibility.Visible;
        }
        private void obsImage_MouseOut(object sender, RoutedEventArgs e)
        {
            obsName.Opacity = 100;
            obsName.Visibility = Visibility.Visible;
            obsDescription.Visibility = Visibility.Hidden;
        }
        private void obsImage_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            this.IsEnabled = false;
            WindowObs windowLow = new WindowObs(this);
            windowLow.Show();
        }
    }
}
