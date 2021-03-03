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
        public AndroidApplication(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}