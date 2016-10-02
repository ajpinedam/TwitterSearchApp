using System;
using System.ComponentModel;

namespace TwitterSearchApp.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase ()
        {
        }


        protected void RaisePropertyChanged (string propertyName)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }

    }
}
