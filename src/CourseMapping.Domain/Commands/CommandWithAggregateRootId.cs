using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseMapping.Commands
{
    public abstract class CommandWithAggregateRootId
    {
        public Guid AggregateRootId { get; protected set; }
    }
}
