using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using PbxHub.Common;

namespace PbxHub.Admin.App.Services
{
    public interface IClientService
    {
        Task<IEnumerable<User>> GetUsers(int clientId);
        Task<User> AddUser(int clientId, User user);
        Task<IEnumerable<PhoneNumber>> GetPhoneNumbers(int clientId);
        Task<IEnumerable<Queue>> GetQueues(int clientId);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> CreateClient(Client client);
        Task<Client> GetById(int clientId);
        Task Update(int clientId, Client client);
        Task Delete(int clientId);
    }

    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetUsers(int clientId)
        {
            return await _httpClient.GetJsonAsync<User[]>($"/api/Client/GetUsers/{clientId}");
        }

        public async Task<User> AddUser(int clientId, User user)
        {
            return await _httpClient.PostJsonAsync<User>($"/api/Client/AddUser/{clientId}", user);
        }

        public async Task<IEnumerable<PhoneNumber>> GetPhoneNumbers(int clientId)
        {
            return await _httpClient.GetJsonAsync<PhoneNumber[]>($"/api/Client/GetPhoneNumbers/{clientId}");
        }

        public async Task<IEnumerable<Queue>> GetQueues(int clientId)
        {
            return await _httpClient.GetJsonAsync<Queue[]>($"/api/Client/GetQueues/{clientId}");
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _httpClient.GetJsonAsync<Client[]>("/api/Client");
        }

        public async Task<Client> CreateClient(Client client)
        {
            return await _httpClient.PostJsonAsync<Client>($"/api/Client", client);
        }

        public async Task<Client> GetById(int clientId)
        {
            return await _httpClient.GetJsonAsync<Client>($"/api/Client/{clientId}");
        }

        public async Task Update(int clientId, Client client)
        {
            await _httpClient.PutJsonAsync($"/api/Client/{clientId}", client);
        }

        public async Task Delete(int clientId)
        {
            await _httpClient.DeleteAsync($"/api/Client/{clientId}");
        }
    }
}
