using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PbxHub.Admin.Components.Queues
{
    public partial class QueueSupervisorList
    {
        [Parameter]
        public List<QueueSupervisor> QueueSupervisors { get; set; }

        [Parameter]
        public List<User> QueueEligibleSupervisors { get; set; }

        [Parameter]
        public EventCallback<int> OnQueueSupervisorDeleted { get; set; }

        [Parameter]
        public EventCallback<List<User>> OnQueueSupervisorsAdded { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private async Task DeleteQueueSupervisor(int queueSupervisorId)
        {
            await OnQueueSupervisorDeleted.InvokeAsync(queueSupervisorId);
        }

        private async Task ShowQueueSupervisorAddDlgAsync()
        {
            var parameters = new DialogParameters { ["QueueEligibleUsers"] = QueueEligibleSupervisors };
            var dialog = DialogService.Show<QueueAddUserDlg>(null, parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                HashSet<User> data = (HashSet<User>)result.Data;
                await AddQueueSupervisors(data.ToList());
            }
        }

        private async Task AddQueueSupervisors(List<User> users)
        {
            await OnQueueSupervisorsAdded.InvokeAsync(users);
        }
    }
}
