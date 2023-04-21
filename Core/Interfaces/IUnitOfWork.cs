using Core.Models;
using Onion.Core.Models;
using OnionArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Author> Authors { get; }
        IBookRepository Books { get; }
        IBaseRepository<Publisher> Publishers { get; }
        bool Complete();
        bool HasChanges();
    }
}
