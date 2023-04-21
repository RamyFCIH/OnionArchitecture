using Core.Dtos;
using Core.Interfaces;
using Onion.Core.Models;
using OnionArchitecture.EF.Repositories;
using Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BookService : BaseRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<BookAuthorDto> GetBookAuthor(int id)
        {
            var data = from book in _context.Books.Where(x => x.Id == id)
                       from author in _context.Authors.Where(x => x.Id == book.AuthorId)
                       select new BookAuthorDto
                       {
                           AuthorId = author.Id,
                           AuthorName = author.Name,
                           BookName = book.Title
                       };
            return data;
        }
    }
}
