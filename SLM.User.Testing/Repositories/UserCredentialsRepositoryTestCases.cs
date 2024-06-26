﻿using Moq;
using SLM.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Testing.Repositories
{
    public class UserCredentialsRepositoryTestCases
    {
        [Fact]
        public async Task TestCase_for_Validation_Of_User()
        {
            // Arrange
            var user = TestDataGenerator.GenerateSampleUserCredentialData(1).First();
            var userid = user.EntityID;
            var username = user.Username;
            var password = user.HashedPassword;
            var mockRepository = new Mock<IUserCredentialsEntityRepostiory>();
            var expectedUser = user;
            mockRepository.Setup(repo => repo.ValidateUser(username,password))
                      .ReturnsAsync(expectedUser);
            // Act
            var actualUser = await mockRepository.Object.ValidateUser(username, password);

            // Assert
            Assert.Equal(expectedUser, actualUser);
        }
    }
}
