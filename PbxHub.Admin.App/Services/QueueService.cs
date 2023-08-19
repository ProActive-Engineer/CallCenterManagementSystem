using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using PbxHub.Common;

namespace PbxHub.Admin.App.Services
{
    public interface IQueueService
    {
        Task<IEnumerable<QueueMember>> GetMembers(int queueId);
        Task<IEnumerable<User>> GetEligibleMembers(int queueId);
        Task<IEnumerable<QueueMember>> AddEligibleMembers(int queueId, User[] users);
        Task<IEnumerable<QueueSupervisor>> GetSupervisors(int queueId);
        Task<IEnumerable<User>> GetEligibleSupervisors(int queueId);
        Task<IEnumerable<QueueSupervisor>> AddEligibleSupervisors(int queueId, User[] users);
        Task DeleteSupervisor(int supervisorId);
        Task<Queue> GetById(int queueId);
        Task Delete(int queueId);
        Task Update(int queueId, Queue queue);
        Task<Queue> AddNewQueue(int clientId, Queue queue);
        Task DeleteMember(int memberId);
        Task<IEnumerable<QueueType>> GetQueueTypes();
    }

    public class QueueService : IQueueService
    {
        private readonly HttpClient _httpClient;

        public QueueService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<QueueMember>> GetMembers(int queueId)
        {
            return await _httpClient.GetJsonAsync<QueueMember[]>($"/api/Queue/GetMembers/{queueId}");
        }

        public async Task<IEnumerable<User>> GetEligibleMembers(int queueId)
        {
            return await _httpClient.GetJsonAsync<User[]>($"/api/Queue/GetEligibleMembers/{queueId}");
        }

        public async Task<IEnumerable<QueueMember>> AddEligibleMembers(int queueId, User[] users)
        {
            return await _httpClient.PostJsonAsync<QueueMember[]>($"/api/Queue/AddEligibleMembers/{queueId}", users);
        }

        public async Task<IEnumerable<QueueSupervisor>> GetSupervisors(int queueId)
        {
            return await _httpClient.GetJsonAsync<QueueSupervisor[]>($"/api/Queue/GetSupervisors/{queueId}");
        }

        public async Task<IEnumerable<User>> GetEligibleSupervisors(int queueId)
        {
            return await _httpClient.GetJsonAsync<User[]>($"/api/Queue/GetEligibleSupervisors/{queueId}");
        }

        public async Task<IEnumerable<QueueSupervisor>> AddEligibleSupervisors(int queueId, User[] users)
        {
            return await _httpClient.PostJsonAsync<QueueSupervisor[]>($"/api/Queue/AddEligibleSupervisors/{queueId}", users);
        }

        public async Task DeleteSupervisor(int supervisorId)
        {
            await _httpClient.DeleteAsync($"/api/Queue/DeleteSupervisor/{supervisorId}");
        }

        public async Task<Queue> GetById(int queueId)
        {
            return await _httpClient.GetJsonAsync<Queue>($"/api/Queue/{queueId}");
        }

        public async Task Delete(int queueId)
        {
            await _httpClient.DeleteAsync($"/api/Queue/{queueId}");
        }

        public async Task Update(int queueId, Queue queue)
        {
            await _httpClient.PutJsonAsync($"/api/Queue/{queueId}", queue);
        }

        public async Task<Queue> AddNewQueue(int clientId, Queue queue)
        {
            return await _httpClient.PostJsonAsync<Queue>($"/api/Queue/AddNewQueue/{clientId}", queue);
        }

        public async Task DeleteMember(int memberId)
        {
            await _httpClient.DeleteAsync($"/api/Queue/DeleteMember/{memberId}");
        }

        public async Task<IEnumerable<QueueType>> GetQueueTypes()
        {
            return await _httpClient.GetJsonAsync<QueueType[]>($"/api/Queue/GetQueueTypes");
        }
    }
}
