using System.Threading.Tasks;
using MudBlazor;
using Microsoft.AspNetCore.Components;

namespace PbxHub.Admin.Components.PopUpBoxes
{
    public partial class ConfirmPasswordDlg
    {
        [Parameter]
        public EventCallback<string> OnSubmitClicked { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }


        private string PasswordValue { get; set; }
        private bool IsShowPassword { get; set; }
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Outlined.VisibilityOff;

        protected override void OnParametersSet()
        {
            PasswordValue = null;
        }

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

        private async Task OnClickHandler(string button)
        {
            if (button == "Submit")
            {
                await OnSubmitClicked.InvokeAsync(PasswordValue);                
            }
            if (button == "Cancel")
            {
                MudDialog.Cancel();
            }
        }
    }
}
