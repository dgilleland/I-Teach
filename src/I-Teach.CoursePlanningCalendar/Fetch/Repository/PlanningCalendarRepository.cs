using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Fetch
{
    internal class PlanningCalendarRepository : IPlanningCalendarRepository
    {
        #region Constructor
        private readonly string ConnectionStringName;

        public PlanningCalendarRepository(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
        }
        #endregion

        #region IPlanningCalendar Implementations
        public DraftPlanningCalendar FindDraftPlanningCalendar(Guid id)
        {
            using (var context = new ReadModelDataStore(ConnectionStringName))
            {
                return context.DraftPlanningCalendars.Find(id);
            }
        }
        #endregion

        #region DbSet<s>
        #endregion
    }
}
