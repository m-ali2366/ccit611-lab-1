using Backend.Service.Data.Models.User;
using Mapster;

namespace Backend.Service.Features.User.CreateUser
{
    public class UserToCreate
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public ApplicationRoleOption Role { get; set; }
    }
    public class UserToCreateMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserToCreate, Models.User>();



        }
    }
}
