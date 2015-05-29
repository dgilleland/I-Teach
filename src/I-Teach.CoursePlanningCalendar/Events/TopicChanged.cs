using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Events
{
    public class TopicChanged : AbstractEventWithId
    {
        public string Title { get; set; }
        public string NewDescription { get; set; }
        public int NewDuration { get; set; }
    }
    public class TopicRenamed : AbstractEventWithId
    {
        public string Title { get; set; }
        public string NewTitle { get; set; }
    }
}
