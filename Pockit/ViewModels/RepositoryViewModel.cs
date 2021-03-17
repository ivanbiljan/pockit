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
using Pockit.Core.Models;

namespace Pockit.ViewModels {
    public sealed class RepositoryViewModel : ViewModelBase<Repository> {
        public Repository Model { get; private set; }
        
        /// <inheritdoc />
        public override void Prepare(Repository parameter)
        {
            Model = parameter;
        }
    }
}