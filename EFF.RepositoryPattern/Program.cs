using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFF.RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var unitOfWork = new UnitOfWork.UnitOfWork(new PlutoContext()))
            {

                var course = unitOfWork.Courses.Get(1);
                
                var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);
                
                unitOfWork.Complete();

                Console.WriteLine(course.Name);

                Console.WriteLine(courses.FirstOrDefault().Name);

            }

        }
    }
}
