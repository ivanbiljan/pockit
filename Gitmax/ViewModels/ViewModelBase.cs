using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Gitmax.Annotations;

namespace Gitmax.ViewModels 
{
    public sealed class ViewModelBase : INotifyPropertyChanged
    {
        private readonly IDictionary<string, object?> _propertyNameToValueMapping = new Dictionary<string, object?>();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public T Get<T>([CallerMemberName] string? name = null)
        {
            return (_propertyNameToValueMapping.TryGetValue(name, out var obj) && obj != null ? (T) obj : default)!;
        }

        public void Set<T>(T value, [CallerMemberName] string? name = null)
        {
            if (EqualityComparer<T>.Default.Equals(Get<T>(name), value))
            {
                return;
            }

            _propertyNameToValueMapping[name!] = value;
            OnPropertyChanged(name);
        }
    }
}