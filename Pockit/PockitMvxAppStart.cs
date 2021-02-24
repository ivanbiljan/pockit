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
using Pockit.ViewModels;

namespace Pockit 
{
    public sealed class PockitMvxAppStart : MvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;
        
        /// <inheritdoc />
        public PockitMvxAppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
            _navigationService = navigationService;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return _navigationService.Navigate<ProfileViewModel>();
        }
    }
}