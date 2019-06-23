using System;
using System.Linq.Expressions;
using AutoMapper;
using NetWorth.Application.Interfaces.Mapping;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Contributions.Queries.GetAllContributions
{
    public class ContributionDto : IHaveCustomMapping
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; } 
        public long FactorID { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Contribution, ContributionDto>()
                .ForMember(fDTO => fDTO.FactorID, opt => opt.MapFrom(p => p.FactorID != null ? p.FactorID : new object()));
        }
    }
}