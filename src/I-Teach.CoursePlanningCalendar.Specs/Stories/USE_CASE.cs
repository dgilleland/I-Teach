using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.Stories
{
    //[Story(AsA=Actor.CourseCoordinator,
    //    IWant="I Want",
    //    SoThat="So as to ")]
    //public class USE_CASE
    //{
    //    private I_Teach.Class1 sut;
    //    public USE_CASE()
    //    {
    //        // initialize sut
    //    }

    //    [Fact, AutoRollback]
    //    [Trait("Context", "Acceptance Test")]
    //    public void SCENARIO()
    //    {
    //        this.Given(_ => TBA())
    //            .BDDfy();
    //    }

    //    public void TBA() { throw new NotImplementedException(); }
    //}

    public static class Actor
    {
        public const string CourseCoordinator = "Course Coordinator";
        public const string Instructor = "Instructor";
    }
}
