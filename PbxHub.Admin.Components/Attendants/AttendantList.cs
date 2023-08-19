using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Components;
using PbxHub.Common;
using MudBlazor;

namespace PbxHub.Admin.Components.Attendants
{
    public partial class AttendantList
    {
        [Parameter]
        public List<AutoAttendant> Attendants { get; set; }

        [Parameter]
        public string SearchText { get; set; }

        [Parameter]
        public EventCallback<int> OnDeleteAttendant { get; set; }

        private List<AutoAttendant> FilteredAttendants { get; set; }
        private MudMessageBox MBox { get; set; }
        private AutoAttendant SelectedAttendant { get; set; }

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredAttendants = Attendants.Where(attendant => attendant.planName.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredAttendants = Attendants;
            }
            base.OnParametersSet();
        }

        private async Task OnDeleteHandler(AutoAttendant attendant)
        {
            SelectedAttendant = attendant;
            bool? result = await MBox.Show();
            if (result != null)
            {
                await OnDeleteAttendant.InvokeAsync(attendant.id);
            }
        }
    }
}
