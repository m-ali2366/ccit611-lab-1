using Backend.Service.Data.Models.Order;
using Backend.Service.Models;
using Mapster;
using System;

namespace Backend.Service.Features.GetProfiles
{
    public class GetProfilesResult
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }


    }
    public class GetProfilesResultMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Models.Profile, GetProfilesResult>();
        }
    }
}
