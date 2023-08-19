using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using PbxHub.Common;

namespace PbxHub.Admin.App.Services
{
    public interface IAttendantService
    {
        Task<IEnumerable<AutoAttendant>> GetAutoAttendants(int clientId);
        Task<IEnumerable<PbxTimeZone>> GetTimeZones();
        Task<IEnumerable<DestinationType>> GetDestinationTypes(int clientId);
        Task<AutoAttendant> GetAutoAttendant(int autoAttendantId);
        Task<AutoAttendant> GetTemplate(int clientId);
        Task<AutoAttendant> CreateAutoAttendant(int clientId, AutoAttendant autoAttendant);
        Task Delete(int autoAttendantId, int clientId);
    }

    public class AttendantService : IAttendantService
    {
        private readonly HttpClient _httpClient;
        public AttendantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AutoAttendant>> GetAutoAttendants(int clientId)
        {
            return await _httpClient.GetJsonAsync<AutoAttendant[]>($"/api/AutoAttendant/GetAutoAttendants/{clientId}");
        }

        public async Task<IEnumerable<PbxTimeZone>> GetTimeZones()
        {
            return await _httpClient.GetJsonAsync<PbxTimeZone[]>($"/api/AutoAttendant/GetTimezones");
        }

        public async Task<IEnumerable<DestinationType>> GetDestinationTypes(int clientId)
        {
            return await _httpClient.GetJsonAsync<DestinationType[]>($"/api/AutoAttendant/GetDestinationTypes/{clientId}");
        }

        public async Task<AutoAttendant> GetAutoAttendant(int autoAttendantId)
        {
            return await _httpClient.GetJsonAsync<AutoAttendant>($"/api/AutoAttendant/GetAutoAttendant/{autoAttendantId}");
        }

        public async Task<AutoAttendant> GetTemplate(int clientId)
        {
            return await _httpClient.GetJsonAsync<AutoAttendant>($"/api/AutoAttendant/GetTemplate/{clientId}");
        }

        public async Task<AutoAttendant> CreateAutoAttendant(int clientId, AutoAttendant autoAttendant)
        {
            return await _httpClient.PostJsonAsync<AutoAttendant>($"/api/AutoAttendant/CreateAutoAttendant/{clientId}", autoAttendant);
        }

        public async Task Delete(int autoAttendantId, int clientId)
        {
            await _httpClient.DeleteAsync($"/api/AutoAttendant/{autoAttendantId}/{clientId}");
        }
    }
}
