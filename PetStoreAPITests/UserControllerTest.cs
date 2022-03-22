using Newtonsoft.Json;
using NUnit.Framework;
using PetStoreAPI;
using PetStoreAPI.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreAPITests
{
    public class UserControllerTest
    {
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userService = new UserService();
        }

        [Test]
        public async Task Post_ReturnTrueIfCreateListOfUserArray()
        {
            User[] users = new User[]{ 
                new User{ FirstName = "Max", LastName = "Marteletto", Username = "max", Email = "max@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 },
                new User{FirstName = "Jack", LastName = "Marteletto", Username = "jack", Email = "jack@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 },
                new User{FirstName = "Marley", LastName = "Marteletto", Username = "marley", Email = "marley@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 },
                new User{ FirstName = "Luke", LastName = "Marteletto", Username = "luke", Email = "luke@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 },
                new User{ FirstName = "Bubba", LastName = "Marteletto", Username = "bubba", Email = "bubba@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 }
            };   
            var result = await _userService.Create(users);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task Post_ReturnTrueIfCreateListOfUser()
        {
            List<User> users = new List<User>();

            users.Add(new User() { FirstName = "Max", LastName = "Marteletto", Username = "max", Email = "max@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 });
            users.Add(new User() { FirstName = "Jack", LastName = "Marteletto", Username = "jack", Email = "jack@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 });
            users.Add(new User() { FirstName = "Marley", LastName = "Marteletto", Username = "marley", Email = "marley@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 });
            users.Add(new User() { FirstName = "Luke", LastName = "Marteletto", Username = "luke", Email = "luke@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 });
            users.Add(new User() { FirstName = "Bubba", LastName = "Marteletto", Username = "bubba", Email = "bubba@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 });

            var result = await _userService.Create(users);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }       

        [Test]
        public async Task GetByUserName_ReturnTrueIfFound()
        {
            User user = new User() { FirstName = "Theo", LastName = "Marteletto", Username = "theo", Email = "theo@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 };
            var resultCreate = await _userService.Create(user);

            var result = await _userService.GetByUserName(user.Username);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(resultCreate.StatusCode == System.Net.HttpStatusCode.OK, "", true);
                Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
            });
        }

        [Test]
        public async Task Delete_ReturnTrueIfFound()
        {
            User user = new User(){ FirstName = "Debora", LastName = "Marteletto", Username = "debora", Email = "debora@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 };          
            var resultCreate = await _userService.Create(user);
            var resultDelete = await _userService.Delete(user.Username);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(resultCreate.StatusCode == System.Net.HttpStatusCode.OK, "", true);
                Assert.IsTrue(resultDelete.StatusCode == System.Net.HttpStatusCode.OK, "", true);

            });
        }

        [Test]
        public async Task Put_ReturnTrueIfUpdateUser()
        {
            User user = new User() { FirstName = "Maria", LastName = "Maria", Username = "debora", Email = "maria@mail.com", Password = "111111", Phone = "99331102", UserStatus = 1 };
            var result = await _userService.Update(user); 
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }     

        [Test]
        public async Task Delete_ReturnTrueIfNotFound()
        {
            var userName = "Cookie";
            var result = await _userService.Delete(userName);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NotFound, "", true);
        }

        [Test]
        public async Task Delete_ReturnTrueIfMethodNotAllowed()
        {
            var userName = "";
            var result = await _userService.Delete(userName);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed, "", true);
        }

        [Test]
        public async Task GetByUserNameAndPasswordAndGetByUserLogout_ReturnTrueIfFound()
        {
            User user = new User() { FirstName = "Theo", LastName = "Marteletto", Username = "theo", Email = "theo@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 };
            var resultCreate = await _userService.Create(user);
            var resultLogin = await _userService.GetByUserNameAndPassword(user.Username, user.Password);
            var resultLogout = await _userService.GetByUserLogout();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(resultCreate.StatusCode == System.Net.HttpStatusCode.OK, "", true);
                Assert.IsTrue(resultLogin.StatusCode == System.Net.HttpStatusCode.OK, "", true);
                Assert.IsTrue(resultLogout.StatusCode == System.Net.HttpStatusCode.OK, "", true);
            });
        }

        [Test]
        public async Task Post_ReturnTrueIfCreateUser()
        {
            User user = new User() { FirstName = "Theo", LastName = "Marteletto", Username = "theo", Email = "theo@mail.com", Password = "12345", Phone = "99331102", UserStatus = 1 };                        
            var result = await _userService.Create(user);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }


    }
}