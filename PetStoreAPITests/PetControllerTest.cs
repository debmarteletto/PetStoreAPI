using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using PetStoreAPI;
using PetStoreAPI.Controllers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetStoreAPITests
{
    [TestFixture]
    public class PetControllerTest
    {

        private PetService _petService;

        [SetUp]
        public void Setup()
        {
            _petService = new PetService();
        }
        
        [Test]
        public async Task UploadImageToAPetByID_ReturnTrue()
        {            
            var status = "available,pending,sold";
            var resultStatus = await _petService.GetByStatus(status);
            List<Pet> pet = JsonConvert.DeserializeObject<List<Pet>>(resultStatus.Content);
            var file = File.ReadAllBytes("Resources\\Image\\dog.jpg");

            var result = await _petService.UploadImageToAPetByID(pet.First().Id, file);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task GetPetByID_ReturnTrueIfFound()
        {
            var status = "available,pending,sold";
            var resultStatus = await _petService.GetByStatus(status);
            List<Pet> pet = JsonConvert.DeserializeObject<List<Pet>>(resultStatus.Content);

            var result = await _petService.GetById(pet.First().Id);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task GetPetByID_ReturnTrueIfNotFound()
        {
            var result = await _petService.GetById(1);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NotFound, "", true);
        }

        [Test]
        public async Task GetPetByStatus_ReturnTrueIfExistPetByStatus()
        {
            var resultAvailable = await _petService.GetByStatus("available");
            var resultPending = await _petService.GetByStatus("pending");
            var resultSold = await _petService.GetByStatus("sold");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(resultAvailable.StatusCode == System.Net.HttpStatusCode.OK, "", true);
                Assert.IsTrue(resultPending.StatusCode == System.Net.HttpStatusCode.OK, "", true);
                Assert.IsTrue(resultSold.StatusCode == System.Net.HttpStatusCode.OK, "", true);

            });
        }

        [Test]
        public async Task GetPetByStatus_ReturnTrueIfNotExistPetByStatus()
        {
            var status = "none";
            var result = await _petService.GetByStatus(status);
            List<Pet> pet = JsonConvert.DeserializeObject<List<Pet>>(result.Content);
            Assert.IsTrue(pet.Count() == 0, "", true);
        }

        [Test]
        public async Task Post_ReturnTrueIfCreateNewPet()
        {
            Pet pet = new Pet()
            {
                Name = "Pedro",
                Status = "available",
            };
            var result = await _petService.Create(pet);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task Put_ReturnTrueIfUpdatePet()
        {
            var status = "available";
            var resultPet = await _petService.GetByStatus(status);
            List<Pet> petList = JsonConvert.DeserializeObject<List<Pet>>(resultPet.Content);
            Pet pet = petList.First();
            pet.Status = "sold";

            var result = await _petService.Update(pet);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task Delete_ReturnTrueIfDeletePet()
        {
            var status = "available,pending,sold";
            var resultPet = await _petService.GetByStatus(status);
            List<Pet> pet = JsonConvert.DeserializeObject<List<Pet>>(resultPet.Content);

            var result = await _petService.Delete(pet.First().Id);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK, "", true);
        }

        [Test]
        public async Task Delete_ReturnTrueIfDeletePetNotFound()
        {
            var result = await _petService.Delete(1);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NotFound, "", true);
        }

    }
}

