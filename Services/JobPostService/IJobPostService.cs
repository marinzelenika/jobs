using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models.JobPost;

namespace WebApi.Services.JobPostService
{
    public interface IJobPostService
    {
        Task<List<JobPostReadDto>> GetAllJobPostsAsync();
        Task<JobPostReadDto> GetJobPostAsync(int id);
        Task<JobPostReadDto> InsertJobPostAsync(InsertJobPostDto insertJobPostDto);
        Task<JobPostReadDto> UpdateJobPostAsync(EditJobPostDto editedJobPost);
        Task<List<JobPostReadDto>> DeleteJobPostAsync(int id);
    }
}
