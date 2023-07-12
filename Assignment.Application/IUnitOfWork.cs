
using Assignment.Application.Domain;
using Assignment.Application.Repository;

namespace Assignment.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Person> People { get; }
        IBaseRepository<Address> Addresses { get; }

        int Complete();
    }
}
