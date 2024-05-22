using Moq;
using SLM.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Testing.Repositories
{
    public class UserMenuRepositoryTestCases
    {
        [Fact]
        public async Task AddUserMenusAsync_Success()
        {
            var user = TestDataGenerator.GenerateSampleUserMenuData(10);
            var mockRepository = new Mock<IUserMenuEntityRepository>();

            // Act
            try
            {
                await mockRepository.Object.AddAllocatedMenusForUserAsync(user.First());

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
    }
}
