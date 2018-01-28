using SAIP.View.UserControls;
using SAIP.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace SAIP.View.Windows
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance = new MainWindow();
        public MainWindow() => InitializeComponent();
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
