using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using PbxHub.Common;

namespace PbxHub.Admin.App.Services
{
    public interface IQueueMemberService
    {
        Task<QueueMember> GetById(int memberId);
        Task Update(int memberId, QueueMember queueMember);
        Task Delete(int memberId);
        Task<QueueMember> CreateMember(QueueMember queueMember);
    }

    public class QueueMemberService : IQueueMemberService
    {
        private readonly HttpClient _httpClient;

        public QueueMemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<QueueMember> GetById(int memberId)
        {
            return await _httpClient.GetJsonAsync<QueueMember>($"/api/QueueMember/{memberId}");
        }

        public async Task Update(int memberId, QueueMember queueMember)
        {
            await _httpClient.PutJsonAsync($"/api/QueueMember/{memberId}", queueMember);
        }

        public async Task Delete(int memberId)
        {
            await _httpClient.DeleteAsync($"/api/QueueMember/{memberId}");
        }

        public async Task<QueueMember> CreateMember(QueueMember queueMember)
        {
            return await _httpClient.PostJsonAsync<QueueMember>($"/api/QueueMember", queueMember);
        }
    }
}
