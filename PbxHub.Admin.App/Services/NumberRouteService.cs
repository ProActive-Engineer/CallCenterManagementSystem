using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using PbxHub.Common;

namespace PbxHub.Admin.App.Services
{
    public interface INumberRouteService
    {
        Task<IEnumerable<NumberRoute>> GetNumberRoutes(int clientId);
        Task<NumberRoute> GetNumberRoute(int id);
    }
    public class NumberRouteService : INumberRouteService
    {
        private readonly HttpClient _httpClient;

        public NumberRouteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<NumberRoute>> GetNumberRoutes(int clientId)
        {
            return await _httpClient.GetJsonAsync<NumberRoute[]>($"/api/NumberRoute/GetNumberRoutes/{clientId}");
        }

        public async Task<NumberRoute> GetNumberRoute(int id)
        {
            return await _httpClient.GetJsonAsync<NumberRoute>($"/api/NumberRoute/GetNumberRoute/{id}");
        }
    }
}
