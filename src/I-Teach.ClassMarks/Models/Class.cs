using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach.ClassMarks.Models
{
    internal class Class
    {
        private Class(CourseSection section, Term term, EvaluationComponents evaluations)
        {
        }

        public static Class CreateClass(CourseSection section, Term term, EvaluationComponents evaluations)
        {
            return new Class(section, term, evaluations);
        }

        private void AddStudent(Student student)
        {
            
        }

        private void RemoveStudent(StudentId studentId)
        {
            
        }

        private void TransferStudent(StudentId studentId, Class section)
        {
            
        }

        private void AdjustCourseComponent()
        {
            
        }

        private void EnterMark(StudentId studentId, Evaluation evaluationItem, Mark mark)
        {
            
        }
    }
}
