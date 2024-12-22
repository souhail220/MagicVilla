﻿using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaNbService : BaseService, IVillaNbService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly string villaNbUrl;
        public VillaNbService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            this.clientFactory = clientFactory;
            this.villaNbUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI")
                ?? throw new ArgumentNullException(nameof(configuration), "ServiceUrls configuration is missing");
        }
        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.GET,
                Url = villaNbUrl + "/api/VillaNumberAPIController"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.GET,
                Url = villaNbUrl + "/api/VillaNumberAPIController/" + id
            });
        }

        public Task<T> CreateAsync<T>(VillaNbRequestDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.POST,
                Data = dto,
                Url = villaNbUrl + "/api/VillaNumberAPIController"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.DELETE,
                Url = villaNbUrl + "/api/VillaNumberAPIController/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaNbRequestDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = MagicVilla_Utility.SD.ApiType.PUT,
                Data = dto,
                Url = villaNbUrl + "/api/VillaNumberAPIController/" + dto.VillaNumber
            });
        }
    }
}
