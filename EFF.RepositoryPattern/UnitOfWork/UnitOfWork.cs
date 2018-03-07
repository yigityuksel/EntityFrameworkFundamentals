using EFF.RepositoryPattern.Repository;

namespace EFF.RepositoryPattern.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PlutoContext _context;

        public ICourseRepository Courses { get; private set; }

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}