﻿#nullable enable

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.ViewModels;
using Pockit.Properties;

namespace Pockit.ViewModels
{
    public abstract class ViewModelBase : MvxViewModel, INotifyPropertyChanged
    {
        private readonly IDictionary<string, object?> _propertyNameToValueMapping = new Dictionary<string, object?>();

        public event PropertyChangedEventHandler PropertyChanged;

        public T Get<T>([CallerMemberName] string? name = null)
        {
            return (_propertyNameToValueMapping.TryGetValue(name!, out var obj) && obj != null ? (T) obj : default)!;
        }

        public void Set<T>(T value, [CallerMemberName] string? name = null)
        {
            if (EqualityComparer<T>.Default.Equals(Get<T>(name), value))
            {
                return;
            }

            _propertyNameToValueMapping[name!] = value;
            OnPropertyChanged(name!);
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class ViewModelBase<T> : ViewModelBase, IMvxViewModel<T> where T : class
    {
        /// <inheritdoc />
        public abstract void Prepare(T parameter);
    }
}