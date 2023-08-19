using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;

namespace PbxHub.Admin.Components.Queues
{
    public partial class QueueList
    {
        [Parameter]
        public List<Queue> Queues { get; set; }

        [Parameter]
        public string SearchText { get; set; }

        [Parameter]
        public EventCallback<int> OnDeleteQueue { get; set; }

        private List<Queue> FilteredQueues { get; set; }
        private MudMessageBox MBox { get; set; }
        private Queue SelectedQueue { get; set; }

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredQueues = Queues.Where(queue => queue.queueName.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredQueues = Queues;
            }
            base.OnParametersSet();
        }

        private async Task OnDeleteHandlerAsync(int queueId)
        {
            SelectedQueue = Queues.Find(x => x.queueId == queueId);
            bool? result = await MBox.Show();
            if (result != null)
            {
                await OnDeleteQueue.InvokeAsync(queueId);
            }
        }
    }
}
