﻿using AutoMapper;
using Caffiato.Dtos.UserCaffeDtos;

namespace Caffiato.Services.UserCaffeService
{
    public class UserCaffeService : IUserCaffeService
    {
        private readonly CaffiatoDBContext caffiatoDBContext;
        private readonly IMapper mapper;

        public UserCaffeService(CaffiatoDBContext caffiatoDBContext, IMapper mapper)
        {
            this.caffiatoDBContext = caffiatoDBContext;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetUserCaffeDto>> AddUserCaffe(AddUserCaffeDto user)
        {
            var serviceResponse = new ServiceResponse<GetUserCaffeDto>();
            caffiatoDBContext.UserCaffes.Add(mapper.Map<UserCaffe>(user));
            await caffiatoDBContext.SaveChangesAsync();
            serviceResponse.Data = await caffiatoDBContext.UserCaffes
                .OrderBy(u => u.IduserCaffe)
                .Select(u => mapper.Map<GetUserCaffeDto>(u))
                .LastAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserCaffeDto>> GetUserCaffeByEmail(string email)
        {
            var serviceResponse = new ServiceResponse<GetUserCaffeDto>();
            var userCaffe = await caffiatoDBContext.UserCaffes.FirstOrDefaultAsync(u => u.Email == email);
            serviceResponse.Data = mapper.Map<GetUserCaffeDto>(userCaffe);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserCaffeDto>> GetUserCaffeById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserCaffeDto>();
            var userCaffe = await caffiatoDBContext.UserCaffes
                .Include(u => u.Caffes)
                    .ThenInclude(c => c.Deals)
                .Include(u => u.Caffes)
                    .ThenInclude(c => c.Addresses)
                .Include(u => u.Transacts)
                .FirstOrDefaultAsync(u => u.IduserCaffe == id);
            serviceResponse.Data = mapper.Map<GetUserCaffeDto>(userCaffe);

            return serviceResponse;
        }
    }
}
