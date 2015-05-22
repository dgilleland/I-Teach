using CourseMapping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMapping.Commands.Handlers
{
    class ProposeCourseHandler : Edument.CQRS.IHandleCommand<ProposeCourse>
    {
        private readonly IDomainRepository repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProposeCourseHandler"/> class.
        /// </summary>
        /// <param name="repository"></param>
        public ProposeCourseHandler(IDomainRepository repository)
        {
            this.repository = repository;
        }

        System.Collections.IEnumerable Edument.CQRS.IHandleCommand<ProposeCourse>.Handle(ProposeCourse c)
        {
            throw new NotImplementedException();
        }
    }
}
