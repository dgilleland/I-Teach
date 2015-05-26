using Edument.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonUtilities.Domain.Bus
{
    public interface IBus
    {
        void RegisterWithDispatcher(params object[] subscribers);
    }
}
