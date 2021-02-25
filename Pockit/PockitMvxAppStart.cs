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
using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pockit.Core.Services;
using Pockit.ViewModels;

namespace Pockit 
{
    /// <summary>
    /// Represents the class that runs once MVX initialization is complete. This class handles navigating to the first view model.
    /// </summary>
    public sealed class PockitMvxAppStart : MvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ILoginService _loginService;
        
        /// <inheritdoc />
        public PockitMvxAppStart(IMvxApplication application, IMvxNavigationService navigationService, ILoginService loginService) : base(application, navigationService)
        {
            _navigationService = navigationService;
            _loginService = loginService;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            if (!_loginService.TryGetLogin(out var token))
            {
                return _navigationService.Navigate<LoginViewModel>();
            }

            return _navigationService.Navigate<MainViewModel>();
        }
    }
}