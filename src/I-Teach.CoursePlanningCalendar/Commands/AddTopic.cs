using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Commands
{
    public class AddTopic
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Duration { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTopic"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="duration"></param>
        public AddTopic(string title, string description, int duration)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("title is null or empty.", "title");
            if (duration < 1)
                throw new ArgumentOutOfRangeException("topic duration is less than one class", "duration");
            if (duration > 6)
                throw new ArgumentOutOfRangeException("topic duration is more than six classes", "duration");
            if (string.IsNullOrWhiteSpace(description))
                description = null;
            Title = title;
            Description = description;
            Duration = duration;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTopic"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        public AddTopic(string title, string description)
            : this(title, description, 1)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTopic"/> class.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="duration"></param>
        public AddTopic(string title, int duration)
            : this(title, String.Empty, duration)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTopic"/> class.
        /// </summary>
        /// <param name="title"></param>
        public AddTopic(string title)
            : this(title, String.Empty, 1)
        {
        }
    }
}
