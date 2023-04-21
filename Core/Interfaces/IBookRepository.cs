using Core.Dtos;
using Onion.Core.Models;
using OnionArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        public IEnumerable<BookAuthorDto> GetBookAuthor(int id); 
    }
}
