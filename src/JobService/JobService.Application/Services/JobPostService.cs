using JobService.Application.DTOs;
using JobService.Application.Interfaces;
using JobService.Domain.Entities;

namespace JobService.Application.Services;

public class JobPostService : IJobPostService
{
    private readonly IJobPostRepository _repository;

    // Dependency Injection! We inject the interface, not a concrete database class.
    public JobPostService(IJobPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateJobAsync(CreateJobPostDto dto)
    {
        // 1. Map DTO to Domain Entity
        var jobPost = new JobPost(dto.Title, dto.Description, dto.Department, dto.Location);

        // 2. Add to Repository
        await _repository.AddAsync(jobPost);

        // 3. Save Changes
        await _repository.SaveChangesAsync();

        return jobPost.Id;
    }

    public async Task<IEnumerable<JobPost>> GetAllJobsAsync()
    {
        return await _repository.GetAllAsync();
    }
}