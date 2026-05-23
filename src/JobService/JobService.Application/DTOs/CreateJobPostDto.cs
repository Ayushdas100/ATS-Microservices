using System;
using System.Collections.Generic;
using System.Text;

namespace JobService.Application.DTOs
{

    public record CreateJobPostDto(
        string Title,
        string Description,
        string Department,
        string Location
    );
   
}
