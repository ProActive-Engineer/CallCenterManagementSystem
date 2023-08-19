using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PbxHub.Common;
using PbxHub.Admin.Components.PopUpBoxes;
using System.Collections.Generic;
using MudBlazor;

namespace PbxHub.Admin.Components.Users
{
    public partial class UserEdit
    {
        [Parameter]
        public User UserModel { get; set; }

        [Parameter]
        public List<LicenseType> LicenseTypes { get; set; }

        [Parameter]
        public EventCallback<User> OnSaveUser { get; set; }

        [Parameter]
        public EventCallback OnDiscardUser { get; set; }

        [Parameter]
        public EventCallback<int> OnDeleteUser { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private MudMessageBox MBox { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private void ShowDidListDlg()
        {
            var parameters = new DialogParameters { ["Dids"] = UserModel.didList };
            DialogService.Show<DidListsDlg>(null, parameters);
        }

        private void ShowChangeSipPwdDlg()
        {
            DialogService.Show<ChangePasswordDlg>(null);
        }

        private void ShowChangePortalPwdDlg()
        {
            DialogService.Show<ChangePasswordDlg>(null);
        }

        private async Task OnSaveHandler()
        {
            LicenseType type = LicenseTypes.Find(x => x.name == UserModel.licenseTypeName);
            UserModel.licenseType = type;
            await OnSaveUser.InvokeAsync(UserModel);
        }

        private async Task OnDiscardHandler()
        {
            await OnDiscardUser.InvokeAsync();
        }

        private async Task OnDeleteHandler()
        {
            bool? result = await MBox.Show();
            if (result != null)
            {
                await OnDeleteUser.InvokeAsync(UserModel.userId);
            }
        }

        private void OnSendMailHandler()
        {

        }
    }
}
