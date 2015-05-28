using CommonUtilities.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Specs.Helpers
{
    public static class SchoolApplicationExtensions
    {
        public static SchoolApplication ProcessInTurn<TCommand>(this SchoolApplication sut, TCommand command) where TCommand : CommandWithAggregateRootId
        {
            sut.Process(command);
            return sut;
        }
    }
}
