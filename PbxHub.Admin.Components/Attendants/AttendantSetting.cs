using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PbxHub.Admin.Components.PopUpBoxes;

namespace PbxHub.Admin.Components.Attendants
{
    public partial class AttendantSetting
    {
        [Parameter]
        public AutoAttendant AttendantModel { get; set; }

        [Parameter]
        public bool TTSForGreeting { get; set; }

        [Parameter]
        public List<PbxTimeZone> PbxTimeZones { get; set; }

        [Parameter]
        public EventCallback<AutoAttendant> OnSaveAutoAttendant { get; set; }

        [Parameter]
        public EventCallback<AutoAttendant> OnDiscardAntoAttendant { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        private string SelectedTimezoneName { get; set; }

        protected override void OnParametersSet()
        {
            if (AttendantModel != null && AttendantModel.timeZone != null)
            {
                SelectedTimezoneName = AttendantModel.timeZone.standardName;
            }
        }

        private async Task OnSubmitHandler()
        {
            AttendantModel.timeZone = PbxTimeZones.FirstOrDefault(tz => tz.standardName == SelectedTimezoneName);
            AttendantModel.ttsForOpenGreeting = TTSForGreeting;
            AttendantModel.ttsForClosedGreeting = TTSForGreeting;

            if (TTSForGreeting)
            {
                AttendantModel.openGreetingSoundFileName = null;
                AttendantModel.closedGreetingSoundFileName = null;
            }
            else
            {
                AttendantModel.openGreetingText = null;
                AttendantModel.closedGreetingText = null;
            }

            await OnSaveAutoAttendant.InvokeAsync(AttendantModel);
        }

        private async Task OnCancelHandler()
        {
            await OnDiscardAntoAttendant.InvokeAsync();
        }

        private async Task ShowOpenHoursDlg(string title, OpenHours openHours, int index = 1)
        {
            var parameters = new DialogParameters { ["Title"] = title, ["OpenHoursModel"] = openHours };
            IDialogReference dialog = DialogService.Show<OpenHoursDlg>(null, parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OpenHours openHoursModel = (OpenHours)result.Data;
                SetOpenHours(openHoursModel, index);
            }
        }

        private string OpenHoursString(OpenHours openHours)
        {
            if (openHours != null)
            {
                string startDayStr = openHours.startDay.ToString();
                DateTime startTime;
                DateTime.TryParse(openHours.startTime, out startTime);
                string startTimeStr = startTime.ToString("hh:mm tt");
                string endDayStr = openHours.endDay.ToString();
                DateTime endTime;
                DateTime.TryParse(openHours.endTime, out endTime);
                string endTimeStr = endTime.ToString("hh:mm tt");
                return startDayStr + " - " + endDayStr + " " + startTimeStr + " to " + endTimeStr;
            }
            return null;            
        }

        private void SetOpenHours(OpenHours openHours, int curOpenHoursId)
        {
            switch (curOpenHoursId)
            {
                case 1:
                    AttendantModel.openHours1 = openHours;
                    break;
                case 2:
                    AttendantModel.openHours2 = openHours;
                    break;
                case 3:
                    AttendantModel.openHours3 = openHours;
                    break;
                default:
                    break;
            }
        }

        private void ShowDidListDlg()
        {
            var parameters = new DialogParameters { ["Dids"] = AttendantModel.didList };
            DialogService.Show<DidListsDlg>(null, parameters);
        }
    }
}
