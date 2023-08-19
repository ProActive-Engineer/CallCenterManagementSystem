using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;

namespace PbxHub.Admin.Components.Queues
{
    public partial class QueueMemberEditDlg
    {
        [Parameter]
        public QueueMember QueueMember { get; set; }

        [Parameter]
        public string MemberName { get; set; }

        [Parameter]
        public int MemberPriority { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        private void OnClickHandler(string button)
        {
            if (button == "Submit")
            {
                MudDialog.Close(DialogResult.Ok<int>(MemberPriority));
            }
            if (button == "Cancel")
            {
                MudDialog.Cancel();
            }
        }
    }
}
