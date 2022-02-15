using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_5_role_based_authorization_api.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace dotnet_5_role_based_authorization_api.Repositories
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly DataContext _context;
        public JobPostRepository(DataContext context)
        {
            _context = context;

        }

        public void Add(JobPost entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Add<JobPost>(entity);
        }

        public async Task<List<JobPost>> GetAllAsync()
        {
            return await _context.JobPosts.Where(u => u.Invalidated == false).ToListAsync();
        }

        public async Task<JobPost> GetByIdAsync(int id)
        {
            return await _context.JobPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(JobPost entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            //_context.Remove<TEntity>(entity); - we do not remove stuff from DB
            entity.Invalidated = true;
        }

        public void Update(JobPost entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Entry<JobPost>(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}