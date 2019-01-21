using AutoMapper;
using NetWorth.Application.Interfaces.Mapping;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Users.Queries.GetUsersList
{
    public class UserLookupModel : IHaveCustomMapping
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<User, UserLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.UserName, opt => opt.MapFrom(c => c.UserName));
        }
    }
}