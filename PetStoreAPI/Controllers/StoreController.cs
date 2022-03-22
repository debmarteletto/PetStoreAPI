using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService) => _storeService = storeService;

        /// <summary>
        /// Get ID of pet by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns ID of pet.</returns>
        [HttpGet("GetById/{id}")]
        public async Task<RestResponse> GetById(Int64 id) => await _storeService.GetById(id);


        /// <summary>
        /// Delete ID of pet.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<RestResponse> Delete(Int64 id) => await _storeService.Delete(id);

        /// <summary>
        /// Get all Status.
        /// </summary>
        /// <returns>Returns a map of status codes to quantities</returns>
        [HttpGet("Get")]
        public async Task<RestResponse> GetAllStatus() => await _storeService.GetAllStatus();

        /// <summary>
        /// Create a Order for a pet.
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RestResponse> Post([FromBody] Store store)
        {
            return await _storeService.Create(store);
        }
    }
}
