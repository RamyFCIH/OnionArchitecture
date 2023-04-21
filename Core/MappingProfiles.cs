using AutoMapper;
using Core.Dtos;
using Core.Resolvers;
using Onion.Core.Models;

namespace Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookAuthorDto>().ForMember(d => d.ImageUrl , o => o.MapFrom<BookImageResolver>());
        }
    }
}
