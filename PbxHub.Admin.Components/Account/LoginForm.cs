using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;

namespace PbxHub.Admin.Components.Account
{
    public partial class LoginForm : ComponentBase
    {
        [Parameter]
        public EventCallback<LoginInfo> OnLogined { get; set; }

        private MudForm form { get; set; }
        private bool success { get; set; }

        private LoginInfo model = new LoginInfo();
        private bool IsShowPassword { get; set; }
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Outlined.VisibilityOff;

        private void OnShowPassword()
        {
            if (IsShowPassword)
            {
                IsShowPassword = false;
                PasswordInputIcon = Icons.Material.Outlined.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                IsShowPassword = true;
                PasswordInputIcon = Icons.Material.Outlined.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        private async Task OnSubmit()
        {
            form.Validate();
            if (success)
            {
                try
                {
                    await OnLogined.InvokeAsync(model);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
