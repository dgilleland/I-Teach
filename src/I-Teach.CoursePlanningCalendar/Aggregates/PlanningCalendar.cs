using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Events;
using I_Teach.CoursePlanningCalendar.Fetch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar.Aggregates
{
    class PlanningCalendar
        : Aggregate
        , IHandleCommand<CreatePlanningCalendar>
        , IHandleCommand<AppendTopic>
        , IApplyEvent<CalendarCreated>

    {
        IPlanningCalendarRepository ReadModel = new PlanningCalendarRepository();

        public System.Collections.IEnumerable Handle(CreatePlanningCalendar c)
        {
            if (c.Id == Guid.Empty)
                throw new InvalidOperationException("Draft Planning Calendar already exists");
            var existing = ReadModel.ListDraftPlanningCalendars();
            foreach (var item in existing)
            {
                if (c.CourseName == item.CourseName)
                    throw new InvalidOperationException("Draft Planning Calendar with the same course name already exists");
                if (c.CourseNumber == item.CourseNumber)
                    throw new InvalidOperationException("Draft Planning Calendar with the same course number already exists");
            }

            // Generate event
            yield return new CalendarCreated()
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    CourseNumber = c.CourseNumber
                };
        }

        public System.Collections.IEnumerable Handle(AppendTopic c)
        {
            if (c.Id == Guid.Empty)
                throw new InvalidOperationException("Draft Planning Calendar has not been loaded");
            if (c.Id != Id)
                throw new InvalidOperationException("Cannot Append Topic - Wrong planning calendar");

            // Generate event
            yield return new TopicAdded()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Duration = c.Duration
            };
        }

        #region Apply Events
        public void Apply(CalendarCreated e)
        {

        }
        #endregion
    }
}
