using AutoMapper;
using Caffiato.Dtos.DealDtos;

namespace Caffiato.Services.DealService
{
    public class DealService : IDealService
    {
        private readonly CaffiatoDBContext caffiatoDBContext;
        private readonly IMapper mapper;

        public DealService(CaffiatoDBContext caffiatoDBContext, IMapper mapper)
        {
            this.caffiatoDBContext = caffiatoDBContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetDealDto>> AddDeal(AddDealDto deal)
        {
            var serviceResponse = new ServiceResponse<GetDealDto>();
            caffiatoDBContext.Deals.Add(mapper.Map<Deal>(deal));
            await caffiatoDBContext.SaveChangesAsync();
            serviceResponse.Data = await caffiatoDBContext.Deals
                .OrderBy(d => d.Iddeal)
                .Select(d => mapper.Map<GetDealDto>(d))
                .LastAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetDealDto>>> DeleteDeal(int id)
        {

            ServiceResponse<IEnumerable<GetDealDto>> response = new ServiceResponse<IEnumerable<GetDealDto>>();
            try
            {
                Deal deal = await caffiatoDBContext.Deals.FirstOrDefaultAsync(d => d.Iddeal == id);
                if (deal != null)
                {
                    caffiatoDBContext.Deals.Remove(deal);
                    await caffiatoDBContext.SaveChangesAsync();
                    response.Data = caffiatoDBContext.Deals.Select(d => mapper.Map<GetDealDto>(d)).ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Deal not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetDealDto>> GetDealById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDealDto>();
            var deal = await caffiatoDBContext.Deals.FindAsync(id);
            serviceResponse.Data = mapper.Map<GetDealDto>(deal);

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetDealDto>>> GetDeals()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<GetDealDto>>();
            var deals = await caffiatoDBContext.Deals.ToListAsync();
            serviceResponse.Data = deals.Select(d => mapper.Map<GetDealDto>(d)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDealDto>> UpdateDeal(UpdateDealDto updatedDeal)
        {
            ServiceResponse<GetDealDto> response = new ServiceResponse<GetDealDto>();

            try
            {
                var deal = await caffiatoDBContext.Deals.FirstOrDefaultAsync(d => d.Iddeal == updatedDeal.Iddeal);

                if (deal != null)
                {
                    deal.Name = updatedDeal.Name;
                    deal.DateTime = updatedDeal.DateTime;
                    deal.Points = updatedDeal.Points;
                    deal.Price = updatedDeal.Price;
                    deal.Active = updatedDeal.Active;

                    await caffiatoDBContext.SaveChangesAsync();

                    response.Data = mapper.Map<GetDealDto>(deal);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Deal not found.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetDealDto>> UpdateDealActivity(UpdateDealActivityDto updatedDeal)
        {
            ServiceResponse<GetDealDto> response = new ServiceResponse<GetDealDto>();

            try
            {
                var deal = await caffiatoDBContext.Deals.FirstOrDefaultAsync(d => d.Iddeal == updatedDeal.Iddeal);

                if (deal != null)
                {
                    deal.Active = updatedDeal.Active;

                    await caffiatoDBContext.SaveChangesAsync();

                    response.Data = mapper.Map<GetDealDto>(deal);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Deal not found.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
