using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    public interface IUserService
    {
        Task<RestResponse> Create(User[] user);
        Task<RestResponse> Create(List<User> user);
        Task<RestResponse> GetByUserName(string userName);
        Task<RestResponse> Update(User user);
        Task<RestResponse> Delete(string userName);
        Task<RestResponse> GetByUserNameAndPassword(string userName, string password);
        Task<RestResponse> GetByUserLogout();
        Task<RestResponse> Create(User user);
    }
}