using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_Teach.CoursePlanningCalendar.Events
{
    public abstract class AbstractEventWithId
    {
        public Guid Id { get; set; }
    }
}
