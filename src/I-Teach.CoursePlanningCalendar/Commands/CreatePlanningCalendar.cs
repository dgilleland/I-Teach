using CommonUtilities.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar.Commands
{
    public class CreatePlanningCalendar : CommandWithAggregateRootId
    {
        public string CourseName { get; private set; }
        public string CourseNumber { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePlanningCalendar"/> class.
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="courseNumber"></param>
        public CreatePlanningCalendar(string courseName, string courseNumber)
        {
            if (string.IsNullOrWhiteSpace(courseName))
                throw new ArgumentException("courseName is null or empty.", "courseName");
            if (string.IsNullOrWhiteSpace(courseNumber))
                throw new ArgumentException("courseNumber is null or empty.", "courseNumber");
            CourseName = courseName;
            CourseNumber = courseNumber;
            Id = Guid.NewGuid();
        }
    }
}
