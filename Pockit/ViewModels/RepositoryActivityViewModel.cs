using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Pockit.Core.Models;

namespace Pockit.ViewModels
{
    public sealed class RepositoryActivityViewModel : ViewModelBase<Repository>
    {
        private readonly IMvxNavigationService _navigationService;

        public RepositoryActivityViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Repository Model { get; private set; } = null!;

        /// <inheritdoc />
        public override void Prepare(Repository parameter)
        {
            Model = parameter;
        }
    }
}