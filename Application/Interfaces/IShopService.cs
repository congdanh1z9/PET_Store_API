﻿using Application.ServiceReponses;
using Application.ViewModels.ShopDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShopService
    {
        Task<ServiceResponse<List<ShopViewDTO>>> ViewAllShops();
        Task<ServiceResponse<string>> CreateShop(CreateShopDTO createShopDTO);
        Task<ServiceResponse<string>> UpdateShop(int id, UpdateShopDTO updateShopDTO);
    }
}
