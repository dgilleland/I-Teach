// Credits: https://github.com/TestStack/TestStack.BDDfy/issues/14
using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Teach.CoursePlanningCalendar.Specs.Helpers
{
    static class TestHelpers
    {
        public static Exception ExecuteActionThatThrows(Action action)
        {
            Exception exception = null;
            try
            {
                action();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            return exception;
        }
    }
}
