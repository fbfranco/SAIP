using SAIP.View.Windows;

namespace SAIP.Helpers
{
    public class ViewInstances
    {
        /******MainWindow******/
        private static MainWindow _MainInstance;
        public static MainWindow MainInstance
        {
            get
            {
                var x = _MainInstance == null ? new MainWindow() : _MainInstance;
                return x;
            }
            internal set { _MainInstance = value; }
        }
    }
}
