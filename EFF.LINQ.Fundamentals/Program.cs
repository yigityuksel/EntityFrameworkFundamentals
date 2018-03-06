using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFF.LINQ.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new PlutoContext();

            //this query gives run time exception, becauese it is custom method and LINQ does not know how to convert to the SQL
            var beginnerCourses = context.Courses.Where(a => a.IsBeginnerCourse == true);

            //for solution
            //but it might slow down tthe query.
            //var courses = context.Courses.ToList().Where(a => a.IsBeginnerCourse == true);

            //LINQ Syntax
            //var query_ = from c in context.Courses
            //             where c.Name.Contains("c#")
            //             orderby c.Name
            //             select c;

            //foreach (var course in query_)
            //    Console.WriteLine(course.Name);

            //Extension Methods
            //var courses = context.Courses
            //    .Where(a => a.Name.Contains("c#"))
            //    .OrderBy(a => a.Name);

            ////foreach (var course in courses)
            ////    Console.WriteLine(course.Name);

            //var query = from tempAuthorVariable in context.Authors
            //            from tempVariable in context.Courses
            //            select new { AuthorName = tempAuthorVariable.Name, Courses = tempVariable.Name };

            //foreach (var item in query)
            //{
            //    Console.WriteLine($@" {item.AuthorName} - {item.Courses} ");
            //}

            //var que2ry = context.Courses.Join(context.Authors,
            //    c => c.AuthorId,
            //    a => a.Id,
            //    (course, author) => new
            //    {
            //        CourseName = course.Name,
            //        AuthorName = author.Name
            //    }
            //);

            //this piece of code points N+1 Problem, 
            //the problem says that we fetching all course List(N)
            //when we need to get author, fetching author with new query (+1)

            var courses = context.Courses.ToList();

            foreach (var course in courses)
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);

            //Eager Loading
            //Bad Example, Magic String Used
            var courseList = context.Courses.Include("Author").ToList();

            //object
            var course_list = context.Courses.Include(a => a.Author).ToList();

            //single property
            context.Courses.Include(a => a.Author.Name);

            //for collection property
            context.Courses.Include(a => a.Tags);

            //collection bottom level loads.
            context.Courses.Include(a => a.Tags.Select(t => t.Name));


            //// Explict Loading Example

            var authors = context.Authors.ToList();
            var authorIds = authors.Select(a => a.Id);

            //selecting multiple Ids at the same time
            context.Courses.Where(c => authorIds.Contains(c.AuthorId) && c.FullPrice == 0).Load();

        }
    }
}
