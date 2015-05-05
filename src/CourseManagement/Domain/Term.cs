using System;

namespace CourseManagement.Domain
{
    public class Term
    {
        public Month Month { get; private set; }
        public int Year { get; private set; }

        public Term(Month month, int year)
        {
            if (year < 1965 || year > 2064)
                throw new ArgumentException("invalid year");
            Month = month;
            Year = year;
        }
    }
}
