using AutoMapper;
using RecruitAI.Domain.Entities;
using TalentMatch.Application.DTOs;

namespace TalentMatch.Application.Mappings
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, CreateJobRequestModel>();
            CreateMap<CreateJobRequestModel, Job>();
        }
    }
}
