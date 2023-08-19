using Microsoft.AspNetCore.Components;
using MudBlazor;
using PbxHub.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PbxHub.Admin.Components.Attendants
{
    public partial class OpenHoursDlg
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public OpenHours OpenHoursModel { get; set; }

        [Parameter]
        public EventCallback<OpenHours> SubmitChanged { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        private Dictionary<int, bool> DayChecked { get; set; }

        private TimeSpan? startTimeSpan { get; set; }
        private TimeSpan? endTimeSpan { get; set; }

        protected override void OnParametersSet()
        {
            if (OpenHoursModel == null)
            {
                OpenHoursModel = new OpenHours();
            }
            startTimeSpan = GetTimeSpan(OpenHoursModel.startTime);
            endTimeSpan = GetTimeSpan(OpenHoursModel.endTime);
            InitDayChecked();
        }

        private void InitDayChecked(bool bClear = false)
        {
            DayChecked = new Dictionary<int, bool>();

            DayChecked[DayOfWeek.Sunday.GetHashCode()] = false;
            DayChecked[DayOfWeek.Monday.GetHashCode()] = false;
            DayChecked[DayOfWeek.Tuesday.GetHashCode()] = false;
            DayChecked[DayOfWeek.Wednesday.GetHashCode()] = false;
            DayChecked[DayOfWeek.Thursday.GetHashCode()] = false;
            DayChecked[DayOfWeek.Friday.GetHashCode()] = false;
            DayChecked[DayOfWeek.Saturday.GetHashCode()] = false;

            if (bClear)
            {
                return;
            }

            for (int i = OpenHoursModel.startDay.GetHashCode(); i <= OpenHoursModel.endDay.GetHashCode(); i++)
            {
                DayChecked[i] = true;
            }
        }

        private void OnSubmitChanged()
        {
            OpenHoursModel.startTime = GetDateTimeFromTimespan(startTimeSpan.Value);
            OpenHoursModel.endTime = GetDateTimeFromTimespan(endTimeSpan.Value);
            MudDialog.Close(DialogResult.Ok<OpenHours>(OpenHoursModel));            
        }

        private void OnClickHandler(string button)
        {
            if (button == "Clear")
            {
                startTimeSpan = new TimeSpan(0, 0, 0);
                endTimeSpan = new TimeSpan(0, 0, 0);
                InitDayChecked(true);
            }
            if (button == "Cancel")
            {
                MudDialog.Cancel();
            }
        }

        private string GetDateTimeFromTimespan(TimeSpan value)
        {
            DateTime curDate = DateTime.Today + value;
            try
            {
                return curDate.ToString("yyyy-MM-ddTHH:mm");
            }
            catch (Exception ex)
            {
                return curDate.ToString("yyyy-MM-ddTHH:mm");
            }
        }

        private TimeSpan GetTimeSpan(string time)
        {            
            try
            {
                DateTime timeValue;
                DateTime.TryParse(time, out timeValue);
                return timeValue.TimeOfDay;
            }
            catch (Exception ex)
            {
                return new TimeSpan(0, 0, 0);
            }
        }

        private void OnCheckChanged(DayOfWeek day)
        {
            if (day < OpenHoursModel.startDay)
            {
                OpenHoursModel.startDay = day;
            }
            if (day > OpenHoursModel.endDay)
            {
                OpenHoursModel.endDay = day;
            }
            else
            {
                if (day - OpenHoursModel.startDay <= OpenHoursModel.endDay - day )
                {
                    OpenHoursModel.startDay = day;
                }
                else
                {
                    OpenHoursModel.endDay = day;
                }
            }
            InitDayChecked();
        }
    }
}
