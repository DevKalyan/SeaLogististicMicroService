using Moq;
using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Testing.Services
{
    public class UserServiceTestCases
    {
        [Fact]
        public async Task ValidateUser_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();

            var expectedUser = TestDataGenerator.GenerateTestUserData();
            var username = "valid_username";
            var password = "valid_password";

            userServiceMock.Setup(x => x.ValidateUser(username, password)).ReturnsAsync(expectedUser);

            var userService = userServiceMock.Object;

            // Act
            var result = await userService.ValidateUser(username, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser.UserId, result.UserId);
            // Add more assertions to thoroughly test the returned UserViewModel object
            Assert.Equal(expectedUser.UserBasicDetails.User_FirstName, result.UserBasicDetails.User_FirstName);
            //Assert.Equal(expectedUser.Email, result.Email);
            // Add more assertions as needed
        }

        //[Fact]
        //public async Task GetUserDetailsByUserId_ExistingUserId_ReturnsUserViewModel()
        //{
        //    // Arrange
        //    var userServiceMock = new Mock<IUserService>();
        //    var expectedUser = new UserViewModel { /* Fill with expected user details */ };
        //    userServiceMock.Setup(x => x.GetUserDetailsByUserId(It.IsAny<Guid>()))
        //                   .ReturnsAsync(expectedUser);

        //    var userService = userServiceMock.Object;

        //    // Act
        //    var result = await userService.GetUserDetailsByUserId(Guid.NewGuid());

        //    // Assert
        //    Assert.NotNull(result);
        //    // Add more assertions based on expectedUser properties if needed
        //}

        [Fact]
        public async Task GetAllUserDetails_ReturnsListOfListOfUserViewModels()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var expectedUsers = TestDataGenerator.GenerateFakeDataForUsers(); // Assuming you have a method to generate test user data

            var allUserViewModels = new List<List<UserViewModel>>(); // Create a new list to hold the list of UserViewModels
            allUserViewModels.Add(new List<UserViewModel>((IEnumerable<UserViewModel>)expectedUsers)); // Add a copy of the expectedUsers list to the list of lists

            userServiceMock.Setup(x => x.GetAllUserDetails())
                           .ReturnsAsync(allUserViewModels); // Return the list of lists from the mock

            var userService = userServiceMock.Object;

            // Act
            var result = await userService.GetAllUserDetails();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            // Add more assertions based on expectedUsers properties if needed
        }

        [Fact]
        public async Task InsertNewUserDetails_InsertsUserIntoRepository()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var expectedUser = TestDataGenerator.GenerateFakeDataForUsers().First();

            userServiceMock.Setup(x => x.InsertNewUserDetails(expectedUser))
                           .Returns(Task.CompletedTask); // Assuming InsertNewUserDetails returns a Task without any specific value

            var userService = userServiceMock.Object;

            // Act
            await userService.InsertNewUserDetails(expectedUser);

            // No need for an assertion because the test is checking if the method call completes without error
        }
    }
}
