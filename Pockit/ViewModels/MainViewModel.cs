using System;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using Pockit.Core.Models;
using Pockit.Core.Services.Users;

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
            var gitHubApi = Mvx.IoCProvider.GetSingleton<IUserService>();
            var authenticatedUser = await gitHubApi.GetAuthorizedUser();
            await _navigationService.Navigate<ProfileViewModel, User>(authenticatedUser);
        });
    }
}