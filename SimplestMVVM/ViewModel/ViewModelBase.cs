using System.ComponentModel;

namespace SimplestMVVM.ViewModel
{
    public class ViewModelBase:INotifyPropertyChanged
    {  
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
