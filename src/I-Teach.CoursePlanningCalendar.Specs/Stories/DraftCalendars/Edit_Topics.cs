using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Ploeh.AutoFixture; // needed for the AutoFixture extension method .Create()
using Xunit;
using Xunit.Extensions;
using OM = I_Teach.CoursePlanningCalendar.Specs.Helpers.ObjectMother;
using I_Teach.CoursePlanningCalendar.Fetch.Model;

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
        [Theory, AutoRollback]
        [InlineData(0)]
        [InlineData(4)]
        [Trait("Context", "Acceptance Test")]
        public void Add_a_topic(int existingTopicCount)
        {
            string title = "Lorem Ipsum";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent tristique.";
            int duration = 2;
            this.Given(_=> GivenADraftCalendarHasBeenCreated())
                .And(_=>PreviousTopicsWereAppended(existingTopicCount))
                .And(_=>AnAddTopicCommand(title, description, duration))
                .When(_=>AddingTheTopic())
                .Then(_=>ThenATopicAddedEventOccurs())
                .And(_=>TheTopicAppearsAsTheLastTopicOnTheCalendar(title, description, duration))
                .BDDfy();
        }

        private TopicChanged Actual_TopicChanged_Event;
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Change_a_topic()
        {
            string title = "Lorem Ipsum";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent tristique.";
            int duration = 2;
            this.Given(_ => GivenADraftCalendarHasBeenCreated())
                .And(_ => AnAddTopicCommand(title, description, duration))
                .And(_ => AddingTheTopic())
                .When(_ => ChangingTheTopic(title, description, duration))
                .And(_=> ThenATopicChangedEventOccurs())
                .And(_ => TheTopicExistsInTheCalendar(title, description, duration))
                .BDDfy();
        }

        private TopicRemoved Actual_TopicRemoved_Event;
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Remove_a_topic()
        {
            string title = "Lorem Ipsum";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent tristique.";
            int duration = 2;
            this.Given(_ => GivenADraftCalendarHasBeenCreated())
                .And(_ => AnAddTopicCommand(title, description, duration))
                .And(_ => AddingTheTopic())
                .When(_ => RemovingTheTopic())
                .Then(_=>ThenARemoveTopicEventOccurs())
                .And(_=>TheTopicDoesNotAppearOnTheCalendar(title))
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

        #region Alternate Scenarios
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Reject_Duplicate_Topics()
        {
            string title = "Lorem Ipsum";
            string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent tristique.";
            int duration = 2;
            this.Given(_ => GivenADraftCalendarHasBeenCreated())
                .And(_ => AnAddTopicCommand(title, description, duration))
                .And(_ => AddingTheTopic())
                .When(_=>AddingTheTopicWithExpectedException())
                .Then(_=>ThenTheExpectedExceptionOccurs())
                .BDDfy();
        }

        #endregion
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
        private void PreviousTopicsWereAppended(int existingTopicCount)
        {
            while (existingTopicCount > 0)
            {
                var aCommand = OM.Commands.AppendTopicCommand(AggregateRootId, OM.Generator.Create("Title "), OM.Generator.Create("Description "));
                sut.Process(aCommand);
                existingTopicCount--;
            }
        }

        private void AnAddTopicCommand(string title, string description, int duration)
        {
            Command = OM.Commands.AppendTopicCommand(AggregateRootId, title, description, duration);
        }
        #endregion

        #region Whens
        private void AddingTheTopic()
        {
            sut.Process(Command as AppendTopic);
        }
        private void ChangingTheTopic(string title, string description, int duration)
        {
            Command = OM.Commands.ChangeTopicCommand(AggregateRootId, title, description, duration);
            sut.Process(Command as ChangeTopic);
        }
        private void RemovingTheTopic()
        {
            var appendCommand = Command as AppendTopic;
            Command = OM.Commands.RemoveTopicCommand(AggregateRootId, appendCommand.Title, appendCommand.Description, appendCommand.Duration);
            sut.Process(Command as RemoveTopic);
        }
        private void AddingTheTopicWithExpectedException()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Thens
        #region Event Checks
        private void ThenATopicAddedEventOccurs()
        {
            Assert.NotNull(Actual_TopicAdded_Event);
        }
        private void ThenATopicChangedEventOccurs()
        {
            Assert.NotNull(Actual_TopicChanged_Event);
        }
        private void ThenARemoveTopicEventOccurs()
        {
            Assert.NotNull(Actual_TopicRemoved_Event);
        }
        private void ThenATopicsReorderedEventOccurs()
        {
            Assert.NotNull(Actual_TopicsReordered_Event);
        }
        #endregion

        private void TheTopicExistsInTheCalendar(string title, string description, int duration)
        {
            var topics = sut.PlanningCalendarRepository.ListTopics(AggregateRootId);

            foreach (var item in topics)
            {
                Assert.Equal(title, item.Title);
                Assert.Equal(description, item.Description);
                Assert.Equal(duration, item.Duration);
            }
        }

        private void TheTopicAppearsAsTheLastTopicOnTheCalendar(string title, string description, int duration)
        {
            var topics = sut.PlanningCalendarRepository.ListTopics(AggregateRootId);
            var actual = topics.LastOrDefault();

            Assert.NotNull(actual);
            Assert.Equal(AggregateRootId, actual.PlanningCalendarId);
            Assert.Equal(title, actual.Title);
            Assert.Equal(description, actual.Description);
            Assert.Equal(duration, actual.Duration);
        }

        private void TheTopicDoesNotAppearOnTheCalendar(string title)
        {
            var topics = sut.PlanningCalendarRepository.ListTopics(AggregateRootId);

            foreach (var item in topics)
            {
                Assert.NotEqual(title, item.Title);
            }
        }

        private void ThenTheExpectedExceptionOccurs()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
