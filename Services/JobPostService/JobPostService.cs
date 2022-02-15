using AutoMapper;
using dotnet_5_role_based_authorization_api.Entities;
using dotnet_5_role_based_authorization_api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.JobPost;
using WebApi.Services.JobPostService;

namespace dotnet_5_role_based_authorization_api.Services.JobPostService
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepository _JobPostRepository;
        private readonly IMapper _mapper;
        public JobPostService(IJobPostRepository JobPostRepository, IMapper mapper)
        {
            _mapper = mapper;
            _JobPostRepository = JobPostRepository;

        }

        public async Task<List<JobPostReadDto>> GetAllJobPostsAsync()
        {
            List<JobPost> JobPosts = await _JobPostRepository.GetAllAsync();
            var response = (JobPosts.Select(pc => _mapper.Map<JobPostReadDto>(pc))).ToList();
            return response;
        }

        public async Task<JobPostReadDto> GetJobPostAsync(int id)
        {
            JobPost JobPost = await _JobPostRepository.GetByIdAsync(id);
            var response = _mapper.Map<JobPostReadDto>(JobPost);
            return response;
        }

        public async Task<JobPostReadDto> InsertJobPostAsync(InsertJobPostDto insertJobPostDto)
        {
            JobPost JobPost = _mapper.Map<JobPost>(insertJobPostDto);
            _JobPostRepository.Add(JobPost);
            await _JobPostRepository.SaveAsync();

            var response = _mapper.Map<JobPostReadDto>(JobPost);

            return response;
        }

        public async Task<JobPostReadDto> UpdateJobPostAsync(EditJobPostDto editedJobPost)
        {
           
                JobPost JobPost = await _JobPostRepository.GetByIdAsync(editedJobPost.Id);
                _mapper.Map(editedJobPost, JobPost);

                _JobPostRepository.Update(JobPost);
                await _JobPostRepository.SaveAsync();
                var response = _mapper.Map<JobPostReadDto>(JobPost);
                return response;
        }

        public async Task<List<JobPostReadDto>> DeleteJobPostAsync(int id)
        {
            JobPost JobPost = await _JobPostRepository.GetByIdAsync(id);
            _JobPostRepository.Remove(JobPost);
            await _JobPostRepository.SaveAsync();
            List<JobPost> JobPosts = await _JobPostRepository.GetAllAsync();
            var data = (JobPosts.Select(p => _mapper.Map<JobPostReadDto>(p))).ToList();
            return data;

        }

       
    }
}