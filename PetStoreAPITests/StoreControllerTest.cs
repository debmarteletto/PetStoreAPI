using Newtonsoft.Json;
using NUnit.Framework;
using PetStoreAPI;
using PetStoreAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPITests
{
    public class StoreControllerTest
    {
        private StoreService _storeService;

        [SetUp]
        public void Setup()
        {
            _storeService = new StoreService();
        }

        [Test]
        public async Task GetByID_ReturnTrueIfFound()
        {
            var result = await _storeService.GetById(2);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task GetByID_ReturnTrueIfNotFound()
        {
            var result = await _storeService.GetById(-1);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NotFound, "", true);
        }

        [Test]
        public async Task Delete_ReturnTrueIfFound()
        {
            Store store = new Store() { PetId = 1, Quantity = 1, ShipDate = DateTime.Now, Status = "available", Complete = true };
            var resultCreate = await _storeService.Create(store);
            Store storeObject = JsonConvert.DeserializeObject<Store>(resultCreate.Content);

            var result = await _storeService.Delete(storeObject.Id);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(resultCreate.StatusCode == System.Net.HttpStatusCode.OK, "", true);
                Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);

            });
        }

        [Test]
        public async Task Delete_ReturnTrueIfNotFound()
        {
            var result = await _storeService.Delete(-1);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NotFound, "", true);
        }

        [Test]
        public async Task GetAllStatus_ReturnTrueIfFound()
        {
            var result = await _storeService.GetAllStatus();
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task Post_ReturnTrueIfCreateNewOrderForAPet()
        {
            Store store = new Store() { PetId = 1, Quantity = 1, ShipDate = DateTime.Now, Status = "available", Complete = true };
            var result = await _storeService.Create(store);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }        
    }
}