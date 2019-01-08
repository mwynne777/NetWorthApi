using System;
using System.Linq.Expressions;
using AutoMapper;
using NetWorth.Application.Interfaces.Mapping;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Factors.Queries.GetAllFactors
{
    public class FactorDto : IHaveCustomMapping
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double CurrentValue { get; set; } 
        public bool HasInterest { get; set; }
        public double InterestRate { get; set; }
        public int Type { get; set; }
        public long UserID { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<NWFactor, FactorDto>()
                .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(p =>  p.Name));
        }
    }
}