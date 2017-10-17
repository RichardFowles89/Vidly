using AutoMapper;
using VidlyTakeTwo.Dtos;
using VidlyTakeTwo.Models;

namespace VidlyTakeTwo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {//The ForMember() method allows us to not update the ID. This would throw an exception
            Mapper.CreateMap<Customer, CustomerDto>();//maps (source) Customer to (target) CustomerDto
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());//maps target to source
                                                                                                //AutoMapper uses reflection to scan the objects and map their properties based on their name.

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}