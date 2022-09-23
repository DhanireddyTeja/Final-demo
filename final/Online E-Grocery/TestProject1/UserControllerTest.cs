using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_E_Grocery.Controllers;
using Online_E_Grocery.Core.Interface;
using Online_E_Grocery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]

    public class UserControllerTest
    {

        private Mock<IUser> _userRepoMock;
        private Fixture _fixture;
        private UserController _controller;
        public UserControllerTest()
        {
            _fixture = new Fixture();
            _userRepoMock = new Mock<IUser>();
        }
        [TestMethod]

        public async Task GetUserReturnOk()
        {
            var userList = _fixture.CreateMany<User>(3).ToList();
            _userRepoMock.Setup(repo => repo.displayUser()).Returns(userList);
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.displayUser();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task GetDonarThrowException()
        {
            _userRepoMock.Setup(repo => repo.displayUser()).Throws(new Exception());
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.displayUser();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddUserReturnOk()
        {
            var user = _fixture.Create<User>();
            _userRepoMock.Setup(repo => repo.Post(It.IsAny<User>())).Returns(user);
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.Post(user);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddDonarThrowException()
        {
            _userRepoMock.Setup(repo => repo.displayUser()).Throws(new Exception());
            _controller = new UserController(_userRepoMock.Object);
            var result = await _controller.displayUser();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
    }
}
