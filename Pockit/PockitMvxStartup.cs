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
using MvvmCross.ViewModels;

namespace Pockit 
{
    /// <summary>
    /// Represents the MvvmCross startup class. This class contains core MvvmCross initialization logic; IoC setup, defining entry points etc.
    /// </summary>
    public sealed class PockitMvxStartup : MvxApplication 
    {
        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}