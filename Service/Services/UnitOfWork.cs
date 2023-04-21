using Core.Interfaces;
using Core.Models;
using Onion.Core.Models;
using OnionArchitecture.Core.Interfaces;
using Respository;
using Service.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace OnionArchitecture.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Author> Authors { get; private set; }
        public IBookRepository Books { get; private set; }
        public IBaseRepository<Publisher> Publishers { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(context);
            Books = new BookService(_context);
            Publishers = new BaseRepository<Publisher>(context);
        }

        public bool Complete()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
