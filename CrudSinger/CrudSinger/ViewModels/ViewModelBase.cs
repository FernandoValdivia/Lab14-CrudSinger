using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CrudSinger.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string nameProperty = null)
        {
            var change = PropertyChanged;
            if(change != null)
            {
                change(this, new PropertyChangedEventArgs(nameProperty));
            }
        }

    }
}
