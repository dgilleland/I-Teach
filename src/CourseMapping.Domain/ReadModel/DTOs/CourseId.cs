using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseMapping.ReadModel.DTOs
{
    public class CourseId
    {
    }
    public enum Status { Current, Archive, Revision, Proposal }
    public class ProposedCourse
    {
        [Key]
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public Status Status { get; set; }
        public CourseId CourseId { get; set; }
        public int? Hours { get; set; }
        public double? Credits { get; set; }
    }
    public class ActiveCourse
    {
    }
    public class RevisedCourse
    {
    }
}
