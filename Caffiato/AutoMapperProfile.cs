using AutoMapper;
using Caffiato.Dtos.UserCaffe;

namespace Caffiato
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCaffe, GetUserCaffeDto>();
            CreateMap<AddUserCaffeDto, UserCaffe>();
        }
    }
}
