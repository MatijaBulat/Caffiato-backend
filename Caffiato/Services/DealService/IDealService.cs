using Caffiato.Dtos.DealDtos;

namespace Caffiato.Services.DealService
{
    public interface IDealService
    {
        Task<ServiceResponse<IEnumerable<GetDealDto>>> GetDeals();
        Task<ServiceResponse<GetDealDto>> GetDealById(int id);
        Task<ServiceResponse<GetDealDto>> AddDeal(AddDealDto deal);
        Task<ServiceResponse<GetDealDto>> UpdateDeal(UpdateDealDto updatedDeal);
        Task<ServiceResponse<GetDealDto>> UpdateDealActivity(UpdateDealActivityDto updatedDeal);
        Task<ServiceResponse<IEnumerable<GetDealDto>>> DeleteDeal(int id);
    }
}
