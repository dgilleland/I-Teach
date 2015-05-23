using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar
{
    public sealed class About
    {
        public static Assembly CoursePlanningCalendar
        {
            get
            {
                About me = new About();
                return me.GetType().Assembly;
            }
        }
    }
}
