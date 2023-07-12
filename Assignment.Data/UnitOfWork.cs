using Assignment.Application;
using Assignment.Application.Domain;
using Assignment.Application.Repository;
using Assignment.Data.Repository;

namespace Assignment.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Person> People { get; private set; }

        public IBaseRepository<Address> Addresses { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            People = new BaseRepository<Person>(_context);
            Addresses = new BaseRepository<Address>(_context);
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
