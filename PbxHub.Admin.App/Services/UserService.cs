using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using PbxHub.Common;

namespace PbxHub.Admin.App.Services
{
    public interface IUserService
    {
        Task<User> GetById(int userId);
        Task Update(int userId, User user);
        Task Delete(int userId);
        Task<User> CreateUser(int clientId, User user);
        Task<IEnumerable<LicenseType>> GetLicenseType();
    }

    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetById(int userId)
        {
            return await _httpClient.GetJsonAsync<User>($"/api/User/{userId}");
        }

        public async Task Update(int userId, User user)
        {
            await _httpClient.PutJsonAsync($"/api/User/{userId}", user);
        }

        public async Task Delete(int userId)
        {
            await _httpClient.DeleteAsync($"/api/User/{userId}");
        }

        public async Task<User> CreateUser(int clientId, User user)
        {
            return await _httpClient.PostJsonAsync<User>($"/api/User/{clientId}", user);
        }

        public async Task<IEnumerable<LicenseType>> GetLicenseType()
        {
            return await _httpClient.GetJsonAsync<LicenseType[]>($"/api/User/GetLicenseType");
        }
    }
}
