using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace SAIP.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region ViewModel Estructura Básica

        public void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Cerrar y Mostrar las ventanas

        bool? _CloseWindowFlag;
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                RaisePropertyChanged("CloseWindowFlag");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null
                    ? true
                    : !CloseWindowFlag;
            }));
        }
        #endregion
    }
}
