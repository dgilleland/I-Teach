using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Domain
{
    abstract class CalendarItem
    {
        public string Name { get; private set; }
        public CalendarItem(string name)
        {
            Name = name;
        }
    }
}
