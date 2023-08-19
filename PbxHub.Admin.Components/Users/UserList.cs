using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;

namespace PbxHub.Admin.Components.Users
{
    public partial class UserList
    {
        [Parameter]
        public List<User> Users { get; set; }

        [Parameter]
        public string SearchText { get; set; }

        [Parameter]
        public EventCallback<int> OnDeleteUser { get; set; }

        private List<User> FilteredUsers { get; set; }
        private MudMessageBox MBox { get; set; }
        private User SelectedUser { get; set; }

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredUsers = Users.Where(user => user.fullName.ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredUsers = Users;
            }            
        }

        private async Task OnDeleteHandler(int userId)
        {
            SelectedUser = Users.Find(x => x.userId == userId);
            bool? result = await MBox.Show();
            if (result != null)
            {
                await OnDeleteUser.InvokeAsync(userId);
            }
        }
    }
}
