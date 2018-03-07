using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFF.RepositoryPattern.Domain;

namespace EFF.RepositoryPattern.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(PlutoContext context) : base(context)
        {
        }

        public PlutoContext PlutoContext => Context as PlutoContext;

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return PlutoContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize)
        {
            return PlutoContext.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }
    }
}