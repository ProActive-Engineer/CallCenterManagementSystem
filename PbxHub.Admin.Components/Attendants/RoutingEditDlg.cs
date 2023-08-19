using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;
using System.Collections.Generic;

namespace PbxHub.Admin.Components.Attendants
{
    public partial class RoutingEditDlg
    {
        [Parameter]
        public DigitRoute RoutingModel { get; set; }

        [Parameter]
        public List<DestinationType> DestinationTypes { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private void OnClickHandler(string button)
        {
            if (button == "Cancel")
            {
                MudDialog.Cancel();
            }
        }

        private void ShowDestinationListDlg()
        {
            var parameters = new DialogParameters { ["DestinationTypes"] = DestinationTypes };
            var dialog = DialogService.Show<DestinationListDlg>(null, parameters);
        }
    }
}
