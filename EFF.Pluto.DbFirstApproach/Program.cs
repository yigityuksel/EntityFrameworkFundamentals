using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFF.Pluto.DbFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {

            //var dbContext = new PlutoDbContext();
            //var courses = dbContext.GetCourses();

            ////dbContext.GetAuthorCourses();

            //foreach (var getCoursesResult in courses)
            //{
            //    Console.WriteLine(getCoursesResult.Title);
            //}

            var course = new Course()
            {
                Level = CourseLevel.Beginner
            };

        }
    }
}
