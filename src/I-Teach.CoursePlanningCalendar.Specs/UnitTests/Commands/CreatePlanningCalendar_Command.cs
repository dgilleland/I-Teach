using I_Teach.CoursePlanningCalendar.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.UnitTests.Commands
{
    public class CreatePlanningCalendar_Command
    {
        #region Theory test
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        [InlineData("\t")]
        [InlineData("\n")]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Reject_An_Empty_Course_Name(string name)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => { new CreatePlanningCalendar(name, "ABCD1001", 90, 3); });
        }

        #region Theory test
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("  ")]
        [InlineData("\t")]
        [InlineData("\n")]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Reject_An_Empty_Course_Number(string number)
        {
            Assert.Throws<ArgumentException>(() => { new CreatePlanningCalendar("Introductory Unit Testing", number, 90, 3); });
        }

        #region Theory test
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(70)]
        [InlineData(100)]
        [InlineData(99)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Reject_Invalid_TotalHours(int totalHours)
        {
            Assert.Throws<ArgumentException>(() => { new CreatePlanningCalendar("Introductory Unit Testing", "ABCD1001", totalHours, 3); });
        }

        #region Theory test
        [Theory]
        [InlineData(60)]
        [InlineData(75)]
        [InlineData(90)]
        [InlineData(180)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Accept_Valid_TotalHours(int totalHours)
        {
            Assert.DoesNotThrow(() => { new CreatePlanningCalendar("Introductory Unit Testing", "ABCD1001", totalHours, 3); });
        }

        #region Theory test
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(7)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Reject_Invalid_ClassesPerWeek(int classesPerWeek)
        {
            Assert.Throws<ArgumentException>(() => { new CreatePlanningCalendar("Introductory Unit Testing", "ABCD1001", 90, classesPerWeek); });
        }

        #region Theory test
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Accept_Valid_ClassesPerWeek(int classesPerWeek)
        {
            Assert.DoesNotThrow(() => { new CreatePlanningCalendar("Introductory Unit Testing", "ABCD1001", 90, classesPerWeek); });
        }
    }
}
