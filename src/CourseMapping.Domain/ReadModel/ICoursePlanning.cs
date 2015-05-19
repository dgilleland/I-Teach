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
                           ISubscribeTo<CourseProposed>
    {

        #region ICoursePlanning Implementation
        public List<CourseId> ProposedCourses(string programOfStudy)
        {
            throw new NotImplementedException();
        }

        public ProposedCourse CourseDetails(Guid id)
        {
            using (var context = new ReadModelContext())
            {
                var course = context.ProposedCourses.Find(id);
                return course;
            }
        }
        #endregion

        #region Event Handler Implementations
        public void Handle(CourseProposed e)
        {
            using (var context = new ReadModelContext())
            {
                var course = new ProposedCourse { Id = e.Id, CourseName = e.CourseName, CourseNumber = e.CourseNumber, Status = Status.Proposal };
                context.ProposedCourses.Add(course);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
