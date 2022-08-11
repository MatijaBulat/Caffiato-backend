using Caffiato.Dtos.CaffeDtos;

namespace Caffiato.Services.CaffeService
{
    public interface ICaffeService
    {
        Task<ServiceResponse<GetCaffeDto>> GetCaffeById(int id);
        Task<ServiceResponse<GetCaffeDto>> AddCaffe(AddCaffeDto caffe);
        Task<ServiceResponse<GetCaffeDto>> UpdateCaffe(UpdateCaffeDto updatedCaffe);
        Task<ServiceResponse<List<GetCaffeDto>>> DeleteCaffe(int id);
    }
}
