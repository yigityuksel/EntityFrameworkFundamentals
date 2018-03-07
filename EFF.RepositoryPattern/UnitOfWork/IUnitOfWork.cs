using System;
using EFF.RepositoryPattern.Repository;

namespace EFF.RepositoryPattern.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }

        int Complete();
    }
}