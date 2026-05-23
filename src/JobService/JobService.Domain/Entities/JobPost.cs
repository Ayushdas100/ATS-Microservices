using JobService.Domain.Enums;

namespace JobService.Domain.Entities;

public class JobPost
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Department { get; private set; }
    public string Location { get; private set; }
    public JobStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // This is for Entity Framework (it needs a parameterless constructor)
    protected JobPost() { }

    // This is how we enforce creating a VALID JobPost right from the start
    public JobPost(string title, string description, string department, string location)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Department = department;
        Location = location;
        Status = JobStatus.Draft; // All jobs start as a draft
        CreatedAt = DateTime.UtcNow;
    }

    public void Publish()
    {
        Status = JobStatus.Published;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Close()
    {
        Status = JobStatus.Closed;
        UpdatedAt = DateTime.UtcNow;
    }
}