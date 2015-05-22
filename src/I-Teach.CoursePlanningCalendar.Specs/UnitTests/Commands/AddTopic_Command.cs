using I_Teach.CoursePlanningCalendar.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace I_Teach.CoursePlanningCalendar.Specs.UnitTests.Commands
{
    public class AddTopic_Command
    {
        [Fact]
        [Trait("Context", "Planning Calendar Commands")]
        public void Should_Instantiate_AddTopic_Command()
        {
            // Arrange
            AddTopic sut;
            string title = "A title";
            string description = "A description";
            int duration = 3;

            // Act/Assert
            sut = new AddTopic(title, description, duration);
            Assert.Equal(title, sut.Title);
            Assert.Equal(description, sut.Description);
            Assert.Equal(duration, sut.Duration);

            sut = new AddTopic(title, description);
            Assert.Equal(title, sut.Title);
            Assert.Equal(description, sut.Description);

            sut = new AddTopic(title, duration);
            Assert.Equal(title, sut.Title);
            Assert.Equal(duration, sut.Duration);

            sut = new AddTopic(title);
            Assert.Equal(title, sut.Title);
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
        public void Should_Reject_An_Empty_Topic_Title(string title)
        {
            Assert.Throws<ArgumentException>(() => { new AddTopic(title); });
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
        public void Should_Accept_An_Empty_Topic_Description(string description)
        {
            var sut = new AddTopic("A topic", description);
            Assert.Equal(null, sut.Description);
        }

        [Fact]
        public void Should_Use_One_Class_As_A_Default_Duration()
        {
            var sut = new AddTopic("A topic");
            Assert.Equal(1, sut.Duration);

            sut = new AddTopic("A topic", "A description");
            Assert.Equal(1, sut.Duration);
        }

        #region Theory test
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Accept_A_Duration_Greater_Than_Or_Equal_To_One_Class(int duration)
        {
            var sut = new AddTopic("A topic", duration);
            Assert.Equal(duration, sut.Duration);
        }

        #region Theory test
        [Theory]
        [InlineData(7)]
        [InlineData(77)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Reject_A_Duration_Greater_Than_Six_Classes(int duration)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new AddTopic("A topic", duration); });
        }

        #region Theory test
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Reject_A_Duration_Less_Than_One_Class(int duration)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new AddTopic("A topic", duration); });
        }
    }
}
