using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.Domain.Commands
{
    public abstract class CommandWithAggregateRootId
    {
        public Guid Id { get; protected set; }
    }
}
