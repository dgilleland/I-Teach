using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    [Story(AsA = Actor.CourseCoordinator,
        IWant = "I Want to release the draft course planning calendar for a specific term to the instructors",
        SoThat = "So as to give instructors a planning calendar to use in their classes")]
    public class Accept_Draft_Calendar
    {
        private I_Teach.SchoolApplication sut;
        public Accept_Draft_Calendar()
        {
            sut = SchoolApplication.Instance();
        }

    //Accept Draft Calendar for Release
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
