using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;
using Ploeh.AutoFixture; // needed for the AutoFixture extension method .Create()
using OM = I_Teach.CoursePlanningCalendar.Specs.Helpers.ObjectMother;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    [Story(AsA = Actor.CourseCoordinator,
            IWant = "I Want to assign dates to evaluation components",
            SoThat = "So as to prepare students for evaluations")]
    public class Edit_Evaluations : Abstract_Story
    {
        private I_Teach.SchoolApplication sut;
        public EvaluationAdded Actual_EvaluationAdded_Event { get; set; }
        public SequenceChanged Actual_SequenceChanged_Event { get; set; }
        public Edit_Evaluations()
        {
            sut = SchoolApplication.Instance();
        }

        //Add an evaluation component
        //Change an evaluation component
        //Remove an evaluation component
        [Theory, AutoRollback]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(2, 0)]
        [InlineData(3, 1)]
        [Trait("Context", "Acceptance Test")]
        public void Add_an_evaluation(int existingTopicCount, int existingEvaluationCount)
        {
            this.Given(_ => GivenADraftCalendarHasBeenCreated())
                .And(_=>PreviousTopicsWereAppended(existingTopicCount))
                .And(_=>PreviousEventsWereAppended(existingEvaluationCount))
                .And(_=>AnAddEvaluationCommand("Major Quiz"))
                .When(_=>AddingTheEvaluation())
                .Then(_=>ThenAnEvaluationAddedEventOcurs())
                .And(_=>ThenASequenceChangedEventOccurs())
                .BDDfy();
        }

        //Add an evaluation component
        //Change an evaluation component
        //Remove an evaluation component
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void SCENARIO()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        public void TBA() { throw new NotImplementedException(); }
        private void AnAddEvaluationCommand(string title)
        {
            Command = OM.Commands.AppendEvaluationCommand(AggregateRootId, title);
            Assert.NotNull(Command);
        }
        private void AddingTheEvaluation()
        {
            sut.Process(Command as AppendEvaluation);
        }
        private void ThenAnEvaluationAddedEventOcurs()
        {
            Assert.NotNull(Actual_EvaluationAdded_Event);
        }
        private void ThenASequenceChangedEventOccurs()
        {
            Assert.NotNull(Actual_SequenceChanged_Event);
        }
    }
}
