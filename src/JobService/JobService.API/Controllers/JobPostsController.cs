using JobService.Application.DTOs;
using JobService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobPostsController : ControllerBase
{
    private readonly IJobPostService _jobService;

    public JobPostsController(IJobPostService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] CreateJobPostDto dto)
    {
        var jobId = await _jobService.CreateJobAsync(dto);
        return CreatedAtAction(nameof(GetJobs), new { id = jobId }, jobId);
    }

    [HttpGet]
    public async Task<IActionResult> GetJobs()
    {
        var jobs = await _jobService.GetAllJobsAsync();
        return Ok(jobs);
    }
}