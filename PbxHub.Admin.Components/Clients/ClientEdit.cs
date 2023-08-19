using Microsoft.AspNetCore.Components;
using PbxHub.Common;
using System.Threading.Tasks;

namespace PbxHub.Admin.Components.Clients
{
    public partial class ClientEdit
    {
        [Parameter]
        public Client ClientModel { get; set; }

        [Parameter]
        public EventCallback<Client> OnSaveClient { get; set; }

        [Parameter]
        public EventCallback OnDiscardClient { get; set; }

        private async Task OnSaveHandler()
        {
            await OnSaveClient.InvokeAsync(ClientModel);
        }

        private async Task OnDiscardHandler()
        {
            await OnDiscardClient.InvokeAsync();
        }
    }
}
