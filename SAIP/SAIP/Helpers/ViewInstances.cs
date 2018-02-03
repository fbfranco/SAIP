using SAIP.Model;
using SAIP.View.UserControls;
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

        /******DocumentosCrtlU******/
        public static DocumentosCtrlU DocInstance
        {
            get
            {
                var x = DocumentosCtrlU.Instance == null ? new DocumentosCtrlU() : DocumentosCtrlU.Instance;
                return x;
            }
        }
    }
}
