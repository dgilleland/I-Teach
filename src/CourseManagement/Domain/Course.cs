using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Domain
{
    public class Course
    {
        public CourseName Name { get; private set; }
        public CourseNumber Number { get; private set; }
        public int Hours { get; private set; }
        public double Credits { get; private set; }
        public Term CommencementDate { get; private set; }
        public Term FinalOfferingDate { get; private set; }
    }
}