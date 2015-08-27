using I_Teach.CoursePlanningCalendar.Fetch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I_Teach.CoursePlanningCalendar.Web
{
    public class AppProxy
    {
        public I_Teach.SchoolApplication App { get; set; }
        public AppProxy()
        {
            App = I_Teach.SchoolApplication.Instance();
        }

        public static AppProxy Instance()
        {
            return new AppProxy();
        }

        public IEnumerable<DraftPlanningCalendar> ListCalendars()
        {
            var calendars = App.PlanningCalendarRepository.ListDraftPlanningCalendars();

            return calendars;
        }
    }
}