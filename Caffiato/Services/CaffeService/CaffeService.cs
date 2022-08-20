using AutoMapper;
using Caffiato.Dtos.CaffeDtos;

namespace Caffiato.Services.CaffeService
{
    public class CaffeService : ICaffeService
    {
        private readonly CaffiatoDBContext caffiatoDBContext;
        private readonly IMapper mapper;
        public CaffeService(CaffiatoDBContext caffiatoDBContext, IMapper mapper)
        {
            this.caffiatoDBContext = caffiatoDBContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetCaffeDto>> AddCaffe(AddCaffeDto caffe)
        {
            var serviceResponse = new ServiceResponse<GetCaffeDto>();
            caffiatoDBContext.Caffes.Add(mapper.Map<Caffe>(caffe));
            await caffiatoDBContext.SaveChangesAsync();

            serviceResponse.Data = await caffiatoDBContext.Caffes
                .OrderBy(c => c.Id)
                .Include(c => c.Addresses)
                .Include(c => c.Deals)
                .Select(c => mapper.Map<GetCaffeDto>(c))
                .LastAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCaffeDto>>> DeleteCaffe(int id)
        {
            ServiceResponse<IEnumerable<GetCaffeDto>> response = new ServiceResponse<IEnumerable<GetCaffeDto>>();
            try
            {
                Caffe caffe = await caffiatoDBContext.Caffes.FirstOrDefaultAsync(c => c.Id == id);
                if (caffe != null)
                {
                    Address address = await caffiatoDBContext.Addresses.FirstOrDefaultAsync(a => a.CaffeId == caffe.Id);
                    if (address != null)
                    {
                        caffiatoDBContext.Addresses.Remove(address);
                    }

                    caffiatoDBContext.Deals.RemoveRange(caffiatoDBContext.Deals.Where(d => d.CaffeId == caffe.Id));

                    
                    caffiatoDBContext.Caffes.Remove(caffe);
                    await caffiatoDBContext.SaveChangesAsync();

                    response.Data = caffiatoDBContext.Caffes
                        .Include(c => c.Addresses)
                        .Include(c => c.Deals)
                        .Select(c => mapper.Map<GetCaffeDto>(c)).ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Caffe not found";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCaffeDto>> GetCaffeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCaffeDto>();
            var caffe = await caffiatoDBContext.Caffes
                .Include(c => c.Addresses)
                .Include(c => c.Deals)
                .FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = mapper.Map<GetCaffeDto>(caffe);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCaffeDto>> UpdateCaffe(UpdateCaffeDto updatedCaffe)
        {
            ServiceResponse<GetCaffeDto> response = new ServiceResponse<GetCaffeDto>();

            try
            {
                var caffe = await caffiatoDBContext.Caffes
                    .Include(c => c.Addresses)
                    .Include(c => c.Deals)
                    .FirstOrDefaultAsync(c => c.Id == updatedCaffe.Id);

                if (caffe != null)
                {
                    caffe.Name = updatedCaffe.Name;
                    caffe.UserCaffeId = updatedCaffe.UserCaffeId;

                    await caffiatoDBContext.SaveChangesAsync();

                    response.Data = mapper.Map<GetCaffeDto>(caffe);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Caffe not found.";
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
