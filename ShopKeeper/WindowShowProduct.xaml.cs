﻿using System;
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
    /// Логика взаимодействия для WindowShowProduct.xaml
    /// </summary>
    public partial class WindowShowProduct : Window
    {
        int index;
        Window parentForm;
        CPU cpu;
        public WindowShowProduct(int indexProduct,Window parentWindow)
        {
            InitializeComponent();
            index = indexProduct;
            parentForm = parentWindow;
            cpu = new CPU();
            showProduct();
        }
        private void showProduct()
        {
            win.Title = cpu.cpuList.ElementAt(index).Key;
            string intVideo, intSo;
            if (cpu.cpuList.ElementAt(index).Value.integratedVideo_CPU)
            {
                intVideo = "Имеется";
            }
            else
            {
                intVideo = "Не имеется";
            }
            if (cpu.cpuList.ElementAt(index).Value.includedCS_CPU)
            {
                intSo= "Имеется";
            }
            else
            {
                intSo = "Не имеется";
            }
            label1.Content = "Сокет: " + cpu.cpuList.ElementAt(index).Value.socket_CPU;
            label2.Content = "Ядер: " + cpu.cpuList.ElementAt(index).Value.countCores_CPU;
            label3.Content = "Тактовая частота: " + cpu.cpuList.ElementAt(index).Value.frequency_CPU + " MHz";
            label4.Content = "Интегрированное видео: " + intVideo;
            label5.Content = "Система охлаждения: " + intSo;
            label6.Content = "Цена: "+cpu.cpuList.ElementAt(index).Value.price_CPU + " ₽";
            imageProduct.Source= new BitmapImage(new Uri(cpu.cpuToImageCPU.ElementAt(index).Value, UriKind.Relative));
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            parentForm.Show();
        }
    }
}
