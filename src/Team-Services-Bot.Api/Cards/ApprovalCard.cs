﻿// ———————————————————————————————
// <copyright file="ApprovalCard.cs">
// Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>
// <summary>
// Represents a card for an approval.
// </summary>
// ———————————————————————————————
namespace Vsar.TSBot.Cards
{
    using System;
    using Microsoft.Bot.Connector;
    using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi;
    using Resources;

    /// <summary>
    /// Represents a card for an approval.
    /// </summary>
    public class ApprovalCard : HeroCard
    {
        private const string FormatReleaseUrl =
            "https://{0}.visualstudio.com/{1}/_release?definitionId={2}&_a=release-summary&releaseId={3}";

        /// <summary>
        /// Initializes a new instance of the <see cref="ApprovalCard"/> class.
        /// </summary>
        /// <param name="accountName">The name of the account.</param>
        /// <param name="approval">A <see cref="ReleaseApproval"/>.</param>
        /// <param name="teamProject">A team project.</param>
        public ApprovalCard(string accountName, ReleaseApproval approval, string teamProject)
        {
            if (approval == null)
            {
                throw new ArgumentNullException(nameof(approval));
            }

            this.Subtitle = approval.ReleaseReference.Name;
            this.Text = approval.ReleaseEnvironmentReference.Name;
            this.Title = approval.ReleaseDefinitionReference.Name;

            var url = string.Format(FormatReleaseUrl, accountName, teamProject, approval.ReleaseDefinitionReference.Id, approval.ReleaseReference.Id);

            this.Tap = new CardAction(ActionTypes.OpenUrl, value: url);

            this.Buttons.Add(new CardAction(ActionTypes.ImBack, Labels.Approve, value: FormattableString.Invariant($"approve {approval.Id}")));
            this.Buttons.Add(new CardAction(ActionTypes.ImBack, Labels.Reject, value: FormattableString.Invariant($"reject {approval.Id}")));
        }
    }
}