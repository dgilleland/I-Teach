using CommonUtilities.Domain.Bus;
using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar.Bus
{
    internal class CommandEventBus : IBus
    {
        private readonly MessageDispatcher Dispatcher;

        public CommandEventBus(MessageDispatcher dispatcher)
        {
            Dispatcher = dispatcher;
            dispatcher.ScanInstance(new PlanningCalendar());
        }

        public void RegisterWithDispatcher(params object[] subscribers)
        {
            foreach (object item in subscribers)
            {
                Dispatcher.ScanInstance(item);
            }
        }

    }
}
