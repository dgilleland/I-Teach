using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Events;
using I_Teach.CoursePlanningCalendar.Fetch.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Fetch
{
    internal class PlanningCalendarRepository
        : IPlanningCalendarRepository
        , ISubscribeTo<CalendarCreated>
        , ISubscribeTo<TopicAdded>
        , ISubscribeTo<TopicRemoved>
    {
        #region Constructor
        public PlanningCalendarRepository()
        {
        }
        #endregion

        #region IPlanningCalendar Implementations
        public DraftPlanningCalendar FindDraftPlanningCalendar(Guid id)
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                return context.DraftPlanningCalendars.Find(id);
            }
        }

        public IEnumerable<DraftPlanningCalendar> ListDraftPlanningCalendars()
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                return context.DraftPlanningCalendars.ToList();
            }
        }

        public IEnumerable<Topic> ListTopics(Guid draftPlanningCalendarId)
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                var topics = context.Topics.Where(x => x.PlanningCalendarId == draftPlanningCalendarId);
                return topics.ToList();
            }
        }
        #endregion

        #region Event Subscribers - persisting to the Read database
        public void Handle(CalendarCreated e)
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                DraftPlanningCalendar calendar = new DraftPlanningCalendar()
                {
                    Id = e.Id,
                    CourseName = e.CourseName,
                    CourseNumber = e.CourseNumber
                };
                context.DraftPlanningCalendars.Add(calendar);
                context.SaveChanges();
            }
        }

        public void Handle(TopicAdded e)
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                Topic topic = new Topic()
                {
                    PlanningCalendarId = e.Id,
                    Title = e.Title,
                    Description = e.Description,
                    Duration = e.Duration
                };
                context.Topics.Add(topic);
                context.SaveChanges();
            }
        }

        public void Handle(TopicRemoved e)
        {
            using (var context = new ReadModelDataStore(About.ConnectionStringName))
            {
                var existing = context.Topics.Single(x => x.Title == e.Title && x.PlanningCalendarId == e.Id);
                context.Topics.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
