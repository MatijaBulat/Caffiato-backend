using AutoMapper;
using Caffiato.Dtos.CaffeDtos;

namespace Caffiato.Services.CaffeServices
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
            serviceResponse.Data = await caffiatoDBContext
                .Caffes.OrderBy(c => c.Idcafe)
                .Select(c => mapper.Map<GetCaffeDto>(c))
                .LastAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCaffeDto>>> DeleteCaffe(int id)
        {
            ServiceResponse<List<GetCaffeDto>> response  = new ServiceResponse<List<GetCaffeDto>>();
            try
            {
                Caffe caffe = await caffiatoDBContext.Caffes.FirstOrDefaultAsync(c => c.Idcafe == id);
                if (caffe != null)
                {
                    caffiatoDBContext.Remove(caffe);
                    await caffiatoDBContext.SaveChangesAsync();
                    response.Data = caffiatoDBContext.Caffes.Select(c => mapper.Map<GetCaffeDto>(c)).ToList();
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
            var caffe = await caffiatoDBContext.Caffes.FindAsync(id);
            serviceResponse.Data = mapper.Map<GetCaffeDto>(caffe);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCaffeDto>> UpdateCaffe(UpdateCaffeDto updatedCaffe)
        {
            ServiceResponse<GetCaffeDto> response = new ServiceResponse<GetCaffeDto>();

            try
            {
                var caffe = await caffiatoDBContext.Caffes.FirstOrDefaultAsync(c => c.Idcafe == updatedCaffe.Idcafe);

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
