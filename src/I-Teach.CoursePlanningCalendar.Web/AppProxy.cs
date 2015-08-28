using I_Teach.CoursePlanningCalendar.Commands;
using I_Teach.CoursePlanningCalendar.Fetch.Model;
using I_Teach.CoursePlanningCalendar.Web.AdHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I_Teach.CoursePlanningCalendar.Web
{
    public class AppProxy
    {
        public I_Teach.SchoolApplication App { get; set; }
        public AppProxy()
        {
            App = I_Teach.SchoolApplication.Instance();
        }

        public static AppProxy Instance()
        {
            return new AppProxy();
        }

        public IEnumerable<DraftPlanningCalendar> ListCalendars()
        {
            var calendars = App.PlanningCalendarRepository.ListDraftPlanningCalendars();

            return calendars;
        }

        public void CreateCourse(string name, string number, int totalHours, int weeks = 15)
        {
            using (var context = new AdHocContext())
            {
                context.Courses.Add(new Course() { Id = Guid.NewGuid(), Name = name, Number = number, TotalHours = totalHours, Weeks = weeks });
                context.SaveChanges();
            }
        }

        public List<Course> ListCourses()
        {
            using (var context = new AdHocContext())
            {
                return context.Courses.ToList();
            }
        }

        public void CreateCourseCalendar(Guid courseId, int year, string month)
        {
            using (var context = new AdHocContext())
            {
            	var course = context.Courses.Find(courseId);
                var command = new CreatePlanningCalendar(course.Name, course.Number, course.TotalHours, 3);
                App.Process(command);
            }
        }
    }
}