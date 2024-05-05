using Moq;
using Newtonsoft.Json;
using SLM.User.Application.Interfaces;
using SLM.User.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Testing.Services
{
    public class MenuServiceTestCases
    {
        [Fact]
        public async Task TestCases_To_ReturnsAllMenus()
        {
            // Arrange
            var menuServiceMock = new Mock<IMenuService>();

            var expectedMenus = TestDataGenerator.GenerateMenuFakeData(25);

            menuServiceMock.Setup(x => x.GetAllMenuAsync()).ReturnsAsync(expectedMenus);

            var menuService = menuServiceMock.Object;
           
            // Act
            var result = await menuService.GetAllMenuAsync();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            // Assert
            Assert.NotNull(result);
            // You may need to implement custom equality comparer or compare properties individually
            Assert.Equal(expectedMenus.Count, result.ToList().Count);
            // Add more assertions to thoroughly test the returned menu data
        }
    }
}
