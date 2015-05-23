using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.SectionSpecificCalendars
{
    [Story(AsA = Actor.Instructor,
            IWant = "I Want to change the order and/or duration of topics on the calendar",
            SoThat = "So as to adjust the course delivery for my section")]
    public class Adjust_Topics
    {
        private I_Teach.SchoolApplication sut;
        public Adjust_Topics()
        {
            // initialize sut
        }

        //Reorder Topics
        //Change Topic Duration
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
