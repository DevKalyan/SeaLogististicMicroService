using Bogus;
using SLM.User.Application.Utilities.Models;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Testing
{
    public class TestDataGenerator
    {
        public static List<UserEntity> GenerateSampleUsers(int count = 25)
        {
            var faker = new Faker<UserEntity>()
                .RuleFor(u=>u.EntityID,f=>f.Random.Guid())
                .RuleFor(u => u.Firstname, f => f.Name.FirstName())
                .RuleFor(u => u.MiddleName, f => f.Name.FirstName())
                .RuleFor(u => u.Lastname, f => f.Name.LastName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.Firstname, u.Lastname))
                .RuleFor(u => u.Country, f => f.Address.Country())
                .RuleFor(u => u.State, f => f.Address.State())
                .RuleFor(u => u.PostalCode, f => f.Address.ZipCode())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past(30))
                .RuleFor(u => u.UserTypeId, f => f.Random.Guid())
                .RuleFor(u => u.DesignationId, f => f.Random.Guid());

            var users = faker.Generate(count);
            return users;
        }
        public static List<UserCredentialEntity> GenerateSampleUserCredentialData(int count = 25)
        {
            var credentialFaker = new Faker<UserCredentialEntity>()
            .RuleFor(c => c.Username, f => f.Internet.UserName())
            .RuleFor(c => c.HashedPassword, f => f.Random.Hash())
            .RuleFor(c => c.PasswordChanged, f => f.Random.Number(0, 10))
            .RuleFor(c => c.DtPasswordChanged, f => f.Date.Recent())
            .RuleFor(c => c.UserId, f => f.Random.Guid());
            var userCredentials = credentialFaker.Generate(count);

            return userCredentials;
        }

        public  static UserViewModel GenerateTestUserData()
        {
            var _userId = Guid.NewGuid();
            var userBasicDetails = new UserBasicDetailsModel
            {
                User_FirstName = "John",
                User_MiddleName = "David",
                User_LastName = "Smith",
                User_Email = "john.smith@example.com",
                User_Country = "United States",
                User_State = "California",
                User_PostalCode = "90001",
                User_PhoneNumber = "+1 (555) 123-4567",
                User_DateOfBirth = new DateTime(1990, 5, 15)
            };
            var userCredentials = new UserCredentialsModel
            {
                Username = "john_smith",
                PasswordHash = "password",
                PasswordChanged = 1, // Assuming 1 represents true or password changed
                DtPasswordChanged = DateTime.UtcNow.AddDays(-7) // Example: password changed 7 days ago
            };

            UserViewModel user = new()
            {
                UserId = _userId,
                UserBasicDetails = userBasicDetails,
                UserCredentials= userCredentials
            };

            return user;
        }

    }
}
