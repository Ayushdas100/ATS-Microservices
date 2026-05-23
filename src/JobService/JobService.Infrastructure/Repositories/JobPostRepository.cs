using JobService.Application.Interfaces;
using JobService.Domain.Entities;
using JobService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JobService.Infrastructure.Repositories;

public class JobPostRepository : IJobPostRepository
{
    private readonly JobDbContext _context;

    public JobPostRepository(JobDbContext context)
    {
        _context = context;
    }

    public async Task<JobPost?> GetByIdAsync(Guid id)
    {
        return await _context.JobPosts.FindAsync(id);
    }

    public async Task<IEnumerable<JobPost>> GetAllAsync()
    {
        return await _context.JobPosts.ToListAsync();
    }

    public async Task AddAsync(JobPost jobPost)
    {
        await _context.JobPosts.AddAsync(jobPost);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}