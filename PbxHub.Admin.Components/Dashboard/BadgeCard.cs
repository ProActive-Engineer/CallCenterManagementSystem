using Microsoft.AspNetCore.Components;

namespace PbxHub.Admin.Components.Dashboard
{
    partial class BadgeCard
    {
        [Parameter]
        public string BadgeText { get; set; }
        [Parameter]
        public int BadgeValue { get; set; }
        [Parameter]
        public string BadgeColor { get; set; }
    }
}
