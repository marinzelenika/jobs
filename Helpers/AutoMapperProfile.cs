using AutoMapper;
using jobs.Models.Users;
using WebApi.Entities;

namespace jobs.Helpers
{
    public class AutoMapperProfile : Profile
    {
         public AutoMapperProfile()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}