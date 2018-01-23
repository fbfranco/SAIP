using SAIP.View.Windows;

namespace SAIP.Helpers
{
    public class ViewInstances
    {
        /******MainWindow******/
        public static MainWindow MainInstance
        {
            get
            {
                var x = MainWindow.Instance == null ? new MainWindow() : MainWindow.Instance;
                return x;
            }
        }
    }
}
