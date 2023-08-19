using Microsoft.AspNetCore.Components.Authorization;
using PbxHub.Admin.App.Helpers;
using PbxHub.Common;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PbxHub.Admin.App.Services.Middlewares
{
	public class CustomAuthenticationProvider : AuthenticationStateProvider
	{
		private readonly ILocalStorageService _localStorageService;

		public LoginUser User { get; private set; }

		public CustomAuthenticationProvider(ILocalStorageService localStorageService)
		{
			_localStorageService = localStorageService;
		}

		public async Task<string> GetTokenAsync()
		{
			User = await _localStorageService.GetItem<LoginUser>(Constant.STORAGE_ITEM_USER_KEY);
			if (User != null)
			{
				if (DateTime.Parse(User.authExpire.ToString()) > DateTime.Now)
				{
					return User.authToken;
				}
				else
				{
					await _localStorageService.RemoveItem(Constant.STORAGE_ITEM_USER_KEY);
				}
			}
			return null;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var token = await GetTokenAsync();
            //token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJmaXJzdE5hbWUiOiJzdHJpbmciLCJsYXN0TmFtZSI6Impkb2VAZGVtby5jb20iLCJlbWFpbCI6InBhc3N3b3JkIiwiYXV0aExldmVsIjoiQWRtaW5pc3RyYXRvciIsImF1dGhFeHBpcmUiOiIyMDIxLTA0LTI2VDE1OjAyOjIyLjI0OVoifQ.h4mEIxyHb22jy5GFYQ0846U62H5MW_NwLQbSkdcI1l0";
            User = await _localStorageService.GetItem<LoginUser>(Constant.STORAGE_ITEM_USER_KEY);

            if (User == null)
            {
                var anonymous = new
                    AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity() { }));
                return anonymous;
            }

            string role = "";
            switch (User.authLevel)
            {
                case 1:
                    role = Helpers.AuthLevel.Administrator.ToString();
                    break;
                case 2:
                    role = Helpers.AuthLevel.CustomerService.ToString();
                    break;
                case 3:
                    role = Helpers.AuthLevel.CustomerAdmin.ToString();
                    break;
                case 4:
                    role = Helpers.AuthLevel.User.ToString();
                    break;
                default:
                    role = "";
                    break;
            }

            // role = "Administrator";
            // role = "User";

            var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, User.firstName),
                new Claim(ClaimTypes.Email, User.email),
                new Claim(ClaimTypes.Role, role)
                }, Constant.CLAIM_AUTH_TYPE);

            /*var identityToken = string.IsNullOrEmpty(token)
                ? new ClaimsIdentity()
                : new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), Constant.CLAIM_AUTH_TYPE);*/

            var userClaimPrincipal = new ClaimsPrincipal(identity);
			var authState = new AuthenticationState(userClaimPrincipal);
			return authState;
		}

		public void Notify()
		{
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}
	}
}
