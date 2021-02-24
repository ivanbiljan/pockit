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

namespace Pockit.ViewModels
{
    public sealed class MainViewModel : ViewModelBase
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            ShowProfileViewCommand = new MvxCommand(() => _navigationService.Navigate<ProfileViewModel>());
        }

        public IMvxCommand ShowProfileViewCommand { get; }
    }
}