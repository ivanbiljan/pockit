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
using Org.W3c.Dom;
using Pockit.Core;
using Pockit.Core.DTOs;
using Pockit.Core.Helpers;

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

        public string? Location => string.IsNullOrWhiteSpace(Model.Location) ? null : $"Location: {Model.Location}";
        
        public string? Company => string.IsNullOrWhiteSpace(Model.Company) ? null : $"Company: {Model.Company}";

        public string Followers => StringHelpers.ToAbbreviatedString((ulong) Model.Followers);

        public string Following => StringHelpers.ToAbbreviatedString((ulong) Model.Following);
    }
}