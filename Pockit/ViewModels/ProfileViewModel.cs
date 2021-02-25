using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Pockit.Core;
using Pockit.Core.DTOs;

namespace Pockit.ViewModels 
{
    public sealed class ProfileViewModel : ViewModelBase<GitHubUser>
    {
        private readonly IGitHubApi _gitHubApi;

        public ProfileViewModel(IGitHubApi gitHubApi)
        {
            _gitHubApi = gitHubApi ?? throw new ArgumentNullException(nameof(gitHubApi));
        }
        
        public GitHubUser Model { get; private set; }

        /// <inheritdoc />
        public override void Prepare(GitHubUser parameter)
        {
            Model = parameter;
        }
    }
}