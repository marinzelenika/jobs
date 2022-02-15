using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_5_role_based_authorization_api.Entities;

namespace dotnet_5_role_based_authorization_api.Repositories
{
    public interface IJobPostRepository
    {
        Task<List<JobPost>> GetAllAsync();
        Task<JobPost> GetByIdAsync(int id);
        void Add(JobPost entity);
        void Update(JobPost entity);
        void Remove(JobPost entity);
        Task SaveAsync();
    }
}