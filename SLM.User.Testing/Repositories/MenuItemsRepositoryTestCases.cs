using Moq;
using SLM.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Testing.Repositories
{
    public class MenuItemsRepositoryTestCases
    {
        [Fact]
        public async Task GetMenuItemsAsync_ReturnsListOfMenuItems()
        {
            // Arrange
            var mockRepository = new Mock<IMenuItemsEntityRepository>();
            var expectedMenuItems = TestDataGenerator.GenerateSampleMenuItems(20);
            mockRepository.Setup(repo => repo.GetAllMenuItems())
                          .ReturnsAsync(expectedMenuItems);

            // Act
            var actualMenuItems = await mockRepository.Object.GetAllMenuItems();

            // Assert
            Assert.Equal(expectedMenuItems, actualMenuItems);
        }
    }
}
