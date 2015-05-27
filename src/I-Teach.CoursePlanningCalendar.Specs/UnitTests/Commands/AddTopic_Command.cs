using I_Teach.CoursePlanningCalendar.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace I_Teach.CoursePlanningCalendar.Specs.UnitTests.Commands
{
    public class AppendTopic_Command
    {
        [Fact]
        [Trait("Context", "Planning Calendar Commands")]
        public void Should_Instantiate_AppendTopic_Command()
        {
            // Arrange
            AppendTopic sut;
            Guid id = Guid.NewGuid();
            string title = "A title";
            string description = "A description";
            int duration = 3;

            // Act/Assert
            sut = new AppendTopic(id, title, description, duration);
            Assert.Equal(title, sut.Title);
            Assert.Equal(description, sut.Description);
            Assert.Equal(duration, sut.Duration);

            sut = new AppendTopic(id, title, description);
            Assert.Equal(title, sut.Title);
            Assert.Equal(description, sut.Description);

            sut = new AppendTopic(id, title, duration);
            Assert.Equal(title, sut.Title);
            Assert.Equal(duration, sut.Duration);

            sut = new AppendTopic(id, title);
            Assert.Equal(title, sut.Title);
        }

        [Fact]
        [Trait("Context", "Planning Calendar Commands")]
        public void Should_Reject_Empty_Guid()
        {
            // Arrange
            AppendTopic sut;
            Guid id = Guid.Empty;
            string title = "A title";
            string description = "A description";
            int duration = 3;

            // Act/Assert
            Assert.Throws<ArgumentException>(() => sut = new AppendTopic(id, title, description, duration));

            Assert.Throws<ArgumentException>(() => sut = new AppendTopic(id, title, description));

            Assert.Throws<ArgumentException>(() => sut = new AppendTopic(id, title, duration));

            Assert.Throws<ArgumentException>(() => sut = new AppendTopic(id, title));
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
            Assert.Throws<ArgumentException>(() => { new AppendTopic(Guid.NewGuid(), title); });
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
            var sut = new AppendTopic(Guid.NewGuid(), "A topic", description);
            Assert.Equal(null, sut.Description);
        }

        [Fact]
        [Trait("Context", "Planning Calendar Commands")]
        public void Should_Use_One_Class_As_A_Default_Duration()
        {
            var sut = new AppendTopic(Guid.NewGuid(), "A topic");
            Assert.Equal(1, sut.Duration);

            sut = new AppendTopic(Guid.NewGuid(), "A topic", "A description");
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
            var sut = new AppendTopic(Guid.NewGuid(), "A topic", duration);
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
            Assert.Throws<ArgumentOutOfRangeException>(() => { new AppendTopic(Guid.NewGuid(), "A topic", duration); });
        }

        #region Theory test
        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        [Trait("Context", "Planning Calendar Commands")]
        #endregion
        public void Should_Reject_A_Duration_Less_Than_One_Class(int duration)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => { new AppendTopic(Guid.NewGuid(), "A topic", duration); });
        }
    }
}
