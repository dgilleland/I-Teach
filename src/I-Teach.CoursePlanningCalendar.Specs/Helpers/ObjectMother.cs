using CommonUtilities.Domain.Commands;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Events;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar.Specs.Helpers
{
    static class ObjectMother
    {
        public static Fixture Generator = new Fixture();

        public static class Commands
        {
            public static CreatePlanningCalendar CreatePlanningCalendar(string courseName = "Enterprise Application Programming",
                       string courseNumber = "EAP 205")
            {
                return new CreatePlanningCalendar(courseName, courseNumber, 90, 3);
            }
            public static AppendTopic AppendTopicCommand(Guid aggregateRootId, string title = "Lorem Ipsum", string description = "Generating meaningless data with Lorem Ipsum", int duration = 1)
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
