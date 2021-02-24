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
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Pockit.Core.Services;
using Pockit.Services;

namespace Pockit 
{
    /// <summary>
    /// Represents the MvvmCross setup class. This class performs initial initialization logic and acts as a composition root.
    /// </summary>
    public sealed class PockitMvxApplicationSetup : MvxApplication
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes(typeof(Pockit.Core.IGitHubApi).Assembly).EndingWith("Service").AsInterfaces()
                                                                   .RegisterAsLazySingleton();
            
            RegisterCustomAppStart<PockitMvxAppStart>();
        }
    }
}