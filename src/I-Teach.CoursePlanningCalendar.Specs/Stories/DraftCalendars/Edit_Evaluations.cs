using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    [Story(AsA = Actor.CourseCoordinator,
            IWant = "I Want to assign dates to evaluation components",
            SoThat = "So as to prepare students for evaluations")]
    public class Edit_Evaluations
    {
        private I_Teach.SchoolApplication sut;
        public Edit_Evaluations()
        {
            // initialize sut
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
    }
}
