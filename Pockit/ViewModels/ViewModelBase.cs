﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Pockit.Properties;

namespace Pockit.ViewModels 
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