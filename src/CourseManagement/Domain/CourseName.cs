using System;
using CourseManagement.Domain.Exceptions;

namespace CourseManagement.Domain
{
    public class CourseName
    {
        public string Name { get; private set; }
        public CourseName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullOrWhiteSpaceStringException("course name cannot be empty");
            Name = name;
        }
        public override string ToString() { return Name; }
    }
}
