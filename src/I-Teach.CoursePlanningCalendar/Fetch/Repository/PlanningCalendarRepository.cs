using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Events;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Fetch
{
    internal class PlanningCalendarRepository
        : IPlanningCalendarRepository
        , ISubscribeTo<CalendarCreated>
    {
        #region Constructor
        public PlanningCalendarRepository()
        {
        }
        #endregion

        #region IPlanningCalendar Implementations
        public DraftPlanningCalendar FindDraftPlanningCalendar(Guid id)
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                return context.DraftPlanningCalendars.Find(id);
            }
        }

        public IEnumerable<DraftPlanningCalendar> ListDraftPlanningCalendars()
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                return context.DraftPlanningCalendars.ToList();
            }
        }
        #endregion

        #region DbSet<s>
        #endregion

        public void Handle(CalendarCreated e)
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                DraftPlanningCalendar calendar = new DraftPlanningCalendar()
                {
                    Id = e.Id,
                    CourseName = e.CourseName,
                    CourseNumber = e.CourseNumber
                };
                context.DraftPlanningCalendars.Add(calendar);
                context.SaveChanges();
            }
        }

    }
}
