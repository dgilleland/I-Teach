using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    [Story(AsA = Actor.CourseCoordinator,
            IWant = "I Want to add or remove work periods between topics",
            SoThat = "So as to allow time for in-class work")]
    public class Include_Work_Periods
    {
        private I_Teach.Class1 sut;
        public Include_Work_Periods()
        {
            // initialize sut
        }

        //Add Work Period
        //Remove Work Period
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
