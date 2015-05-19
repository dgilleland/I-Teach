using CourseMapping.ReadModel.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMapping.ReadModel.Denormalizer
{
    public interface IReadModelContext : IDisposable
    {
        DbSet<ProposedCourse> ProposedCourses { get; set; }
        int SaveChanges();
    }
    public class ReadModelContext : DbContext, IReadModelContext
    {
        public DbSet<ProposedCourse> ProposedCourses { get; set; }
    }
}
