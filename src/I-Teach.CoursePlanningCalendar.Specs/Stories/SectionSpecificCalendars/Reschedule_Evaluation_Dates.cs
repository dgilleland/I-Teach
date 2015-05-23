using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.SectionSpecificCalendars
{
    [Story(AsA = Actor.Instructor,
            IWant = "I Want to adjust due dates for an evaluation item",
            SoThat = "So as to provide proper preparation for evaluations in response to changes in the order of topics for the course")]
    public class Reschedule_Evaluation_Dates
    {
        private I_Teach.SchoolApplication sut;
        public Reschedule_Evaluation_Dates()
        {
            // initialize sut
        }

        //Reschedule Evaluation Date
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
