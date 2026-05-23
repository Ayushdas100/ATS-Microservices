using AutoMapper;
using JobService.Application.DTOs;
using JobService.Application.Interfaces;
using JobService.Domain.Entities;

namespace JobService.Application.Services;

public class JobPostService : IJobPostService
{
    private readonly IJobPostRepository _repository;
    private readonly IMapper _mapper;

    // Inject IMapper here
    public JobPostService(IJobPostRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> CreateJobAsync(CreateJobPostDto dto)
    {
        var jobPost = new JobPost(dto.Title, dto.Description, dto.Department, dto.Location);
        await _repository.AddAsync(jobPost);
        await _repository.SaveChangesAsync();
        return jobPost.Id;
    }

    public async Task<IEnumerable<JobPostDto>> GetAllJobsAsync()
    {
        var jobs = await _repository.GetAllAsync();

        // Let AutoMapper do the heavy lifting!
        return _mapper.Map<IEnumerable<JobPostDto>>(jobs);
    }
}