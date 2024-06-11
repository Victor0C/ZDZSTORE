using AutoMapper;
using ZDZSTORE.User.DTO;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.User.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, UserModel>();
            CreateMap<UserModel, ResponseUserDTO>();
            CreateMap<UserModel, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, UserModel>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
