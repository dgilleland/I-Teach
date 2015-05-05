using System;
using CourseManagement.Domain.Exceptions;

namespace CourseManagement.Domain
{
    public class CourseNumber
    {
        public string Number { get; private set; }
        public CourseNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new NullOrWhiteSpaceStringException("course number cannot be empty");
            Number = number;
        }
        public override string ToString() { return Number; }
    }
}
