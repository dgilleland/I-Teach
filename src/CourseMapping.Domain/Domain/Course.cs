using CourseMapping.Commands;
using CourseMapping.Events;
using Edument.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
namespace CourseMapping.Domain
{
    class Course : Aggregate,
        IHandleCommand<ProposeCourse>,
        IApplyEvent<CourseProposed>

    {
        public CourseName Name { get; private set; }
        public CourseNumber Number { get; private set; }
        public int Hours { get; private set; }
        public double Credits { get; private set; }
        public Term CommencementDate { get; private set; }
        public Term FinalOfferingDate { get; private set; }

        #region Command Handlers
        public IEnumerable Handle(ProposeCourse c)
        {
            yield return new CourseProposed 
            {
                Id = c.AggregateRootId,
                CourseName = c.CourseName
            };
        }

        #endregion

        #region Event Handlers
        public void Apply(CourseProposed e)
        {
            //Id = e.Id,
            Name = new CourseName(e.CourseName);
        }
        #endregion
    }
}