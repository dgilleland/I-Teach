using CourseMapping.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy;
using Xunit;

namespace CourseMapping.Specs.Domain.Commands
{
    [Story(IWant = "I want to propose new courses",
           SoThat = "So that new courses can be planned for future release")]
    public class Proposing_New_Courses
    {
        /*
         *  When Proposing A New Course
         *  Then I Can Uniquely Identify The Course For Editing
         *  Then The Default Delivery Setting is Lab
         *  Then The Course Is Not Designated As A Core Course
         *  Then No Credits Are Assigned
         *  Then No Hours Are Assigned
         *  Then No Semester Is Assigned
         *  Then No Commencement Term Is Assigned
         *  Then No Final Offering Term Is Assigned
         *
         *  When Proposing A New Course
         *  Then The Course Proposed Event Is Raised
* --- PLACE UNDER SEPARATE USE CASE for Read Models
*
*  Given A New Course Has Been Proposed
*  When Viewing The List of Proposed Courses
*  Then The Proposed Course Is Listed By Name Under The Program Of Study

* --- USE CASE??
*
*  When Proposing A New Course With A New Program Of Study
*  Then The New Program Of Study Is Listed In The Schools Programs
         *
         *  When Proposing A Course With No Name
         *  Then The Course Proposal Is Rejected
         *
         *  When Proposing A Course With No Program of Study
         *  Then The Course Proposal Is Rejected
         *      // UI Note: When the # of programs of study is just 1, then use it as the default, otherwise have the user select it from a list/dropdown.
         *
         */

        private CommandWithAggregateRootId Command;
        private Application.UsageContext UsageContext;
        public Proposing_New_Courses()
        {
            UsageContext = new Application.UsageContext("Anna List", "Software Development");
            UsageContext.SetToStringImplementation(() => {
                return string.Format("(for the {0} diploma by the user {1}", UsageContext.ProgramName, UsageContext.UserName);
            });
        }

        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => WhenIProposeANewCourse("Domain Driven Design"))
                .Then(_ => ThenICanUniquelyIdentifyTheCourse())
                .And(_ => ThenTheCourseIsNotDesignatedAsACoreCourse())
                .And(_ => ThenNoCreditsAreAssigned())
                .And(_ => ThenNoHoursAreAssigned())
                .And(_ => ThenNoSemesterIsAssigned())
                .And(_ => ThenNoCommencementTermIsAssigned())
                .And(_ => ThenNoFinalOfferingTermIsAssigned())
                //.And(_ => ThenTheCourseIsProposed
                /*
                 */
                .BDDfy();
        }

        private void ThenNoFinalOfferingTermIsAssigned()
        {
            throw new NotImplementedException();
        }

        private void ThenNoCommencementTermIsAssigned()
        {
            throw new NotImplementedException();
        }

        private void ThenNoSemesterIsAssigned()
        {
            throw new NotImplementedException();
        }

        private void ThenNoHoursAreAssigned()
        {
            throw new NotImplementedException();
        }

        private void ThenNoCreditsAreAssigned()
        {
            throw new NotImplementedException();
        }

        private void ThenTheCourseIsNotDesignatedAsACoreCourse()
        {
            throw new NotImplementedException();
        }
        private void WhenIProposeANewCourse(string courseName)
        {
            Command = new ProposeCourse(courseName, UsageContext.ProgramName);
        }
        private void ThenICanUniquelyIdentifyTheCourse()
        {
            Assert.NotEqual(Guid.Empty, Command.AggregateRootId);
        }
    }

    [Story(IWant = "I want to add an existing course",
           SoThat = "So that courses currently available are included in the course mapping")]
    public class Adding_Existing_Courses
    {
        /*
         */
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to assign a course number to a proposed course",
           SoThat = "So that the course can be identified in the course mapping")]
    public class Assigning_Course_Numbers
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to assign a course name to a proposed/revised course",
           SoThat = "So that the course name can act as a description for the course.")]
    public class Assigning_Course_Names
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to adjust course details",
           SoThat = "So that proposed and revised courses can be modified")]
    public class Adjust_Course_Details
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to add course dependencies",
           SoThat = "So that course corequesites and prerequisites can be mapped")]
    public class Adding_Course_Dependencies
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to adjust the importance of course dependencies",
           SoThat = "So that the nature of course dependencies can be adjusted")]
    public class Adjusting_Course_Dependencies
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to remove course dependencies",
           SoThat = "So that coursess can be decoupled in the course mapping")]
    public class Removing_Course_Dependencies
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to accept proposed courses",
           SoThat = "So that they can be included in the course mapping")]
    public class Accepting_Proposed_Courses
    {
        [Fact]
        public void Scenario_Name()
        {
            throw new NotImplementedException();
        }
    }

    [Story(IWant = "I want to reject proposed courses",
           SoThat = "So that they can be removed from the course mapping")]
    public class Rejecting_Proposed_Courses
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to make changes to current courses",
           SoThat = "So that courses can be modified for future delivery")]
    public class Revising_Current_Courses
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to accept course revisions",
           SoThat = "So that they can be included in the course mapping")]
    public class Accepting_Course_Revisions
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to reject course revisions",
           SoThat = "So that they can be removed from the course mapping")]
    public class Rejecting_Course_Revisions
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }

    [Story(IWant = "I want to retire current courses",
           SoThat = "So that courses that are no longer applicable to the program will no longer be available")]
    public class Retiring_Current_Courses
    {
        [Fact]
        public void Scenario_Name()
        {
            this.When(_ => TBA()).BDDfy();
        }
        public void TBA()
        {
            { throw new NotImplementedException(); }
        }
    }
}
