using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models.JobPost;
using WebApi.Services.JobPostService;

namespace WebApi.Controllers
{
        [ApiController]
        [Route("api/JobPosts")]
        public class JobPostController : ControllerBase
        {
            private readonly IJobPostService _JobPostService;

            public JobPostController(IJobPostService JobPostService)
            {
                _JobPostService = JobPostService;
            }


            [HttpGet]
            public async Task<IActionResult> GetJobPostsAsync()
            {
                return Ok(await _JobPostService.GetAllJobPostsAsync());
            }

            [HttpPost]
            public async Task<IActionResult> CreateAsync(InsertJobPostDto insertJobPostDto)
            {
                return Ok(await _JobPostService.InsertJobPostAsync(insertJobPostDto));
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetJobPostAsync(int id)
            {
                return Ok(await _JobPostService.GetJobPostAsync(id));
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAsync(int id)
            {
                return Ok(await _JobPostService.DeleteJobPostAsync(id));
            }

            [HttpPut]
            public async Task<IActionResult> UpdateAsync(EditJobPostDto editJobPostDto)
            {
                return Ok(await _JobPostService.UpdateJobPostAsync(editJobPostDto));
            }
        }
    }


