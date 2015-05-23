using I_Teach.CoursePlanningCalendar.Specs.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories.SectionSpecificCalendars
{
    [Story(AsA = Actor.Instructor,
        IWant = "I Want to flag evaluation components as 'removed'",
        SoThat = "So as to compensate for insufficient time to cover topics in the course")]
    public class Remove_Evaluation_Component
    {
        private I_Teach.Class1 sut;
        public Remove_Evaluation_Component()
        {
            // initialize sut
        }

        //**must* include a note about how marks will be redistributed*
        //Flag Evaluation Component As Redistributed
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