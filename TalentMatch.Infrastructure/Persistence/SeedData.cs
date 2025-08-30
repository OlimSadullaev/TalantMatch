using Microsoft.EntityFrameworkCore;
using RecruitAI.Domain.Entities;
using RecruitAI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentMatch.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = Guid.NewGuid(),
                    Title = "Middle .NET Engineer",
                    Location = "21a Taras Shevchenko St, 100060. Tashkent, Uzbekistan",
                    KeyResponsibilities = @"Developing our solution set with a commitment to deliver high-quality code to production
                            Participating in the full cycle of software application and business logic development
                            Participate in demo sessions, Scrum ceremonies and Idea Talks
                            Participating in project estimation and planning
                            Conducting code reviews & writing code tests
                            Working on continuous technology integration
                            If desired, participation in technical interviews and/or mentoring, knowledge sharing in dev2dev/meetup format (including external events)",
                    Qualifications = new List<string>
                        {
                            "At least 2 years of practical experience with .NET",
                            "Knowledge of .NET, ASP.NET / ASP.NET MVC, MS SQL Server",
                            "Knowledge of JavaScript frameworks: Angular / React / Vue.js / Ember.js",
                            "B2 level of English or higher, and experience in communicating with English-speaking customers",
                            "A desire to improve your skills and keep abreast of the latest technological advances in .NET development"
                        },
                    About_Us = @"At Vention, we assemble senior-level, dedicated teams of developers to help fast-growing startups and innovative 
                            enterprises drive impact and achieve their goals. We’ve delivered solutions across multiple domains, including 
                            FinTech, PropTech, AdTech, HealthTech, e-commerce, and more.",
                    Benefits = @"An individualized approach to career development, tailoring growth plans to every role
                            Access to our technology mentorship program as a mentor or mentee
                            Expanded medical support for employees in Tashkent
                            19 working days of vacation per year, 21 after two years in the company
                            Сonferences & meetups, organized by our company
                            Corporate getaway & teambuilding activities
                            Referral bonuses",
                    FitScore = 0,
                    PostedDate = DateTime.UtcNow,
                    RecruiterId = Guid.NewGuid(),
                    User = UserRole.Recruiter
                },

                new Job
                {
                    Id = Guid.NewGuid(),
                    Title = "Frontend Engineer (React)",
                    Location = "Remote – Uzbekistan / Hybrid in Tashkent",
                    KeyResponsibilities = @"Build modern, responsive web applications using React and TypeScript
                            Collaborate with backend engineers to integrate APIs
                            Ensure cross-browser compatibility and performance optimization
                            Participate in code reviews, technical discussions, and agile ceremonies
                            Contribute to UI/UX improvements and accessibility compliance",
                    Qualifications = new List<string>
                        {
                            "3+ years of experience in frontend development",
                            "Strong skills in React, TypeScript, and modern JavaScript (ES6+)",
                            "Experience with state management (Redux, Zustand, or Recoil)",
                            "Understanding of REST APIs and GraphQL",
                            "Familiarity with automated testing (Jest, Cypress)"
                        },
                    About_Us = @"We are a fast-growing SaaS company building data-driven products for global customers. Our team values collaboration, 
                            innovation, and quality engineering practices.",
                    Benefits = @"Competitive salary and performance bonuses
                            Flexible working hours and remote-first policy
                            Professional development budget for courses, certifications, and conferences
                            Health insurance package
                            Team retreats and hackathons",
                    FitScore = 0,
                    PostedDate = DateTime.UtcNow,
                    RecruiterId = Guid.NewGuid(),
                    User = UserRole.Recruiter
                },

                new Job
                {
                    Id = Guid.NewGuid(),
                    Title = "Cloud Engineer (AWS/Azure)",
                    Location = "Tashkent, Uzbekistan",
                    KeyResponsibilities = @"Design and implement scalable cloud infrastructure
                            Maintain CI/CD pipelines and automate deployments
                            Ensure system reliability, security, and compliance
                            Work closely with developers to optimize application performance
                            Implement monitoring, logging, and incident response practices",
                    Qualifications = new List<string>
                        {
                            "Experience with AWS or Microsoft Azure cloud services",
                            "Strong knowledge of Docker and Kubernetes",
                            "Proficiency with Infrastructure as Code (Terraform, Bicep, or CloudFormation)",
                            "Experience with CI/CD (GitHub Actions, GitLab CI, or Azure DevOps)",
                            "Good understanding of networking, load balancing, and cloud security"
                        },
                    About_Us = @"We specialize in building cloud-native platforms for fintech and e-commerce clients. Our engineering culture emphasizes 
                            automation, reliability, and continuous learning.",
                    Benefits = @"Attractive compensation package
                            Private medical insurance
                            Flexible working schedule
                            Company-sponsored certifications (AWS/Azure/GCP)
                            Annual team offsite abroad",
                    FitScore = 0,
                    PostedDate = DateTime.UtcNow,
                    RecruiterId = Guid.NewGuid(),
                    User = UserRole.Recruiter
                }   
            );
        }
    }
}
