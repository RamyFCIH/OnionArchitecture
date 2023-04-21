using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Models
{
    public class Book
    {
        public int Id { get; set; } 
        public string? Title { get; set; }

        public int AuthorId { get; set; }

        public int? PublisherId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public Publisher Publisher { get; set; }
    }
}
