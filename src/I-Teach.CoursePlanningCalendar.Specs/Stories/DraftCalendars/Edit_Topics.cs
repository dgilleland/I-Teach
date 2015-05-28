using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;
using OM = I_Teach.CoursePlanningCalendar.Specs.Helpers.ObjectMother;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    [Story(AsA = Actor.CourseCoordinator,
            IWant = "I Want to edit the list of topics",
            SoThat = "So as to plan the topics to cover in class")]
    public class Edit_Topics 
        : Abstract_Story
        , ISubscribeTo<TopicAdded>
        , ISubscribeTo<TopicChanged>
        , ISubscribeTo<TopicRemoved>
        , ISubscribeTo<TopicsReordered>
    {
        public Edit_Topics()
        {
        }

        #region Scenarios
        private TopicAdded Actual_TopicAdded_Event;
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Add_a_topic()
        {
            string title = "Lorem Ipsum";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent tristique.";
            int duration = 2;
            this.Given(_ => GivenADraftCalendar())
                .And(_=>GivenAnAddTopicCommand(title, description, duration))
                .When(_=>WhenIAddTheTopic())
                .Then(_=>ThenATopicAddedEventOccurs())
                .And(_=>ThenTheTopicAppearsAsTheLastTopicOnTheCalendar(title, description, duration))
                .BDDfy();
        }

        private TopicChanged Actual_TopicChanged_Event;
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Change_a_topic()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        private TopicRemoved Actual_TopicRemoved_Event;
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Remove_a_topic()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        private TopicsReordered Actual_TopicsReordered_Event;
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Reorder_topics()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        public void TBA() { throw new NotImplementedException(); }
        #endregion

        #region Event Subscribers
        public void Handle(TopicAdded e)
        {
            Actual_TopicAdded_Event = e;
        }

        public void Handle(TopicChanged e)
        {
            Actual_TopicChanged_Event = e;
        }

        public void Handle(TopicRemoved e)
        {
            Actual_TopicRemoved_Event = e;
        }

        public void Handle(TopicsReordered e)
        {
            Actual_TopicsReordered_Event = e;
        }
        #endregion

        #region Givens
        private void GivenADraftCalendar()
        {
            var createCommand = OM.Commands.CreatePlanningCalendar();
            AggregateRootId = createCommand.Id;
        }
        private void GivenAnAddTopicCommand(string title, string description, int duration)
        {
            Command = OM.Commands.AppendTopicCommand(AggregateRootId, title, description, duration);
        }
        #endregion

        #region Whens
        private void WhenIAddTheTopic()
        {
            sut.Process(Command as AppendTopic);
        }
        #endregion

        #region Thens
        private void ThenATopicAddedEventOccurs()
        {
            Assert.NotNull(Actual_TopicAdded_Event);
        }

        private void ThenTheTopicAppearsAsTheLastTopicOnTheCalendar(string title, string description, int duration)
        {
            var topics = sut.PlanningCalendarRepository.ListTopics(AggregateRootId);
            var actual = topics.LastOrDefault();

            Assert.NotNull(actual);
            Assert.Equal(AggregateRootId, actual.PlanningCalendarId);
            Assert.Equal(title, actual.Title);
            Assert.Equal(description, actual.Description);
            Assert.Equal(duration, actual.Duration);
        }
        #endregion
    }
}
