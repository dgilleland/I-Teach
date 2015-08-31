using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Domain
{
    class Topic : CalendarItem
    {
        public TopicName Title { get; private set; }
        public string Description { get; private set; }
        public double Duration { get; private set; }
        public Topic(TopicName title, string description, double duration) : base(title)
        {
            Title = title;
            Description = description;
            Duration = duration;
        }
    }
}
