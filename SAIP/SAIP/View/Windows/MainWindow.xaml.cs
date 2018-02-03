using System.Windows;
using System.Windows.Input;

namespace SAIP.View.Windows
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance = new MainWindow();
        public MainWindow() => InitializeComponent();
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
