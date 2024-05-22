using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Service.Api.Controllers.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.Language.Flow;
namespace SLM.User.Testing.Controllers
{
    public class UserContollerTestCases
    {
        [Fact]
        public async Task ValidateUser_ValidCredentials_ReturnsOkAsync()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<UserController>>();
            var userServiceMock = new Mock<IUserService>();
            var expectedUser = TestDataGenerator.GenerateTestUserData();

            userServiceMock.Setup(x => x.ValidateUser("valid_username", "valid_password"))
                           .ReturnsAsync(expectedUser);

            var controller = new UserController(loggerMock.Object, userServiceMock.Object);

            // Act
            var result = await controller.ValidateUser("valid_username", "valid_password") as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode); // Assuming Ok() returns 200
            Assert.Equal(expectedUser, result.Value); // Assuming user object equality
        }
        [Fact]
        public async Task InsertNewEmployee_ReturnsOk()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<UserController>>();
            var userControllerMock = new Mock<UserController>(loggerMock.Object);
            var expectedUser = TestDataGenerator.GenerateFakeDataForUsers().First();

            userControllerMock.Setup(x => x.InsertNewEmpoloyee(expectedUser))
                              .Returns((Task<IActionResult>)Task.CompletedTask);

            var userController = userControllerMock.Object;

            // Act
            var result = await userController.InsertNewEmpoloyee(expectedUser);

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(expectedUser, result); // Make sure the returned user matches the expected user
        }

        //[Fact]
        //public void ValidateUser_InvalidCredentials_ReturnsNotFound()
        //{
        //    // Arrange
        //    var loggerMock = new Mock<ILogger<UserController>>();
        //    var userServiceMock = new Mock<IUserService>();
        //    userServiceMock.Setup(x => x.ValidateUser("invalid_username", "invalid_password"))
        //                   .Returns((UserViewModel)null);
        //    var controller = new UserController(loggerMock.Object, userServiceMock.Object);

        //    // Act
        //    var result = controller.ValidateUser("invalid_username", "invalid_password") as StatusCodeResult;

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(404, result.StatusCode); // Assuming NotFound() returns 404
        //}
    }
}

