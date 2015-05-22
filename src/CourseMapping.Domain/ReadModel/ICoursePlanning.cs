using CourseMapping.Events;
using CourseMapping.ReadModel.Denormalizer;
using CourseMapping.ReadModel.DTOs;
using Edument.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMapping.ReadModel
{
    interface ICoursePlanning
    {
        List<CourseId> ProposedCourses(string programOfStudy);
        ProposedCourse CourseDetails(Guid id);
    }

    class CoursePlanning : ICoursePlanning,
                           IDisposable,
                           ISubscribeTo<CourseProposed>
    {
        private IReadModelContext Context { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CoursePlanning"/> class.
        /// </summary>
        /// <param name="readModelContext"></param>
        public CoursePlanning(IReadModelContext readModelContext)
        {
            Context = readModelContext;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        #region ICoursePlanning Implementation
        public List<CourseId> ProposedCourses(string programOfStudy)
        {
            throw new NotImplementedException();
        }

        public ProposedCourse CourseDetails(Guid id)
        {
                var course = Context.ProposedCourses.Find(id);
                return course;
        }
        #endregion

        #region Event Handler Implementations
        public void Handle(CourseProposed e)
        {
                var course = new ProposedCourse { Id = e.Id, CourseName = e.CourseName, CourseNumber = e.CourseNumber, Status = Status.Proposal };
                Context.ProposedCourses.Add(course);
                Context.SaveChanges();
        }
        #endregion
    }
}
