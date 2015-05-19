using CourseMapping.ReadModel.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMapping.ReadModel.Denormalizer
{
    public class ReadModelContext :DbContext
    {
        public DbSet<ProposedCourse> ProposedCourses { get; set; }
    }
}
