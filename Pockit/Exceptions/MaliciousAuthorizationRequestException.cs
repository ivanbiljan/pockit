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

namespace Pockit.Exceptions 
{
    internal sealed class MaliciousAuthorizationRequestException : Exception
    {
        public MaliciousAuthorizationRequestException()
        {
        }

        public MaliciousAuthorizationRequestException(string message) : base(message)
        {
        }

        public MaliciousAuthorizationRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}