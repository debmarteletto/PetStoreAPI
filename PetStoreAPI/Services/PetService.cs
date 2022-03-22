using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    public class PetService : IPetService
    {
        public async Task<RestResponse> UploadImageToAPetByID(long id, byte[] file)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/pet/{id}/uploadImage", Method.Post) { RequestFormat = DataFormat.Json };
            request.AddBody(file);
            var response = await client.PostAsync(request);

            return response;
        }

        public async Task<RestResponse> GetById(Int64 id)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/pet/{id}", Method.Get);
            var response = await client.ExecuteAsync(request);           

            return response;
        }

        public async Task<RestResponse> GetByStatus(string status)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            string statusReq = "";

            foreach (var item in status.Split(","))
            {
                statusReq += $"&status={item}";
            }
            statusReq = statusReq.Substring(1, statusReq.Length - 1);
            var request = new RestRequest($"/v2/pet/findByStatus?{statusReq}", Method.Get);
            var response = await client.ExecuteAsync(request);           

            return response;
        }

        public async Task<RestResponse> Create(Pet pet)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/pet", Method.Post) { RequestFormat = DataFormat.Json };
            request.AddBody(pet);
            var response = await client.PostAsync(request);           

            return response;
        }       

        public async Task<RestResponse> Update(Pet pet)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/pet", Method.Put) { RequestFormat = DataFormat.Json };
            request.AddBody(pet);
            var response = await client.PutAsync(request);

            return response;
        }

        public async Task<RestResponse> Delete(Int64 id)
        {
            var client = new RestClient($"https://petstore.swagger.io");
            var request = new RestRequest($"/v2/pet/{id}", Method.Delete);
            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}