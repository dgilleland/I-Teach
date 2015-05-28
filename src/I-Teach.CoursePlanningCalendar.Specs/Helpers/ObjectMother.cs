using CommonUtilities.Domain.Commands;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar.Specs.Helpers
{
    static class ObjectMother
    {
        public static class Commands
        {
            public static CreatePlanningCalendar CreatePlanningCalendar(string courseName = "Enterprise Application Programming",
                       string courseNumber = "EAP 205")
            {
                return new CreatePlanningCalendar(courseName, courseNumber, 90, 3);
            }
            public static CommandWithAggregateRootId CreateTopicCommand(Guid aggregateRootId, string title = null, string description = null, int duration = 0)
            {
                return new AppendTopic(aggregateRootId, title, description, duration);
            }
        }

        public static class Events
        {
            public static CalendarCreated CalendarCreated(CreatePlanningCalendar fromCommand = null)
            {
                if (fromCommand == null) fromCommand = Commands.CreatePlanningCalendar();
                return new CalendarCreated { Id = fromCommand.Id, CourseName = fromCommand.CourseName, CourseNumber = fromCommand.CourseNumber };
            }
        }
    }
}
