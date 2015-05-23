using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar.Aggregates
{
    class PlanningCalendar 
        : Aggregate
        , IHandleCommand<CreatePlanningCalendar>

    {
        public System.Collections.IEnumerable Handle(CreatePlanningCalendar c)
        {
            yield return new CalendarCreated();
        }
    }
}
