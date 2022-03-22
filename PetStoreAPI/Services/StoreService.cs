using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    public class StoreService : IStoreService
    { 
        public async Task<RestResponse> GetById(Int64 id)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/store/order/{id}", Method.Get);
            var response = await client.ExecuteAsync(request);           

            return response;
        }       

        public async Task<RestResponse> Delete(Int64 id)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/store/order/{id}", Method.Delete);
            var response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<RestResponse> GetAllStatus()
        {
            var client = new RestClient($"https://petstore.swagger.io");          
            var request = new RestRequest($"/v2/store/inventory", Method.Get);
            var response = await client.ExecuteAsync(request);

            return response;
        }

        public async Task<RestResponse> Create(Store store)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/store/order", Method.Post) { RequestFormat = DataFormat.Json };
            request.AddBody(store);
            var response = await client.PostAsync(request);

            return response;
        }
    }
}