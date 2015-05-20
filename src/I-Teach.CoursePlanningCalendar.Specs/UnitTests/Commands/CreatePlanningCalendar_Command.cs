using I_Teach.CoursePlanningCalendar.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
            Assert.Throws<ArgumentException>(() => { new CreatePlanningCalendar(name, "ABCD1001"); });
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
            Assert.Throws<ArgumentException>(() => { new CreatePlanningCalendar("Introductory Unit Testing", number); });
        }
    }
}
