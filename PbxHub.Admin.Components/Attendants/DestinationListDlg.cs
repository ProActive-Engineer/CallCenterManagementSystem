using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;

namespace PbxHub.Admin.Components.Attendants
{
    public partial class DestinationListDlg
    {
        [Parameter]
        public DigitRoute DigitRouteModel { get; set; }

        [Parameter]
        public List<DestinationType> DestinationTypes { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        private List<DestinationType> FilteredTypes { get; set; }
        private string SearchText { get; set; }

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredTypes = DestinationTypes.Where(type => type.name.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredTypes = DestinationTypes;
            }
            base.OnParametersSet();
        }

        private void OnSearchHandler()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredTypes = DestinationTypes.Where(type => type.name.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredTypes = DestinationTypes;
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
