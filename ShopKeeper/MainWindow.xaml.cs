using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace ShopKeeper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CPU objCPU;
        Button[] btnsKritetiy;
        bool isClickHelperButton;
        public MainWindow()
        {
            InitializeComponent();
            //init_Elements();
            
        }
        private void init_Elements()
        {
            double ots = 0;
            btnsKritetiy = new Button[4];
            for (int i = 0; i < 4; i++)
            {
                btnsKritetiy[i] = new Button();
                btnsKritetiy[i].Margin = new Thickness(helperButton.Margin.Left + helperButton.Width + 2, helperButton.Margin.Top+ots, 0, 0);
                
                btnsKritetiy[i].Width = helperButton.Width+45;
                btnsKritetiy[i].Height = helperButton.Height;
                btnsKritetiy[i].HorizontalAlignment = HorizontalAlignment.Left;
                btnsKritetiy[i].VerticalAlignment = VerticalAlignment.Top;
                btnsKritetiy[i].Visibility = Visibility.Hidden;
                panelHelp.Children.Add(btnsKritetiy[i]);
                ots += helperButton.Height + 5;
            }
            btnsKritetiy[0].Content = "Указать нижние границы";
            btnsKritetiy[1].Content = "Субоптимизация";
            btnsKritetiy[2].Content = "Лексикографическая оптимизация";
            btnsKritetiy[3].Content = "Обобщенный критерий";
            btnsKritetiy[0].Click += lowBordersButtonClick;
            btnsKritetiy[1].Click += resetShow_Click;

            isClickHelperButton = false;
        }


        //Ivents
        public void but_Show_Click(object sender, EventArgs e)
        {
            clearViewCPUs();
            bool isChBox1 = true, isChBox2;
           isChBox1= (bool)chBoxs[0].IsChecked ? true : false;
            isChBox2 = (bool)chBoxs[1].IsChecked ? true : false;
            Show_Cpus(int.Parse(txtBoxsLow[0].Text), int.Parse(txtBoxsLow[1].Text), int.Parse(txtBoxsLow[2].Text),
                int.Parse(txtBoxsLow[3].Text), int.Parse(txtBoxsLow[4].Text), int.Parse(txtBoxsLow[5].Text), isChBox1, isChBox2);
        }
        public void resetShow_Click(object sender, EventArgs e)
        {
            clearViewCPUs();
            Show_Cpus();
        }
        public void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Show_Cpus();
            //showHelper();
            //panelHelp.IsEnabled = true;
            HelperWindow helperWindow = new HelperWindow();
            helperWindow.Show();
            //this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imageCPU.Opacity = 80;
        }

        private void GroupBox_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //scrViewerCPUs.Width = mainWindow.Width;
            //scrViewerCPUs.Height = mainWindow.Height;
            //panel.Height = scrViewerCPUs.Height;
            //panel.Width = scrViewerCPUs.Width;
            
        }
        private void HelperButton_Click(object sender, RoutedEventArgs e)
        {
            helperButtonShowOption(1);
        }
        private void lowBordersButtonClick(object sender, RoutedEventArgs e)
        {
            showHelpMenuLowBorders();
            helperButtonShowOption(1);
        }
        private void suboptimisationButtonClick(object sender, RoutedEventArgs e)
        {
            showHelpMenuSuboptimisation();
            helperButtonShowOption(1);
        }


        //Views
        TextBox[] txtBoxsLow;
        private void showHelper()
        {
            helperButton.Visibility = Visibility.Visible;
            helperButton.Background = mainWindow.Background;

        }
        CheckBox[] chBoxs;
        private void showHelpMenuLowBorders()
        {
            clearHelpMenu(1);
            Label[] lbls = new Label[5];
            txtBoxsLow = new TextBox[6];
            chBoxs = new CheckBox[2];
            Button btnShow = new Button();
            Button resetShow = new Button();
            int tekY = 90;
            int ots = 55;
            string[] forMenuLabels = { "Количество ядер", "Тактовая частота", "Стоимость","Интегрированное видеоядро",
                "Cистема охлаждения в комплекте" };
            for (int i = 0; i < lbls.Length; i++)
            {
                lbls[i] = new Label();
                lbls[i].FontSize = tempLabel.FontSize;
                lbls[i].FontStyle = tempLabel.FontStyle;
                
                panelHelp.Children.Add(lbls[i]);
                if (i > 2)
                {
                    lbls[i].Margin = new Thickness(45, tekY-4, 0, 0);
                    chBoxs[i-3] = new CheckBox();
                    chBoxs[i-3].Margin = new Thickness(25, tekY, 0, 0);
                    panelHelp.Children.Add(chBoxs[i-3]);
                    tekY += ots-20;
                }
                else
                {
                    lbls[i].Margin = new Thickness(25, tekY, 0, 0);
                    tekY += ots;
                }
                lbls[i].Content = forMenuLabels[i];
                
            }
            tekY = 115;
            int tekX = 25;
            for(int i = 0; i < txtBoxsLow.Length; i+=2)
            {
                txtBoxsLow[i] = new TextBox();
                txtBoxsLow[i].Margin = new Thickness(tekX, tekY, 0, 0);
                txtBoxsLow[i+1] = new TextBox();
                txtBoxsLow[i+1].Margin = new Thickness(tekX+60, tekY, 0, 0);
                txtBoxsLow[i].Width = 50;
                txtBoxsLow[i].Height = 20;
                txtBoxsLow[i+1].Width = 50;
                txtBoxsLow[i+1].Height = 20;
                txtBoxsLow[i].HorizontalAlignment = HorizontalAlignment.Left;
                txtBoxsLow[i].VerticalAlignment = VerticalAlignment.Top;
                txtBoxsLow[i+1].HorizontalAlignment = HorizontalAlignment.Left;
                txtBoxsLow[i+1].VerticalAlignment = VerticalAlignment.Top;
                panelHelp.Children.Add(txtBoxsLow[i]);
                panelHelp.Children.Add(txtBoxsLow[i+1]);
                tekY += ots;
            }
            btnShow.HorizontalAlignment = HorizontalAlignment.Left;
            btnShow.VerticalAlignment = VerticalAlignment.Top;
            btnShow.Width = 100;
            btnShow.Height = 40;
            btnShow.Margin = new Thickness(30, 315, 0, 0);
            btnShow.Content = "Show";
           // btnShow.Background = new SolidColorBrush(Colors.Green);
            btnShow.BorderBrush = new SolidColorBrush(Colors.Green);
            panelHelp.Children.Add(btnShow);
            btnShow.Click += but_Show_Click;
            
            resetShow.HorizontalAlignment = HorizontalAlignment.Left;
            resetShow.VerticalAlignment = VerticalAlignment.Top;
            resetShow.Width = 50;
            resetShow.Height = 30;
            resetShow.Opacity = 80;
            resetShow.Margin = new Thickness(30, 365, 0, 0);
            resetShow.Content = "Reset";
            panelHelp.Children.Add(resetShow);
            resetShow.Click += resetShow_Click;

        }
        private void showHelpMenuSuboptimisation()
        {
            clearHelpMenu();
        }
        private void Show_Cpus()
        {
            scrViewerCPUs.IsEnabled = true;
            scrViewerCPUs.Visibility = Visibility.Visible;
            panel.IsEnabled = true;
            int ots = 108;
            int tek = 0;
            objCPU = new CPU();
            imageCPU.Opacity = 100;
            imageCPU.IsEnabled = false;
            labelCPU.IsEnabled = false;
            labelQuestion1.IsEnabled = false;
            GroupBox[] arrGroupBoxsCPUs = new GroupBox[objCPU.GetCountCPUs()];
            Grid[] arrGridCPUs = new Grid[objCPU.GetCountCPUs()];
            Label[] socketCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] coreCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] frenqCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] integrCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] SOCPULabels = new Label[objCPU.GetCountCPUs()];
            Image[] CPUImages = new Image[objCPU.GetCountCPUs()];
            Grid viewCPUs = new Grid();
            Label[] priceCPULabels = new Label[objCPU.GetCountCPUs()];
            string[] namesOfImageCPU = {"Pictures_CPU/AMD_SEPRON_2650.jpg", "Pictures_CPU/AMD_ATHLON_200GE.jpg",
                "Pictures_CPU/INTEL_CELERON_G3930.jpg", "Pictures_CPU/INTEL_CELERON_G4900.jpg","Pictures_CPU/AMD_FX_6300.jpg",
            "Pictures_CPU/INTEL_PENTIUM_G5400.jpg","Pictures_CPU/INTEL_CELERON_G4920.jpg","Pictures_CPU/AMD_FX_8300.jpg",
            "Pictures_CPU/AMD_RYZEN_2300X.jpg","Pictures_CPU/INTEL_CORE_I3_8100.jpg","Pictures_CPU/INTEL_XEON_E3_1230.jpg","Pictures_CPU/INTEL_XEON_E3_1245.jpg",
            "Pictures_CPU/AMD_Ryzen_Threadripper_1900X.jpg"};
            ScrollViewer ScrViewerCPUs = new ScrollViewer();
            
           // panel.Children.Add(ScrViewerCPUs);
            for (int i = 0; i < arrGroupBoxsCPUs.Length; i++)
            {
                arrGroupBoxsCPUs[i] = new GroupBox();
                arrGridCPUs[i] = new Grid();
                //create GroupBoxes for CPU view
                arrGroupBoxsCPUs[i].Content = arrGridCPUs[i];
                arrGroupBoxsCPUs[i].Margin = new Thickness(2, tek, 0, 0);
                arrGroupBoxsCPUs[i].HorizontalAlignment = HorizontalAlignment.Left;
                arrGroupBoxsCPUs[i].Height = 103;
                arrGroupBoxsCPUs[i].Width = 311;
                arrGroupBoxsCPUs[i].Visibility = mainWindow.Visibility;
                arrGroupBoxsCPUs[i].Header = objCPU.cpuList.ElementAt(i).Key;
                arrGroupBoxsCPUs[i].VerticalAlignment = VerticalAlignment.Top;
                panel.Children.Add(arrGroupBoxsCPUs[i]);
                tek = tek + ots;

                //create Images for CPU view
                CPUImages[i] = new Image();
                CPUImages[i].Margin = CPUImage.Margin;
                CPUImages[i].HorizontalAlignment = HorizontalAlignment.Left;
                CPUImages[i].VerticalAlignment = VerticalAlignment.Top;

                CPUImages[i].Source= new BitmapImage(new Uri(namesOfImageCPU[i], UriKind.Relative));
                //Create Labels for CPU view
                socketCPULabels[i] = new Label();
                coreCPULabels[i] = new Label();
                frenqCPULabels[i] = new Label();
                integrCPULabels[i] = new Label();
                SOCPULabels[i] = new Label();
                priceCPULabels[i] = new Label();
                socketCPULabels[i].Content = "Сокет: "+ objCPU.cpuList.ElementAt(i).Value.socket_CPU;
                coreCPULabels[i].Content = "Ядер: " + objCPU.cpuList.ElementAt(i).Value.countCores_CPU;
                frenqCPULabels[i].Content = "Тактовая частота: " + objCPU.cpuList.ElementAt(i).Value.frequency_CPU+" MHz";
                integrCPULabels[i].Content = "Интегрированное видео: " + objCPU.cpuList.ElementAt(i).Value.integratedVideo_CPU;
                SOCPULabels[i].Content = "Система охлаждения: " + objCPU.cpuList.ElementAt(i).Value.includedCS_CPU;
                priceCPULabels[i].Content = objCPU.cpuList.ElementAt(i).Value.price_CPU+ " ₽";

                //set view of Labels of CPU
                arrGridCPUs[i].Children.Add(socketCPULabels[i]);
                arrGridCPUs[i].Children.Add(coreCPULabels[i]);
                arrGridCPUs[i].Children.Add(frenqCPULabels[i]);
                arrGridCPUs[i].Children.Add(integrCPULabels[i]);
                arrGridCPUs[i].Children.Add(SOCPULabels[i]);
                arrGridCPUs[i].Children.Add(priceCPULabels[i]);
                arrGridCPUs[i].Children.Add(CPUImages[i]);

                //styling Labels of CPU view
                socketCPULabels[i].FontSize = socketCPULabel.FontSize;
                socketCPULabels[i].FontStyle = socketCPULabel.FontStyle;
                socketCPULabels[i].Margin = socketCPULabel.Margin;

                coreCPULabels[i].FontSize = coreCPULabel.FontSize;
                coreCPULabels[i].FontStyle = coreCPULabel.FontStyle;
                coreCPULabels[i].Margin = coreCPULabel.Margin;

                frenqCPULabels[i].FontSize = frencCpuLabel.FontSize;
                frenqCPULabels[i].FontStyle = frencCpuLabel.FontStyle;
                frenqCPULabels[i].Margin = frencCpuLabel.Margin;

                integrCPULabels[i].FontSize = IntegrCPULabel.FontSize;
                integrCPULabels[i].FontStyle = IntegrCPULabel.FontStyle;
                integrCPULabels[i].Margin = IntegrCPULabel.Margin;

                SOCPULabels[i].FontSize = SOCPULabel.FontSize;
                SOCPULabels[i].FontStyle = SOCPULabel.FontStyle;
                SOCPULabels[i].Margin = SOCPULabel.Margin;

                priceCPULabels[i].FontSize = price_Label.FontSize;
                priceCPULabels[i].FontStyle = price_Label.FontStyle;
                priceCPULabels[i].Margin = price_Label.Margin;
                priceCPULabels[i].FontWeight = price_Label.FontWeight;
            }
        }
        private void Show_Cpus(int minCores,int maxCores,int minFrenq,int maxFrenq,int minPrice,int maxPrice, bool intVideo, bool SO,string type="",string socket="")
        {
            scrViewerCPUs.IsEnabled = true;
            scrViewerCPUs.Visibility = Visibility.Visible;
            panel.IsEnabled = true;
            int ots = 108;
            int tek = 0;
            objCPU = new CPU();
            imageCPU.Opacity = 100;
            imageCPU.IsEnabled = false;
            labelCPU.IsEnabled = false;
            labelQuestion1.IsEnabled = false;
            GroupBox[] arrGroupBoxsCPUs = new GroupBox[objCPU.GetCountCPUs()];
            Grid[] arrGridCPUs = new Grid[objCPU.GetCountCPUs()];
            Label[] socketCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] coreCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] frenqCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] integrCPULabels = new Label[objCPU.GetCountCPUs()];
            Label[] SOCPULabels = new Label[objCPU.GetCountCPUs()];
            Image[] CPUImages = new Image[objCPU.GetCountCPUs()];
            Grid viewCPUs = new Grid();
            Label[] priceCPULabels = new Label[objCPU.GetCountCPUs()];
            string[] namesOfImageCPU = {"Pictures_CPU/AMD_SEPRON_2650.jpg", "Pictures_CPU/AMD_ATHLON_200GE.jpg",
                "Pictures_CPU/INTEL_CELERON_G3930.jpg", "Pictures_CPU/INTEL_CELERON_G4900.jpg","Pictures_CPU/AMD_FX_6300.jpg",
            "Pictures_CPU/INTEL_PENTIUM_G5400.jpg","Pictures_CPU/INTEL_CELERON_G4920.jpg","Pictures_CPU/AMD_FX_8300.jpg",
            "Pictures_CPU/AMD_RYZEN_2300X.jpg","Pictures_CPU/INTEL_CORE_I3_8100.jpg","Pictures_CPU/INTEL_XEON_E3_1230.jpg","Pictures_CPU/INTEL_XEON_E3_1245.jpg",
            "Pictures_CPU/AMD_Ryzen_Threadripper_1900X.jpg"};
            ScrollViewer ScrViewerCPUs = new ScrollViewer();

            // panel.Children.Add(ScrViewerCPUs);
            for (int i = 0; i < arrGroupBoxsCPUs.Length; i++)
            {
                if ((objCPU.cpuList.ElementAt(i).Value.socket_CPU == socket || socket == "") 
                    && (objCPU.cpuList.ElementAt(i).Value.type_CPU == type || type == "")
                    && (objCPU.cpuList.ElementAt(i).Value.countCores_CPU>=minCores && objCPU.cpuList.ElementAt(i).Value.countCores_CPU <= maxCores)
                    && (objCPU.cpuList.ElementAt(i).Value.frequency_CPU>=minFrenq && objCPU.cpuList.ElementAt(i).Value.frequency_CPU <= maxFrenq)
                    && (objCPU.cpuList.ElementAt(i).Value.price_CPU>=minPrice && objCPU.cpuList.ElementAt(i).Value.price_CPU <= maxPrice
                    && intVideo == objCPU.cpuList.ElementAt(i).Value.integratedVideo_CPU 
                    && objCPU.cpuList.ElementAt(i).Value.includedCS_CPU == SO))
                {
                    arrGroupBoxsCPUs[i] = new GroupBox();
                    arrGridCPUs[i] = new Grid();
                    //create GroupBoxes for CPU view
                    arrGroupBoxsCPUs[i].Content = arrGridCPUs[i];
                    arrGroupBoxsCPUs[i].Margin = new Thickness(359, tek, 0, 0);
                    arrGroupBoxsCPUs[i].HorizontalAlignment = HorizontalAlignment.Left;
                    arrGroupBoxsCPUs[i].Height = 103;
                    arrGroupBoxsCPUs[i].Width = 311;
                    arrGroupBoxsCPUs[i].Visibility = mainWindow.Visibility;
                    arrGroupBoxsCPUs[i].Header = objCPU.cpuList.ElementAt(i).Key;
                    arrGroupBoxsCPUs[i].VerticalAlignment = VerticalAlignment.Top;
                    panel.Children.Add(arrGroupBoxsCPUs[i]);
                    tek = tek + ots;

                    //create Images for CPU view
                    CPUImages[i] = new Image();
                    CPUImages[i].Margin = CPUImage.Margin;
                    CPUImages[i].HorizontalAlignment = HorizontalAlignment.Left;
                    CPUImages[i].VerticalAlignment = VerticalAlignment.Top;

                    CPUImages[i].Source = new BitmapImage(new Uri(namesOfImageCPU[i], UriKind.Relative));
                    //Create Labels for CPU view
                    socketCPULabels[i] = new Label();
                    coreCPULabels[i] = new Label();
                    frenqCPULabels[i] = new Label();
                    integrCPULabels[i] = new Label();
                    SOCPULabels[i] = new Label();
                    priceCPULabels[i] = new Label();
                    socketCPULabels[i].Content = "Сокет: " + objCPU.cpuList.ElementAt(i).Value.socket_CPU;
                    coreCPULabels[i].Content = "Ядер: " + objCPU.cpuList.ElementAt(i).Value.countCores_CPU;
                    frenqCPULabels[i].Content = "Тактовая частота: " + objCPU.cpuList.ElementAt(i).Value.frequency_CPU + " MHz";
                    integrCPULabels[i].Content = "Интегрированное видео: " + objCPU.cpuList.ElementAt(i).Value.integratedVideo_CPU;
                    SOCPULabels[i].Content = "Система охлаждения: " + objCPU.cpuList.ElementAt(i).Value.includedCS_CPU;
                    priceCPULabels[i].Content = objCPU.cpuList.ElementAt(i).Value.price_CPU + " ₽";

                    //set view of Labels of CPU

                    arrGridCPUs[i].Children.Add(socketCPULabels[i]);
                    arrGridCPUs[i].Children.Add(coreCPULabels[i]);
                    arrGridCPUs[i].Children.Add(frenqCPULabels[i]);
                    arrGridCPUs[i].Children.Add(integrCPULabels[i]);
                    arrGridCPUs[i].Children.Add(SOCPULabels[i]);
                    arrGridCPUs[i].Children.Add(priceCPULabels[i]);
                    arrGridCPUs[i].Children.Add(CPUImages[i]);


                    //styling Labels of CPU view
                    socketCPULabels[i].FontSize = socketCPULabel.FontSize;
                    socketCPULabels[i].FontStyle = socketCPULabel.FontStyle;
                    socketCPULabels[i].Margin = socketCPULabel.Margin;

                    coreCPULabels[i].FontSize = coreCPULabel.FontSize;
                    coreCPULabels[i].FontStyle = coreCPULabel.FontStyle;
                    coreCPULabels[i].Margin = coreCPULabel.Margin;

                    frenqCPULabels[i].FontSize = frencCpuLabel.FontSize;
                    frenqCPULabels[i].FontStyle = frencCpuLabel.FontStyle;
                    frenqCPULabels[i].Margin = frencCpuLabel.Margin;

                    integrCPULabels[i].FontSize = IntegrCPULabel.FontSize;
                    integrCPULabels[i].FontStyle = IntegrCPULabel.FontStyle;
                    integrCPULabels[i].Margin = IntegrCPULabel.Margin;

                    SOCPULabels[i].FontSize = SOCPULabel.FontSize;
                    SOCPULabels[i].FontStyle = SOCPULabel.FontStyle;
                    SOCPULabels[i].Margin = SOCPULabel.Margin;

                    priceCPULabels[i].FontSize = price_Label.FontSize;
                    priceCPULabels[i].FontStyle = price_Label.FontStyle;
                    priceCPULabels[i].Margin = price_Label.Margin;
                    priceCPULabels[i].FontWeight = price_Label.FontWeight;
                }
            }
        }
        private void clearViewCPUs()
        {
            panel.Children.Clear();
        }
        private void clearHelpMenu(int r=0)
        {
            panelHelp.Children.Clear();
            if (r == 1)
            {
                panelHelp.Children.Add(helperButton);
                for (int i = 0; i < 4; i++)
                {
                    panelHelp.Children.Add(btnsKritetiy[i]);
                }
            }
        }



        private void HelperButton_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void HelperButton_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        




        //методы для кнопок
        private void helperButtonShowOption(int r)
        {
            switch (r)
            {
                case 1: //скрыть или показать
                    if (!isClickHelperButton)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            btnsKritetiy[i].Visibility = Visibility.Visible;
                            btnsKritetiy[i].IsEnabled = true;
                        }

                        isClickHelperButton = true;
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                            btnsKritetiy[i].Visibility = Visibility.Hidden;

                        isClickHelperButton = false;
                    }
                    break;
                case 2: //скрыть все
                    
                        for (int i = 0; i < 4; i++)
                            btnsKritetiy[i].Visibility = Visibility.Hidden;
                        isClickHelperButton = false;
                    
                    break;

            }

        }
    }
}
