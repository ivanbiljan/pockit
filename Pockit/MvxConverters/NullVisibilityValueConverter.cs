using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MvvmCross.Converters;

namespace Pockit.MvxConverters
{
    public sealed class NullVisibilityValueConverter : MvxValueConverter<string, string>
    {
        private const string VisibilityGone = "hidden";
        private const string VisibilityVisible = "visible";
        
        /// <inheritdoc />
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(value) ? VisibilityGone : VisibilityVisible;
        }
    }
}