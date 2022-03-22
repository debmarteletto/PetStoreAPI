using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    public interface IStoreService
    {   
        Task<RestResponse> GetById(Int64 id); 
        Task<RestResponse> Delete(Int64 id);
        Task<RestResponse> GetAllStatus();
        Task<RestResponse> Create(Store store);
    }
}