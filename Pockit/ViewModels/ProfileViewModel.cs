using System;
using FFImageLoading.Cross;
using Pockit.Core;
using Pockit.Core.Helpers;
using Pockit.Core.Models;

namespace Pockit.ViewModels
{
    public sealed class ProfileViewModel : ViewModelBase<User>
    {
        public string? Company => string.IsNullOrWhiteSpace(Model.Company) ? null : $"Company: {Model.Company}";

        public string Followers => StringHelpers.ToAbbreviatedString((ulong) Model.Followers.TotalCount);

        public string Following => StringHelpers.ToAbbreviatedString((ulong) Model.Following.TotalCount);

        public string Contributions => $"{Model.Contributions.ContributionCalendar.TotalContributions} contributions in the past year";

        public User Model { get; private set; }

        /// <inheritdoc />
        public override void Prepare(User parameter)
        {
            Model = parameter;
        }
    }
}