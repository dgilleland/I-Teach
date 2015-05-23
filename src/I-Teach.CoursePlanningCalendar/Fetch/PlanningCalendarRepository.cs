using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Fetch
{
    internal class PlanningCalendarRepository : IPlanningCalendarRepository
    {
        public PlanningCalendarRepository(string connectionStringName)
        {
            // TODO: Build on EF by inheriting DbContext
        }
        public DraftPlanningCalendar FindDraftPlanningCalendar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
