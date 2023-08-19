using Microsoft.AspNetCore.Components;
using PbxHub.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PbxHub.Admin.Components.Queues
{
    public partial class QueueSetting
    {
        [Parameter]
        public Queue QueueModel { get; set; }

        [Parameter]
        public List<QueueType> QueueTypes { get; set; } = new List<QueueType>();

        [Parameter]
        public EventCallback<Queue> OnSaveQueue { get; set; }

        private async Task OnSaveHandler()
        {
            if (QueueModel.queueId < 1)
            {
                Guid g = Guid.NewGuid();
                QueueModel.queueKey = g.ToString();
                QueueType type = QueueTypes.Find(x => x.queueTypeName == QueueModel.queueTypeName);
                QueueModel.queueTypeId = type.queueTypeId;
                QueueModel.queueTypeName = type.queueTypeName;
            }
            await OnSaveQueue.InvokeAsync(QueueModel);
        }
    }
}
