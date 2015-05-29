using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Domain;
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
            , IApplyEvent<CalendarCreated>
        , IHandleCommand<AppendTopic>
            , IApplyEvent<TopicAdded>
        , IHandleCommand<RemoveTopic>
            , IApplyEvent<TopicRemoved>
        , IHandleCommand<ChangeTopic>
            , IApplyEvent<TopicChanged>
        , IHandleCommand<RenameTopic>
            , IApplyEvent<TopicRenamed>
        , IHandleCommand<MoveTopic>
            , IApplyEvent<TopicMoved>

    {
        IPlanningCalendarRepository ReadModel = new PlanningCalendarRepository();

        #region Domain Behaviour
        private List<object> Sequence = new List<object>();
        private Dictionary<TopicName, Topic> TopicList = new Dictionary<TopicName, Topic>();
        private bool TopicExists(TopicName title)
        {
            return TopicList.ContainsKey(title);
        }
        #endregion

        #region Command Handlers
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

            if (TopicExists((TopicName)c.Title))
                throw new InvalidOperationException("A topic by that name already exists on the calendar");

            // Generate event
            yield return new TopicAdded()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Duration = c.Duration
            };
        }

        public System.Collections.IEnumerable Handle(RemoveTopic c)
        {
            yield return new TopicRemoved()
            {
                Id = c.Id,
                Title = c.Title
            };
        }

        public System.Collections.IEnumerable Handle(ChangeTopic c)
        {
            yield return new TopicChanged()
            {
                Id = c.Id,
                Title = c.Title,
                NewDescription = c.NewDescription,
                NewDuration = c.NewDuration
            };
        }

        public System.Collections.IEnumerable Handle(RenameTopic c)
        {
            yield return new TopicRenamed()
            {
                Id = c.Id,
                Title = c.Title,
                NewTitle = c.NewTitle
            };
        }

        public System.Collections.IEnumerable Handle(MoveTopic c)
        {
            yield return new TopicMoved()
            {
                Id = c.Id,
                Title = c.Title,
                Position = c.NewPosition
            };
        }
        #endregion

        #region Apply Events
        public void Apply(CalendarCreated e)
        {

        }

        public void Apply(TopicAdded e)
        {

            TopicList.Add((TopicName)e.Title, new Topic());
        }

        public void Apply(TopicRemoved e)
        {
        }

        public void Apply(TopicChanged e)
        {
            
        }

        public void Apply(TopicRenamed e)
        {
        }

        public void Apply(TopicMoved e)
        {
        }
        #endregion
    }
}
