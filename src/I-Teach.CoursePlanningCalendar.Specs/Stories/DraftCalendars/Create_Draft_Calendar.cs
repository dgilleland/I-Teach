using CommonUtilities.Domain.Commands;
using I_Teach.CoursePlanningCalendar.Commands;
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
            IWant = "I Want to create a draft planning calendar for a course",
            SoThat = "So as to have a working copy of a planning calendar for editing")]
    public class Create_Draft_Calendar
    {
        private I_Teach.SchoolApplication sut;
        private CommandWithAggregateRootId Command;
        private CalendarCreated ExpectedCalendarCreatedEvent;

        public Create_Draft_Calendar()
        {
            sut = SchoolApplication.Instance();
        }

        #region Scenarios
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Create_a_blank_draft_calendar()
        {
            this.Given(_ => GivenACreatePlanningCalendarCommand())
                .When(_ => WhenICreateANewDraftCalendar())
                .Then(_ => ThenADraftCalendarCreatedEventOccurs())
                .And(_ => ThenIHaveAReferenceToTheDraftCalendar())
                .BDDfy();
        }

        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Create_a_draft_from_an_existing_calendar()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }
        #endregion

        public void TBA() { throw new NotImplementedException(); }

        #region Givens
        private void GivenACreatePlanningCalendarCommand()
        {
            Command = new CreatePlanningCalendar("Enterprise Application Programming", "EAP 205");
        }
        #endregion

        #region Whens
        private void WhenICreateANewDraftCalendar()
        {
            sut.Process(Command as CreatePlanningCalendar);
        }
        #endregion

        #region Thens
        private void ThenADraftCalendarCreatedEventOccurs()
        {
            Assert.NotNull(ExpectedCalendarCreatedEvent);
        }

        private void ThenIHaveAReferenceToTheDraftCalendar()
        {
            Assert.NotEqual(Guid.Empty, Command.Id);
        }
        #endregion
    }
}
