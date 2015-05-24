using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

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
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Add_a_topic()
        {
            string title = "";
            string description = "";
            int duration = 2;
            this.Given(_ => GivenADraftCalendar())
                .And(_=>GivenAnAddTopicCommand(title, description, duration))
                .When(_=>WhenIAddTheTopic())
                .Then(_=>ThenATopicAddedEventOccurs())
                .And(_=>ThenTheTopicAppearsAsTheLastTopicOnTheCalendar(title, description, duration))
                .BDDfy();
        }

        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Change_a_topic()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Remove_a_topic()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

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
            throw new NotImplementedException();
        }

        public void Handle(TopicChanged e)
        {
            throw new NotImplementedException();
        }

        public void Handle(TopicRemoved e)
        {
            throw new NotImplementedException();
        }

        public void Handle(TopicsReordered e)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Givens
        private void GivenADraftCalendar()
        {
            throw new NotImplementedException();
        }
        private void GivenAnAddTopicCommand(string title, string description, int duration)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Whens
        private void WhenIAddTheTopic()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Thens
        private void ThenATopicAddedEventOccurs()
        {
            throw new NotImplementedException();
        }
        private void ThenTheTopicAppearsAsTheLastTopicOnTheCalendar(string title, string description, int duration)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
