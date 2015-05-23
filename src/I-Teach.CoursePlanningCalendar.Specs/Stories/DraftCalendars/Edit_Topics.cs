using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    [Story(AsA = Actor.CourseCoordinator,
            IWant = "I Want to edit the list of topics",
            SoThat = "So as to plan the topics to cover in class")]
    public class Edit_Topics
    {
        private I_Teach.Class1 sut;
        public Edit_Topics()
        {
            // initialize sut
        }

        //Add a topic
        //Change a topic
        //Remove a topic
        //Reorder topics
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
