using System.Collections.Generic;
using EFF.RepositoryPattern.Domain;

namespace EFF.RepositoryPattern.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}