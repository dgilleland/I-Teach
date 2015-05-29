using CommonUtilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.CoursePlanningCalendar.Domain
{
    class TopicName : IEquatable<TopicName>
    {
        readonly string __value;

        public TopicName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullOrWhiteSpaceStringException();
            __value = name;
        }

        #region Implicit Operators
        // from http://stackoverflow.com/a/22912864
        public static implicit operator string(TopicName name)
        {
            return name.ToString();
        }
        public static explicit operator TopicName(string name)
        {
            return new TopicName(name);
        }
        #endregion

        public override string ToString()
        {
            return __value;
        }

        #region IEquatable Implementation
        public override bool Equals(object obj)
        {
            if (obj is TopicName)
                return Equals((TopicName)obj);
            return base.Equals(obj);
        }
        public static bool operator ==(TopicName first, TopicName second)
        {
            if ((object)first == null)
                return (object)second == null;
            return first.Equals(second);
        }
        public static bool operator !=(TopicName first, TopicName second)
        {
            return !(first == second);
        }
        public bool Equals(TopicName other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Equals(this.__value, other.__value);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 47;
                if (this.__value != null)
                    hashCode = (hashCode * 53) ^ this.__value.GetHashCode();
                return hashCode;
            }
        }
        #endregion
    }
}
