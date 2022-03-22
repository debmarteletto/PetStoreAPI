using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    public interface IPetService
    {   
        Task<RestResponse> GetById(Int64 id);
        Task<RestResponse> GetByStatus(string status);
        Task<RestResponse> Create(Pet pet);
        Task<RestResponse> Update(Pet pet);
        Task<RestResponse> Delete(Int64 id);
        Task<RestResponse> UploadImageToAPetByID(long id, byte[] file);
    }
}