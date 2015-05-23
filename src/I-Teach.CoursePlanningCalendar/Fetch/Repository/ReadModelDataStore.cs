using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Fetch
{
    internal class ReadModelDataStore : DbContext
    {
        public ReadModelDataStore(string connectionStringName) : base(connectionStringName) { }

        public DbSet<DraftPlanningCalendar> DraftPlanningCalendars { get; set; }
    }
}
