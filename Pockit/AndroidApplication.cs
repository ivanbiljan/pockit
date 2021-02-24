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
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace Pockit 
{
    [Application]
    public class AndroidApplication : MvxAndroidApplication<MvxAndroidSetup<PockitMvxApplicationSetup>, PockitMvxApplicationSetup>
    {
        private static Lazy<Context> _applicationContext = null!;
        
        public AndroidApplication(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public override void OnCreate()
        {
            base.OnCreate();
            _applicationContext = new Lazy<Context>(ApplicationContext);
        }

        // TODO: See if there's a better way to do this. Something about this doesn't sit right.
        
        /// <summary>
        /// Gets the main application context.
        /// </summary>
        public static Context MainContext => _applicationContext.Value;
    }
}