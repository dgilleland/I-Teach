using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMapping.Events
{
    public class CourseProposed
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
    }
}
