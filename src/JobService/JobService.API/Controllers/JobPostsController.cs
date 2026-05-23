using FluentValidation;
using JobService.Application.DTOs;
using JobService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobPostsController : ControllerBase
{
    private readonly IJobPostService _jobService;
    private readonly IValidator<CreateJobPostDto> _validator;
    public JobPostsController(IJobPostService jobService, IValidator<CreateJobPostDto> validator)
    {
        _jobService = jobService;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] CreateJobPostDto dto)
    {
        // 1. Validate the incoming data
        var validationResult = await _validator.ValidateAsync(dto);

        if (!validationResult.IsValid)
        {
            // Return 400 Bad Request with the exact error messages
            return BadRequest(validationResult.Errors);
        }
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