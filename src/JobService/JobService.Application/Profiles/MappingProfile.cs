using AutoMapper;
using JobService.Application.DTOs;
using JobService.Domain.Entities;

namespace JobService.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // This tells AutoMapper: "You are allowed to convert a JobPost entity into a JobPostDto"
        CreateMap<JobPost, JobPostDto>();
    }
}