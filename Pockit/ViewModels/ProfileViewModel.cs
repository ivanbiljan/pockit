using System;
using Pockit.Core;
using Pockit.Core.Helpers;
using Pockit.Core.Models;

namespace Pockit.ViewModels
{
    public sealed class ProfileViewModel : ViewModelBase<GitHubUser>
    {
        public string? Company => string.IsNullOrWhiteSpace(Model.Company) ? null : $"Company: {Model.Company}";

        public string Followers => StringHelpers.ToAbbreviatedString((ulong) Model.Followers.TotalCount);

        public string Following => StringHelpers.ToAbbreviatedString((ulong) Model.Following.TotalCount);

        public string? Location => string.IsNullOrWhiteSpace(Model.Location) ? null : $"Location: {Model.Location}";

        public GitHubUser Model { get; private set; }

        /// <inheritdoc />
        public override void Prepare(GitHubUser parameter)
        {
            Model = parameter;
        }
    }
}