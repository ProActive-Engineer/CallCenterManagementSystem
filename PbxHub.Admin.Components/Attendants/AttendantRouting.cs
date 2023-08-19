using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;

namespace PbxHub.Admin.Components.Attendants
{
    public partial class AttendantRouting
    {
        [Parameter]
        public List<DigitRoute> DigitRoutes { get; set; }

        [Parameter]
        public List<DestinationType> DestinationTypes { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private void ShowRoutingDlg(DigitRoute routing)
        {
            var parameters = new DialogParameters { ["RoutingModel"] = routing, ["DestinationTypes"] = DestinationTypes };
            var dialog = DialogService.Show<RoutingEditDlg>(null, parameters);
        }
    }
}
