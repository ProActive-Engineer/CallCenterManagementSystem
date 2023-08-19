using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System.Net.Http;
using PbxHub.Common;
using Microsoft.AspNetCore.Components.Authorization;
using PbxHub.Admin.App.Services.Middlewares;
using PbxHub.Admin.App.Helpers;

namespace PbxHub.Admin.App.Services
{
    public interface IAccountService
    {
        LoginUser User { get; }
        Task Initialize();
        Task Login(LoginInfo model);
        Task Logout();        
    }

    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        private readonly AuthenticationStateProvider _authenticationStateProvider;


        public LoginUser User { get; private set; }

        public AccountService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<LoginUser>(Constant.STORAGE_ITEM_USER_KEY);
        }

        public async Task Login(LoginInfo model)
        {
            User = await _httpClient.PostJsonAsync<LoginUser>("/api/Login", model);
            await _localStorageService.SetItem(Constant.STORAGE_ITEM_USER_KEY, User);
            (_authenticationStateProvider as CustomAuthenticationProvider).Notify();

        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(Constant.STORAGE_ITEM_USER_KEY);
            _navigationManager.NavigateTo("account/login");
            (_authenticationStateProvider as CustomAuthenticationProvider).Notify();

        }        
    }
}
