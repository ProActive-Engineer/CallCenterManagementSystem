using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PbxHub.Common;

namespace PbxHub.Admin.Components.NumberRoutes
{
    public partial class NumberRouteEdit
    {
        [Parameter]
        public NumberRoute NumberRouteModel { get; set; }

        [Parameter]
        public EventCallback<NumberRoute> OnSaveNumberRoute { get; set; }

        [Parameter]
        public EventCallback OnDiscardNumberRoute { get; set; }

        private async Task OnSaveHandler()
        {
            await OnSaveNumberRoute.InvokeAsync(NumberRouteModel);
        }

        private async Task OnDiscardHandler()
        {
            await OnDiscardNumberRoute.InvokeAsync();
        }
    }
}
