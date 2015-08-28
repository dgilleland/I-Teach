using CommonUtilities.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Commands
{
    public class MoveTopic : CommandWithAggregateRootId
    {
        public string Title { get; set; }
        public int NewPosition { get; set; }

        public MoveTopic(Guid aggregateRootId, string title, int newPosition)
        {
            Id = aggregateRootId;
            Title = title;
            NewPosition = newPosition;
        }
    }
    [Obsolete("Phase out in favor or ReplaceTopic")]
    public class RenameTopic : CommandWithAggregateRootId
    {
        public string Title { get; private set; }
        public string NewTitle { get; private set; }

        public RenameTopic(Guid aggregateRootId, string title, string newTitle)
        {
            Id = aggregateRootId;
            Title = title;
            NewTitle = newTitle;
        }
    }
    public class ReplaceTopic : CommandWithAggregateRootId
    {
        public string Title { get; private set; }
        public string NewDescription { get; private set; }
        public int NewDuration { get; private set; }
        public int Sequence { get; set; }

        public ReplaceTopic(Guid aggregateRootId, string title, string description, int duration, int sequence)
        {
            // TODO: Complete member initialization
            Id = aggregateRootId;
            Title = title;
            NewDescription = description;
            NewDuration = duration;
        }
    }
    public class AppendTopic : CommandWithAggregateRootId
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Duration { get; private set; }

        public AppendTopic(Guid aggregateRootId, string title, string description, int duration)
        {
            if (aggregateRootId == Guid.Empty)
                throw new ArgumentException("planning calendar id is empty", "aggregateRootId");
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("title is null or empty.", "title");
            if (duration < 1)
                throw new ArgumentOutOfRangeException("topic duration is less than one class", "duration");
            if (duration > 6)
                throw new ArgumentOutOfRangeException("topic duration is more than six classes", "duration");
            if (string.IsNullOrWhiteSpace(description))
                description = null;
            Id = aggregateRootId;
            Title = title;
            Description = description;
            Duration = duration;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTopic"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public AppendTopic(Guid aggregateRootId, string title, string description)
            : this(aggregateRootId, title, description, 1)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTopic"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="duration"></param>
        public AppendTopic(Guid aggregateRootId, string title, int duration)
            : this(aggregateRootId, title, String.Empty, duration)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTopic"/> class.
        /// </summary>
        /// <param name="title"></param>
        public AppendTopic(Guid aggregateRootId, string title)
            : this(aggregateRootId, title, String.Empty, 1)
        {
        }
    }
}
