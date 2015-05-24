using Edument.CQRS;
using I_Teach.CoursePlanningCalendar.Events;
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
    public class Record_Non_School_Days : Abstract_Story, ISubscribeTo<SetCalendarHolidays>
    {
        private SetCalendarHolidays ActualEvent;

        public Record_Non_School_Days()
        {
        }

        #region Scenarios
        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Edit_Holiday_Dates()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Add_Reading_Week()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        [Fact, AutoRollback]
        [Trait("Context", "Acceptance Test")]
        public void Remove_Reading_Week()
        {
            this.Given(_ => TBA())
                .BDDfy();
        }

        public void TBA() { throw new NotImplementedException(); }
        #endregion

        #region Event Subscribers
        public void Handle(SetCalendarHolidays e)
        {
            ActualEvent = e;
        }
        #endregion
    }
}
