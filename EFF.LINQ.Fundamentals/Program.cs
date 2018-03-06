using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFF.LINQ.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new PlutoContext();

            //LINQ Syntax
            var query_ = from c in context.Courses
                         where c.Name.Contains("c#")
                         orderby c.Name
                         select c;

            //foreach (var course in query)
            //    Console.WriteLine(course.Name);

            //Extension Methods
            var courses = context.Courses
                .Where(a => a.Name.Contains("c#"))
                .OrderBy(a => a.Name);

            //foreach (var course in courses)
            //    Console.WriteLine(course.Name);

            var query = from tempAuthorVariable in context.Authors
                        from tempVariable in context.Courses
                        select new { AuthorName = tempAuthorVariable.Name, Courses = tempVariable.Name };

            foreach (var item in query)
            {
                Console.WriteLine($@" {item.AuthorName} - {item.Courses} ");
            }

        }
    }
}
