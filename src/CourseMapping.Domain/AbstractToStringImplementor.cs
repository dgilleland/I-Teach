using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseMapping
{
    public abstract class AbstractToStringImplementor
    {
        public void SetToStringImplementation(Func<string> implementation)
        {
            toStringImplementation = implementation;
        }

        private Func<string> toStringImplementation;

        public override string ToString()
        {
            return toStringImplementation();
        }
    }
}
