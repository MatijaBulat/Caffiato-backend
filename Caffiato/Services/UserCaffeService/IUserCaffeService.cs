using Caffiato.Dtos.UserCaffeDtos;

namespace Caffiato.Services.UserCaffeService
{
    public interface IUserCaffeService
    {
        Task<ServiceResponse<GetUserCaffeDto>> GetUserCaffeById(int id);
        Task<ServiceResponse<GetUserCaffeDto>> GetUserCaffeByEmail(string email);
        Task<ServiceResponse<GetUserCaffeDto>> AddUserCaffe(AddUserCaffeDto user);

    }
}
