using AutoMapper;
using dotnet_5_role_based_authorization_api.Entities;
using jobs.Models.Users;
using WebApi.Entities;
using WebApi.Models.JobPost;

namespace jobs.Helpers
{
    public class AutoMapperProfile : Profile
    {
         public AutoMapperProfile()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<JobPostReadDto, JobPost>();
            CreateMap<InsertJobPostDto, JobPost>();
            CreateMap<EditJobPostDto, JobPost>();
        }
    }
}