using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundToText
{

    class ObservableCollectionEx<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        private void Handle(object sender, PropertyChangedEventArgs args)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, null));
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object t in e.NewItems)
                {
                    ((T)t).PropertyChanged += Handle;
                }
            }
            if (e.OldItems != null)
            {
                foreach (object t in e.OldItems)
                {
                    ((T)t).PropertyChanged -= Handle;
                }
            }
            base.OnCollectionChanged(e);
        }
    }

}