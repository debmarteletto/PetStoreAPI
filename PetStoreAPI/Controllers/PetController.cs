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
    public class PetController : ControllerBase
    {

        private readonly IPetService _petService;

        public PetController(IPetService petService) => _petService = petService;

        [HttpPost]
        public async Task<RestResponse> Post([FromBody] Int64 id, byte[] file)
        {
            return await _petService.UploadImageToAPetByID(id, file);
        }

        /// <summary>
        /// Get Pet by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a single pet By Id.</returns>
        [HttpGet("GetById/{id}")]
        public async Task<RestResponse> GetById(Int64 id) => await _petService.GetById(id);


        /// <summary>
        /// Get Pet by multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <param name="status"></param>
        /// <returns>Returns a list pet By multiple status values.</returns>
        [HttpGet("GetByStatus/{status}")]
        public async Task<RestResponse> GetByStatus([FromRoute] string status) => await _petService.GetByStatus(status);


        /// <summary>
        /// Create a new Pet.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RestResponse> Post([FromBody] Pet pet)
        {
            return await _petService.Create(pet);
        }

        /// <summary>
        /// Update a pet.
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<RestResponse> Put([FromBody] Pet pet)
        {            
            return await _petService.Update(pet);
        }
        
        /// <summary>
        /// Delete Pet by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<RestResponse> Delete(Int64 id) => await _petService.Delete(id);

    }
}
