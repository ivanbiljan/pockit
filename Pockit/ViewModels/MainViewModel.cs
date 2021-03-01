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
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.Platforms.Android;
using Pockit.Core;
using Pockit.Core.Models;

namespace Pockit.ViewModels
{
    public sealed class MainViewModel : ViewModelBase
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        }

        public IMvxCommand ShowProfileViewCommand => new MvxCommand(async () => {
            var gitHubApi = MvxIoCProvider.Instance.GetSingleton<IGitHubApi>();
            var authenticatedUser = await gitHubApi.GetAuthenticatedUser();
            await _navigationService.Navigate<ProfileViewModel, GitHubUser>(authenticatedUser);
        });
    }
}