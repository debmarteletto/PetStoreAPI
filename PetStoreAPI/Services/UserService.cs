using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    public class UserService : IUserService
    {
        public async Task<RestResponse> Create(User[] user)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/user/createWithArray", Method.Post) { RequestFormat = DataFormat.Json };
            request.AddBody(user);
            var response = await client.PostAsync(request);

            return response;
        }

        public async Task<RestResponse> Create(List<User> user)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/user/createWithList", Method.Post) { RequestFormat = DataFormat.Json };
            request.AddBody(user);
            var response = await client.PostAsync(request);

            return response;
        }

        public async Task<RestResponse> GetByUserName(string userName)
        {
            var client = new RestClient($"https://petstore.swagger.io");           
            var request = new RestRequest($"/v2/user/{userName}", Method.Get);
            var response = await client.ExecuteAsync(request);           

            return response;
        }

        public async Task<RestResponse> Update(User user)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/user/{user.Username}", Method.Put) { RequestFormat = DataFormat.Json };
            request.AddBody(user);
            var response = await client.PutAsync(request);

            return response;
        }

        public async Task<RestResponse> Delete(string userName)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/user/{userName}", Method.Delete);
            var response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<RestResponse> GetByUserNameAndPassword(string userName, string password)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/user/login?username={userName}&password={password}", Method.Get);
            var response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<RestResponse> GetByUserLogout()
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/user/logout", Method.Get);
            var response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<RestResponse> Create(User user)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/user/", Method.Post) { RequestFormat = DataFormat.Json };
            request.AddBody(user);
            var response = await client.PostAsync(request);

            return response;
        }
    }
}