using FluentValidation;
using JobService.Application.DTOs;

namespace JobService.Application.Validators;

public class CreateJobPostDtoValidator : AbstractValidator<CreateJobPostDto>
{
    public CreateJobPostDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Job title is required.")
            .MaximumLength(200).WithMessage("Job title cannot exceed 200 characters.")
            // Enforce that the title must contain at least one letter
            .Matches(@"[a-zA-Z]").WithMessage("Job title must contain valid words, not just numbers or symbols.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Job description is required.");

        RuleFor(x => x.Department)
            .NotEmpty().WithMessage("Department is required.")
            .MaximumLength(100).WithMessage("Department cannot exceed 100 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(100).WithMessage("Location cannot exceed 100 characters.")
            // Enforce that the location must contain at least one letter
            .Matches(@"[a-zA-Z]").WithMessage("Location must contain valid characters, not just numbers.");
    }
}