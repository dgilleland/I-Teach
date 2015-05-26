using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.SectionSpecificCalendars
{
    [Story(AsA = Actor.Instructor,
            IWant = "I Want to publish my course planning calendar",
            SoThat = "So as to share the calendar with students")]
    public class Publish_Course_Calendar
    {
        private I_Teach.SchoolApplication sut;
        public Publish_Course_Calendar()
        {
            sut = SchoolApplication.Instance();
        }

        //Publish Calendar
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
