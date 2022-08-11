using AutoMapper;
using Caffiato.Dtos.AddressDtos;
using Caffiato.Dtos.CaffeDtos;
using Caffiato.Dtos.UserCaffeDtos;

namespace Caffiato
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCaffe, GetUserCaffeDto>();
            CreateMap<AddUserCaffeDto, UserCaffe>();
            CreateMap<Caffe, GetCaffeDto>();
            CreateMap<AddCaffeDto, Caffe>();
            CreateMap<Address, GetAddressDto>();
            CreateMap<AddAddressDto, Address>();
        }
    }
}
