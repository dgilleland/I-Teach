using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace I_Teach.CoursePlanningCalendar.Fetch
{
    public class DraftPlanningCalendar
    {
        [Key]
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
    }
}
