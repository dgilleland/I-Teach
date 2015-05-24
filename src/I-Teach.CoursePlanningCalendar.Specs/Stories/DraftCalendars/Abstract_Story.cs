using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonUtilities.Domain.Commands;
namespace I_Teach.CoursePlanningCalendar.Specs.Stories.DraftCalendars
{
    public class Abstract_Story
    {
        protected I_Teach.SchoolApplication sut;
        protected CommandWithAggregateRootId Command;
        protected Guid AggregateRootId;
        public Abstract_Story()
        {
            sut = SchoolApplication.Instance(this);
        }
    }
}
