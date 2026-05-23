using JobService.Application.DTOs;
using JobService.Domain.Entities;

namespace JobService.Application.Interfaces;

public interface IJobPostService
{
    Task<Guid> CreateJobAsync(CreateJobPostDto dto);
    Task<IEnumerable<JobPost>> GetAllJobsAsync();
}