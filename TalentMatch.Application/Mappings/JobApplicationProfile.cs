using AutoMapper;
using RecruitAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentMatch.Application.Mappings
{
    public class JobApplicationProfile : Profile
    {
        public JobApplicationProfile()
        {
            CreateMap<JobApplication, UseCases.JobApplication.JobApplicationResponseModel>()
                .ForMember(dest => dest.CandidateName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.Job.Title));

            CreateMap<UseCases.JobApplication.CreateJobApplicationRequestModel, JobApplication>();

            CreateMap<UseCases.JobApplication.UpdateJobApplicationRequestModel, JobApplication>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.LinkedIn, opt => opt.MapFrom(src => src.LinkedIn))
                .ForMember(dest => dest.CV, opt => opt.MapFrom(src => src.CV));
        }
    }
}
