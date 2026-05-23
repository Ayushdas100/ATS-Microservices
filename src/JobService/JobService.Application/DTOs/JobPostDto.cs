namespace JobService.Application.DTOs;

public record JobPostDto(
    Guid Id,
    string Title,
    string Description,
    string Department,
    string Location,
    string Status, // AutoMapper will automatically convert the JobStatus Enum to a string!
    DateTime CreatedAt
);