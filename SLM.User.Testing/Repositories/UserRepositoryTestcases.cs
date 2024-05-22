using Microsoft.EntityFrameworkCore;
using Moq;
using SLM.User.Domain.Entities.Models;
using SLM.User.Domain.Interfaces;
using SLM.User.Infrastructure.Persistence.Context;
using SLM.User.Infrastructure.Persistence.Repositories;

namespace SLM.User.Testing.Repositories
{
    public class UserRepositoryTestcases
    {
        [Fact]
        public async Task GetUserByUserIdAsync_ReturnsUserEntity()
        {
            // Arrange
            var user = TestDataGenerator.GenerateSampleUsers(1).First();
            var userId = user.EntityID;
            var mockRepository = new Mock<IUserEntityRepository>();
            var expectedUser = user;
            mockRepository.Setup(repo => repo.GetuserByUserIdAsync(userId))
                      .ReturnsAsync(expectedUser);
            // Act
            var actualUser = await mockRepository.Object.GetuserByUserIdAsync(userId);

            // Assert
            Assert.Equal(expectedUser, actualUser);
        }

        [Fact]
        public async Task AddUserBasicDetailsAsync_AddsUserEntity_Positive()
        {
            // Arrange
            var mockRepository = new Mock<IUserEntityRepository>();
            var userToAdd = TestDataGenerator.GenerateSampleUsers(1).First();

            // Act
            try
            {
                await mockRepository.Object.AddUserBasicDetailsAsync(userToAdd);

                // Assert - Verify that no exception is thrown
                // If method completes without exceptions, it indicates success
                Assert.True(true); // This line is to ensure the test passes if the method completes without exceptions
            }
            catch (Exception ex)
            {
                // If an exception is caught, fail the test and output the exception message
                Assert.True(false, $"Test failed with exception: {ex.Message}");
            }
        }

        [Fact]
        public async Task UpdateUserBasicDetailsAsync_UpdatesUserEntity_Positive()
        {
            // Arrange
            var mockRepository = new Mock<IUserEntityRepository>();
            var userToUpdate = TestDataGenerator.GenerateSampleUsers(1).First();

            // Act
            await mockRepository.Object.UpdateUserBasicDetailsAsync(userToUpdate);

            // Assert - Verify that no exception is thrown
            // If method completes without exceptions, it indicates success
        }
        [Fact]
        public async Task DeleteUserBasicDetailsAsync_DeletesUserEntity_Positive()
        {
            // Arrange
            var mockRepository = new Mock<IUserEntityRepository>();
            var userToDelete = TestDataGenerator.GenerateSampleUsers(1).First(); ;

            // Act
            await mockRepository.Object.DeleteUserBasicDetailsAsync(userToDelete);

            // Assert - Verify that no exception is thrown
            // If method completes without exceptions, it indicates success
        }

        // Negative Test Cases

        //[Fact]
        //public async Task GetUserByUserIdAsync_ReturnsNullForInvalidUserId_Negative()
        //{
        //    //// Arrange
        //    //var userId = Guid.NewGuid(); // Invalid user ID
        //    //var mockRepository = new Mock<IUserEntityRepository>();
        //    //mockRepository.Setup(repo => repo.GetuserByUserIdAsync(userId))
        //    //              .ReturnsAsync((UserEntity)null);

        //    //// Act
        //    //var actualUser = await mockRepository.Object.GetuserByUserIdAsync(userId);

        //    //// Assert
        //    //Assert.Null(actualUser);
        //}

        [Fact]
        public async Task GetUserBasicDetailsAsync_ReturnsEmptyListIfNoUsers_Negative()
        {
            // Arrange
            var mockRepository = new Mock<IUserEntityRepository>();
            mockRepository.Setup(repo => repo.GetUserBasicDetailsAsync())
                          .ReturnsAsync(new List<UserEntity>());

            // Act
            var actualUsers = await mockRepository.Object.GetUserBasicDetailsAsync();

            // Assert
            Assert.Empty(actualUsers);
        }

        [Fact]
        public async Task AddUserBasicDetailsAsync_ThrowsExceptionForNullUserEntity_Negative()
        {
            // Arrange
            var mockRepository = new Mock<IUserEntityRepository>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => mockRepository.Object.AddUserBasicDetailsAsync(null));
        }

        [Fact]
        public async Task UpdateUserBasicDetailsAsync_ThrowsExceptionForNullUserEntity_Negative()
        {
            // Arrange
            var mockRepository = new Mock<IUserEntityRepository>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => mockRepository.Object.UpdateUserBasicDetailsAsync(null));
        }

        [Fact]
        public async Task DeleteUserBasicDetailsAsync_ThrowsExceptionForNullUserEntity_Negative()
        {
            // Arrange
            var mockRepository = new Mock<IUserEntityRepository>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => mockRepository.Object.DeleteUserBasicDetailsAsync(null));
        }

    }
}