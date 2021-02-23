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
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace Pockit 
{
    [Application]
    public class Application : MvxAndroidApplication<MvxAndroidSetup<PockitMvxStartup>, PockitMvxStartup> {
        public Application(nint javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}