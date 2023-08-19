using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PbxHub.Admin.Components.Queues
{
    public partial class QueueMemberList
    {
        [Parameter]
        public List<QueueMember> QueueMembers { get; set; }

        [Parameter]
        public List<User> QueueEligibleMembers { get; set; }

        [Parameter]
        public EventCallback<int> OnQueueMemberDeleted { get; set; }

        [Parameter]
        public EventCallback<List<User>> OnQueueMembersAdded { get; set; }

        [Parameter]
        public EventCallback<QueueMember> OnQueueMemberSaved { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private async Task DeleteQueueMember(int queueMemberId)
        {
            await OnQueueMemberDeleted.InvokeAsync(queueMemberId);
        }

        private async Task ShowQueueMemberEditDlg(QueueMember queueMember)
        {
            var parameters = new DialogParameters { ["MemberName"] = queueMember.fullName, ["MemberPriority"] = queueMember.priority };
            var dialog = DialogService.Show<QueueMemberEditDlg>(null, parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                int prioirty = (int)result.Data;
                queueMember.priority = prioirty;
                await OnQueueMemberSaved.InvokeAsync(queueMember);
            }
        }

        private async Task ShowQueueMemeberAddDlg()
        {
            var parameters = new DialogParameters { ["QueueEligibleUsers"] = QueueEligibleMembers };
            var dialog = DialogService.Show<QueueAddUserDlg>(null, parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                HashSet<User> data = (HashSet<User>)result.Data;
                await OnQueueMembersAdded.InvokeAsync(data.ToList());
            }
        }
    }
}
