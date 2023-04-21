using Core.Interfaces;
using Onion.Core.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BookWithAuthorAndPublisherSpecification : BaseSpecification<Book>
    {
        public BookWithAuthorAndPublisherSpecification()
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.Publisher);   
        }

        public BookWithAuthorAndPublisherSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.Publisher);
        }
    }
}
