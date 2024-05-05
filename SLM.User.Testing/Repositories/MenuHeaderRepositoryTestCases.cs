using Moq;
using SLM.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Testing.Repositories
{
    public class MenuHeaderRepositoryTestCases
    {
        
        [Fact]
        public async Task GetMenusAsync_ReturnsListOfMenuHeader()
        {
            // Arrange
            var mockRepository = new Mock<IMenuEntityRepository>();
            var expectedMenus = TestDataGenerator.GenerateSampleMenuHeaders(20);
            mockRepository.Setup(repo => repo.GetAllMenuHeaders())
                          .ReturnsAsync(expectedMenus);

            // Act
            var actualUsers = await mockRepository.Object.GetAllMenuHeaders();

            // Assert
            Assert.Equal(expectedMenus, actualUsers);
        }
    }
}
