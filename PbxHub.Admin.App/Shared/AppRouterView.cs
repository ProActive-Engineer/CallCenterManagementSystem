using PbxHub.Admin.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;

namespace PbxHub.Admin.App.Shared
{
    public partial class AppRouteView : RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }
        

        protected override void Render(RenderTreeBuilder builder)
        {

            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            if (authorize && AccountService.User == null)
            {
                NavigationManager.NavigateTo("account/login");
            }
            else
            {
                base.Render(builder);
            }
        }       
        
    }
}