using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Domain;
using I_Teach.CoursePlanningCalendar.Events;
using I_Teach.CoursePlanningCalendar.Fetch;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace I_Teach.CoursePlanningCalendar.Aggregates
{
    class PlanningCalendar
        : Aggregate
        , IHandleCommand<CreatePlanningCalendar>
            , IApplyEvent<CalendarCreated>
        , IHandleCommand<SchedulePlanningCalendar>
            , IApplyEvent<PlanningCalendarScheduled>
        , IHandleCommand<AppendTopic>
            , IApplyEvent<TopicAdded>
            , IApplyEvent<SequenceChanged>
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
        private OrderedDictionary CalendarItems; // TODO: Probably can find/make a better option than an ordered dictionary. Ideally, I would like an OrderedDictionary<T>...

        private string[] GetCalendarItemsSequence()
        {
            return CalendarItems.Keys.Cast<string>().ToArray();
        }
        private bool TopicExists(string name)
        {
            return CalendarItems[name] != null;
        }

        private void AppendCalendarItem(Topic item)
        {
            CalendarItems.Add(item.Name, item);
        }

        private int GetIndexByName(string name)
        {
            int index = 0;
            while (((CalendarItem)CalendarItems[index]).Name != name)
                index++;
            return index;
        }

        private void ChangeCalendarItem(string keyName, string newDescription, int newDuration)
        {
            int index = GetIndexByName(keyName);
            RemoveCalendarItem(keyName);
            CalendarItems.Insert(index, keyName, new Topic((TopicName)keyName, newDescription, newDuration));
        }
        private void RemoveCalendarItem(string title)
        {
            CalendarItems.Remove(title);
        }
        private void RenameCalendarItem(string title, string newTitle)
        {
            var index = GetIndexByName(title);
            var item = CalendarItems[title] as Topic;
            CalendarItems.Insert(index, newTitle, new Topic((TopicName)newTitle, item.Description, item.Duration));
        }
        private void RePositionTopic(string title, int position)
        {
            // TODO: I know the logic here is a bit flakey, but I'll address it when I run into problems.....
            var item = CalendarItems[title] as Topic;
            CalendarItems.RemoveAt(GetIndexByName(title));
            CalendarItems.Insert(position, title, item); 
        }
        #endregion

        // TODO: Consider moving this into the base class.....
        private void TryToDo<T>(Action<T> eventProcessor, T eventObj)
        {
            try 
	        {
                eventProcessor(eventObj);
	        }
	        catch (Exception e)
	        {
                throw new InvalidOperationException("Unable to process the command - rhe resulting event cannot be applied: " + e.Message, e);
	        }
        }

        #region Command Handlers
        public IEnumerable Handle(CreatePlanningCalendar c)
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
            CalendarCreated newCalendarCreated = new CalendarCreated()
                            {
                                Id = c.Id,
                                CourseName = c.CourseName,
                                CourseNumber = c.CourseNumber,
                                TotalHours = c.TotalHours,
                                ClassesPerWeek = c.ClassesPerWeek
                            };
            // Process the event
            TryToDo<CalendarCreated>(Apply, newCalendarCreated);

            // Return applied event for other subscribers
            yield return newCalendarCreated;
        }

        public IEnumerable Handle(SchedulePlanningCalendar c)
        {
            // Generate event
            PlanningCalendarScheduled theEvent = new PlanningCalendarScheduled()
            {
                CalendarId = c.Id,
                Year = c.Year,
                Month = c.Term
            };
            // Process the event


            // Return the event for other subscribers
            yield return theEvent;
        }

        public IEnumerable Handle(AppendTopic c)
        {
            if (c.Id == Guid.Empty)
                throw new InvalidOperationException("Draft Planning Calendar has not been loaded");
            if (c.Id != Id)
                throw new InvalidOperationException("Cannot Append Topic - Wrong planning calendar");

            if (TopicExists(c.Title))
                throw new InvalidOperationException("Cannot Append Topic - An item by that name already exists on the calendar");

            // Generate event
            TopicAdded newTopicAdded = new TopicAdded()
                        {
                            Id = c.Id,
                            Title = c.Title,
                            Description = c.Description,
                            Duration = c.Duration
                        };
            // Process the event
            TryToDo<TopicAdded>(Apply, newTopicAdded);

            // Return applied event for other subscribers
            yield return newTopicAdded;
            yield return new SequenceChanged()
            {
                Id = c.Id,
                Sequence = GetCalendarItemsSequence()
            };
        }

        public IEnumerable Handle(RemoveTopic c)
        {
            yield return new TopicRemoved()
            {
                Id = c.Id,
                Title = c.Title
            };
            yield return new SequenceChanged()
            {
                Id = c.Id,
                Sequence = GetCalendarItemsSequence()
            };
        }

        public IEnumerable Handle(ChangeTopic c)
        {
            yield return new TopicChanged()
            {
                Id = c.Id,
                Title = c.Title,
                NewDescription = c.NewDescription,
                NewDuration = c.NewDuration
            };
        }

        public IEnumerable Handle(RenameTopic c)
        {
            yield return new TopicRenamed()
            {
                Id = c.Id,
                Title = c.Title,
                NewTitle = c.NewTitle
            };
            yield return new SequenceChanged()
            {
                Id = c.Id,
                Sequence = GetCalendarItemsSequence()
            };
        }

        public IEnumerable Handle(MoveTopic c)
        {
            // 0) Validate that the command can be processed

            // 1) Create the event object
            TopicMoved newTopicMoved = new TopicMoved()
                        {
                            Id = c.Id,
                            Title = c.Title,
                            Position = c.NewPosition
                        };

            // 2) Process the command by trying to do the event
            TryToDo<TopicMoved>(Apply, newTopicMoved);

            // 3) Return the event (and any ancillary events)
            yield return newTopicMoved;
            yield return new SequenceChanged()
            {
                Id = c.Id,
                Sequence = GetCalendarItemsSequence()
            };
        }
        #endregion

        #region Apply Events
        public void Apply(CalendarCreated e)
        {
            CalendarItems = new OrderedDictionary();
        }

        public void Apply(TopicAdded e)
        {
            AppendCalendarItem(new Topic((TopicName) e.Title, e.Description, e.Duration));
        }

        public void Apply(TopicRemoved e)
        {
            RemoveCalendarItem(e.Title);
        }

        public void Apply(TopicChanged e)
        {
            ChangeCalendarItem(e.Title, e.NewDescription, e.NewDuration);
        }

        public void Apply(TopicRenamed e)
        {
            RenameCalendarItem(e.Title, e.NewTitle);
        }

        public void Apply(TopicMoved e)
        {
            RePositionTopic(e.Title, e.Position);
        }

        public void Apply(SequenceChanged e)
        {
            // no-op...
        }

        public void Apply(PlanningCalendarScheduled e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
