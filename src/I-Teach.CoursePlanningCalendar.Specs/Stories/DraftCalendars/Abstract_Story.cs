using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonUtilities.Domain.Commands;
using I_Teach.CoursePlanningCalendar.Specs.Helpers;
using OM = I_Teach.CoursePlanningCalendar.Specs.Helpers.ObjectMother;
using System.Collections;
using Xunit;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    public class Abstract_Story
    {
        protected Exception ActualExeption;
        protected I_Teach.SchoolApplication sut;
        protected CommandWithAggregateRootId Command;
        protected Guid AggregateRootId;
        public Abstract_Story()
        {
            sut = SchoolApplication.Instance(this);
            AggregateRootId = Guid.NewGuid();
        }

        protected void GivenADraftCalendarHasBeenCreated()
        {
            var createCommand = OM.Commands.CreatePlanningCalendar();
            AggregateRootId = createCommand.Id;
            sut.Process(createCommand);
        }
        protected void ThenTheExpectedExceptionIsGenerated<T>() where T: Exception
        {
            Assert.IsType<T>(ActualExeption);
        }
        protected void ExecuteActionThatThrows(Action action)
        {
            ActualExeption = TestHelpers.ExecuteActionThatThrows(action);
        }
    }
}
