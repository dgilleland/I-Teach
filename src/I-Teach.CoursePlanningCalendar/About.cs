using CommonUtilities.Domain.Bus;
using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Bus;
using I_Teach.CoursePlanningCalendar.Fetch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar
{
    public sealed class About
    {
        private static IBus CommandEventBus = null;
        public static IBus GetCommandEventBus(MessageDispatcher dispatcher)
        {
            if(CommandEventBus == null)
                CommandEventBus = new CommandEventBus(dispatcher);
            return CommandEventBus;
        }

        // TODO: Fix this, as it's likely a "weak link" configuration that depends on SchoolApplication calling this method.
        internal static string ConnectionStringName { get; private set; }
        public static IPlanningCalendarRepository GetPlanningCalendarRepository(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
            return new PlanningCalendarRepository();
        }
    }
}
