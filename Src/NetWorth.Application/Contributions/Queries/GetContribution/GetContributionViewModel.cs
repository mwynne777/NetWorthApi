using AutoMapper;
using NetWorth.Application.Interfaces.Mapping;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Contributions.Queries.GetContribution
{
    public class ContributionViewModel : IHaveCustomMapping
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; } 

        public long UserID { get; set; }

        public long FactorID { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Contribution, ContributionViewModel>()
                .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(fDTO => fDTO.UserID, opt => opt.MapFrom(c => c.FactorID != null ? c.FactorID : new object()));
        }

        class PermissionsResolver : IValueResolver<Contribution, ContributionViewModel, bool>
        {
            // TODO: inject your services and helper here
            public PermissionsResolver()
            {
               
            }

            public bool Resolve(Contribution source, ContributionViewModel dest, bool destMember, ResolutionContext context)
            {
                    return false;
            }
        }
    }
}