using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.SectionSpecificCalendars
{
    [Story(AsA = Actor.Instructor,
            IWant = "I Want to enter the days of the week that my section has classes",
            SoThat = "So as to make planning calendars specific to each section")]
    public class Customize_Class_Days_For_Sections
    {
        private I_Teach.SchoolApplication sut;
        public Customize_Class_Days_For_Sections()
        {
            sut = SchoolApplication.Instance();
        }

        //Enter Class Days For Section
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
