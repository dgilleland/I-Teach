using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    [Story(AsA = Actor.CourseCoordinator,
            IWant = "I Want to edit the dates in the upcoming term that will be missed due to holidays or skipped due to reading breaks",
            SoThat = "So as to ensure there is enough time for all the items on the planning calendar")]
    public class Record_Non_School_Days
    {
        private I_Teach.Class1 sut;
        public Record_Non_School_Days()
        {
            // initialize sut
        }

        //Edit Holiday Dates
        //Add Reading Week
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
