using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Components;
using PbxHub.Common;

namespace PbxHub.Admin.Components.Clients
{
    public partial class ClientList
    {
        [Parameter]
        public List<Client> Clients { get; set; }

        [Parameter]
        public string SearchText { get; set; }

        [Parameter]
        public EventCallback<int> OnClientDeleted { get; set; }

        private List<Client> FilteredClients { get; set; }

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredClients = Clients.Where(client => client.clientName.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredClients = Clients;
            }
            base.OnParametersSet();
        }

        private async Task DeleteClient(int clientId)
        {
            await OnClientDeleted.InvokeAsync(clientId);
        }
    }
}
