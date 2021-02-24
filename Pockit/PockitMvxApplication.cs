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
    /// Represents the MvvmCross startup class. This class acts as a composition root.
    /// </summary>
    public sealed class PockitMvxApplication : MvxApplication 
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            
            RegisterCustomAppStart<PockitMvxAppStart>();
        }
    }
}