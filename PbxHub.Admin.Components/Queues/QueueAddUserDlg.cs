using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;


namespace PbxHub.Admin.Components.Queues
{
    public partial class QueueAddUserDlg
    {
        [Parameter]
        public EventCallback<List<User>> OnAddQueueUsers { get; set; }

        [Parameter]
        public List<User> QueueEligibleUsers { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        private List<User> FilteredUsers { get; set; }
        private string SearchText { get; set; }
        private HashSet<User> SelectedUsers { get; set; } = new HashSet<User>();

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredUsers = QueueEligibleUsers.Where(user => user.fullName.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredUsers = QueueEligibleUsers;
            }
            base.OnParametersSet();
        }

        private void OnSearchHandler()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredUsers = QueueEligibleUsers.Where(user => user.fullName.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredUsers = QueueEligibleUsers;
            }
        }

        private void OnClickHandler(string button)
        {
            if (button == "Assign")
            {
                MudDialog.Close(DialogResult.Ok<HashSet<User>>(SelectedUsers));
            }
            if (button == "Cancel")
            {
                SelectedUsers.Clear();
                MudDialog.Cancel();
            }
        }
    }
}