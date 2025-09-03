using AutoMapper;
using RecruitAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentMatch.Application.DTOs;

namespace TalentMatch.Application.Mappings
{
    public class JobApplicationProfile : Profile
    {
        public JobApplicationProfile()
        {
            CreateMap<JobApplication, JobApplicationResponseModel>();
            CreateMap<CreateJobApplicationRequestModel, JobApplication>();
            CreateMap<UpdateJobApplicationRequestModel, JobApplication>();
        }
    }
}
