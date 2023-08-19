using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;

namespace PbxHub.Admin.Components.PopUpBoxes
{
    public partial class DidListsDlg
    {
        [Parameter]
        public List<Did> Dids { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        private List<Did> FilteredDids { get; set; }
        private string SearchText { get; set; }

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredDids = Dids.Where(did => did.phoneNumber.ToString().ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredDids = Dids;
            }
            base.OnParametersSet();
        }

        private void OnSearchHandler()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredDids = Dids.Where(did => did.phoneNumber.ToString().ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredDids = Dids;
            }
        }

        private void OnClickHandler(string button)
        {
            if (button == "Cancel")
            {
                MudDialog.Cancel();
            }
        }
    }
}
