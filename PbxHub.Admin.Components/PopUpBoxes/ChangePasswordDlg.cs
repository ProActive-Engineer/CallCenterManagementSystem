using MudBlazor;
using Microsoft.AspNetCore.Components;

namespace PbxHub.Admin.Components.PopUpBoxes
{
    public partial class ChangePasswordDlg
    {
        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        private string CurrentPassword { get; set; }
        private string NewPassword { get; set; }
        private string ConfirmPassword { get; set; }
        private bool IsShowPassword { get; set; }
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Outlined.VisibilityOff;

        private void OnShowPassword()
        {
            if(IsShowPassword)
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

        private void OnClickHandler(string button)
        {
            if (button == "Cancel")
            {
                MudDialog.Cancel();
            }
        }
    }
}
