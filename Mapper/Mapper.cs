using AutoMapper;
using SimplyBooks.DTOs;
using SimplyBooks.Models;
namespace SimplyBooks.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorEditDTO>().ReverseMap();
            CreateMap<Author, AuthorCreateDTO>().ReverseMap();
        }
    }
}
