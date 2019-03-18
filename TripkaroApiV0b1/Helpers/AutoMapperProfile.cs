using AutoMapper;
using TripkaroApiV0b1.Dtos;
using TripkaroApiV0b1.MyDbContext;

namespace TripkaroApiV0b1.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<CurrentTrip, User>();
            CreateMap<CurrentTripDtos, UserDto>();
            CreateMap<CurrentTripDtos, User>();
            CreateMap<CurrentTrip, UserDto>();
        }
    }
}
