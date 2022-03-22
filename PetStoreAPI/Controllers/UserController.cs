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
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RestResponse> Post([FromBody] User[] user)
        {
            return await _userService.Create(user);
        }

        /// <summary>
        /// Creates list of users with List of User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RestResponse> Post([FromBody] List<User> user)
        {
            return await _userService.Create(user);
        }

        /// <summary>
        /// Get User By User Name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Return User</returns>
        [HttpGet("GetByUserName/{userName}")]
        public async Task<RestResponse> GetByUserName([FromRoute] string userName) => await _userService.GetByUserName(userName);

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<RestResponse> Put([FromBody] User user)
        {
            return await _userService.Update(user);
        }

        /// <summary>
        /// Delete the userName that needs to be deleted.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<RestResponse> Delete(string userName) => await _userService.Delete(userName);


        /// <summary>
        /// Get User By userName and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("GetByUserNameAndPassword/{userName}/{password}")]
        public async Task<RestResponse> GetByUserNameAndPassword(string userName, string password) => await _userService.GetByUserNameAndPassword(userName, password);

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetByUserLogout")]
        public async Task<RestResponse> GetByUserLogout() => await _userService.GetByUserLogout();

        /// <summary>
        /// Create a User.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RestResponse> Post([FromBody] User user)
        {
            return await _userService.Create(user);
        }
    }
}
