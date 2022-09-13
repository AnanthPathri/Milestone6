using AutoFixture;
using FoodDonationManagementSystem.Controllers;
using FoodDonationManagementSystem.Core.Interface;
using FoodDonationManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MsTest
{
    [TestClass]
    public class FoodDonationControllerTest
    {
        private Mock<IFoodDonation> foodRepoMock;
        private Fixture fixture;
        private FoodDonationController controller;
        public FoodDonationControllerTest()
        {
            fixture = new Fixture();
            foodRepoMock = new Mock<IFoodDonation>();
        }
        [TestMethod]
        public async Task GetReturnOk()
        {
            var foodList = fixture.CreateMany<FoodDonationModel>().ToList();
            foodRepoMock.Setup(repo => repo.Get()).Returns(foodList);
            controller = new FoodDonationController(foodRepoMock.Object);
            var result = await controller.Get();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task GetThrowException()
        {
            foodRepoMock.Setup(repo => repo.Get()).Throws(new Exception());
            controller = new FoodDonationController(foodRepoMock.Object);
            var result = await controller.Get();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddReturnOk()
        {
            var food = fixture.Create<FoodDonationModel>();
            foodRepoMock.Setup(repo => repo.Post(It.IsAny<FoodDonationModel>())).Returns(food);
            controller = new FoodDonationController(foodRepoMock.Object);
            var result = await controller.Post(food);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddThrowException()
        {
            foodRepoMock.Setup(repo => repo.Post(It.IsAny<FoodDonationModel>())).Throws(new Exception());
            controller = new FoodDonationController(foodRepoMock.Object);
            var result = await controller.Post(It.IsAny<FoodDonationModel>());
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
    }
}
