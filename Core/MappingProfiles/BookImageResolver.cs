using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoMapper.Execution;
using Onion.Core.Models;
using Core.Dtos;
using Microsoft.Extensions.Configuration;

namespace Core.Resolvers
{
    public class BookImageResolver : IValueResolver<Book, BookAuthorDto, string>
    {
        private readonly IConfiguration _config;

        public BookImageResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Book source, BookAuthorDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["apiUrl"] + source.ImageUrl;
            }
            return null;
        }

    }
}
