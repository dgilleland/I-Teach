using CommonUtilities.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Commands
{
    public class RemoveTopic : CommandWithAggregateRootId
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Duration { get; private set; }

        public RemoveTopic(Guid aggregateRootId, string title, string description, int duration)
        {
            // TODO: Complete member initialization
            Id = aggregateRootId;
            Title = title;
            Description = description;
            Duration = duration;
        }

    }
}
