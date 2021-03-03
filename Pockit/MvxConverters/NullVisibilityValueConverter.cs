using System;
using System.Globalization;
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