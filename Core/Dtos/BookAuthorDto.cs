﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class BookAuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BookName { get; set; }

        public string ImageUrl { get; set; }
    }
}
