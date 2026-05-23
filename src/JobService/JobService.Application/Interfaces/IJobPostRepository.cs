using JobService.Domain.Entities;

namespace JobService.Application.Interfaces;

public interface IJobPostRepository
{
    Task<JobPost?> GetByIdAsync(Guid id);
    Task<IEnumerable<JobPost>> GetAllAsync();
    Task AddAsync(JobPost jobPost);
    Task SaveChangesAsync();
}