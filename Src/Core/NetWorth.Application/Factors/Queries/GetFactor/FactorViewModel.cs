using AutoMapper;
using NetWorth.Application.Interfaces.Mapping;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Factors.Queries.GetFactor
{
    public class FactorViewModel : IHaveCustomMapping
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double CurrentValue { get; set; } 

        public bool HasInterest { get; set; }

        public double InterestRate { get; set; }

        public int Type { get; set; }  

        public long UserID { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<NWFactor, FactorViewModel>()
                .ForMember(pDTO => pDTO.EditEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(pDTO => pDTO.DeleteEnabled, opt => opt.MapFrom<PermissionsResolver>())
                .ForMember(fDTO => fDTO.UserID, opt => opt.MapFrom(p => p.User != null ? p.User.Id : 0));
        }

        class PermissionsResolver : IValueResolver<NWFactor, FactorViewModel, bool>
        {
            // TODO: inject your services and helper here
            public PermissionsResolver()
            {
               
            }

            public bool Resolve(NWFactor source, FactorViewModel dest, bool destMember, ResolutionContext context)
            {
                    return false;
            }
        }
    }
}