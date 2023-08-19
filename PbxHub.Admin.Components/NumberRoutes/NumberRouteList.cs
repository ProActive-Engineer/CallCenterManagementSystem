using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PbxHub.Common;

namespace PbxHub.Admin.Components.NumberRoutes
{
    public partial class NumberRouteList
    {
        [Parameter]
        public List<NumberRoute> NumberRoutes { get; set; }

        [Parameter]
        public string SearchText { get; set; }

        [Parameter]
        public EventCallback<int> OnNumberRouteDeleted { get; set; }

        private List<NumberRoute> FilteredNumberRoutes { get; set; }

        protected override void OnParametersSet()
        {
            if (SearchText != null && SearchText.Length > 0)
            {
                FilteredNumberRoutes = NumberRoutes.Where(numberRoute => numberRoute.phoneNumber.ToString().ToLower().Contains(SearchText.ToLower())).ToList();
            }
            else
            {
                FilteredNumberRoutes = NumberRoutes;
            }
            base.OnParametersSet();
        }

        private async Task DeleteNumberRoute(int numberRouteId)
        {
            await OnNumberRouteDeleted.InvokeAsync(numberRouteId);
        }
    }
}
