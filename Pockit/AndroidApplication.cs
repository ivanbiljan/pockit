using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace Pockit
{
    [Application]
    public class AndroidApplication
        : MvxAndroidApplication<MvxAndroidSetup<PockitMvxApplicationSetup>, PockitMvxApplicationSetup>
    {
        private static Lazy<Context> _applicationContext = null!;

        public AndroidApplication(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        // TODO: See if there's a better way to do this. Something about this doesn't sit right.

        /// <summary>
        ///     Gets the main application context.
        /// </summary>
        public static Context MainContext => _applicationContext.Value;

        /// <inheritdoc />
        public override void OnCreate()
        {
            base.OnCreate();
            _applicationContext = new Lazy<Context>(ApplicationContext);
        }
    }
}