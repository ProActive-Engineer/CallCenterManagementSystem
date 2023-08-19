using Microsoft.AspNetCore.Components;


namespace PbxHub.Admin.App.Shared
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("account/login");
        }
    }
}
