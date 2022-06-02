using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;

namespace CourseLibrary.API.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            //Projecton destination name from source firstname and lastname
            CreateMap<Entities.Author, AuthorDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge(src.DateOfDeath)));

            CreateMap<AuthorForCreationDto, Entities.Author>();

            CreateMap<AuthorForCreationWithDateOfDeathDto, Entities.Author>(); 

            CreateMap<Entities.Author, Models.AuthorFullDto>();
        }
    }
}
