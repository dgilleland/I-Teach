using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.SectionSpecificCalendars
{
    [Story(AsA = Actor.Instructor,
            IWant = "I Want to flag topics as 'not covered'",
            SoThat = "So as to compensate for insufficient time to cover topics in the course")]
    public class Remove_Topic
    {
        private I_Teach.SchoolApplication sut;
        public Remove_Topic()
        {
            sut = SchoolApplication.Instance();
        }

        //Flag Topic As Not Covered
        //should include a comment as to why
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
