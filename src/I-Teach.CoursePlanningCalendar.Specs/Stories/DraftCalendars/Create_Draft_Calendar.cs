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
        public Create_Draft_Calendar()
        {
            // initialize sut
        }

        //Create a blank draft
        //Create a draft from an existing calendar
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
