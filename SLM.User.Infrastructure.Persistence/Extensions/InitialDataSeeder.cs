using Microsoft.EntityFrameworkCore;
using SLM.User.Domain.Entities.Models;
using SLM.User.Infrastructure.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Extensions
{
    public static class InitialDataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // User Type 
            var userId= Guid.NewGuid();
            var designationId= Guid.NewGuid();
            var userTypeId= Guid.NewGuid();

            modelBuilder.Entity<UserTypeEntity>().HasData(
                new UserTypeEntity
                {
                    EntityID = userTypeId,
                    TypeName = "Adminstrator",
                    Description = "This user will be having access to all and will also create the users",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = Guid.Empty,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = Guid.Empty,
                    IsDeleted = 0
                });

            modelBuilder.Entity<DesignationEntity>().HasData(
                new DesignationEntity
                {
                    EntityID = designationId,
                    Title = "Super-Admin",
                    Description = "This is a super admin designation and will be only one user",
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = Guid.Empty,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = Guid.Empty,
                    IsDeleted = 0
                });



            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    EntityID= userId,
                    Firstname = "Super",
                    MiddleName ="SA",
                    Lastname= "Administrator",
                    DateOfBirth = DateTime.UtcNow,
                    DesignationId= designationId,
                    UserTypeId= userTypeId,
                    Country= "India",      
                    State= "Karnataka",
                    Email ="Devkranth@gmail.com",
                    PhoneNumber ="9999999999",
                    PostalCode ="999999",                    
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = Guid.Empty,
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = Guid.Empty,
                    IsDeleted = 0
                }
            );
            modelBuilder.Entity<UserCredentialEntity>().HasData(
               new UserCredentialEntity
               {
                   EntityID = Guid.NewGuid(),
                   UserId = userId,
                   Username ="Adminstrator",
                   HashedPassword= PasswordHasher.HashPassword("Adminstrator"),
                   DtPasswordChanged= DateTime.UtcNow,
                   PasswordChanged= 1,
                   CreatedAt = DateTime.UtcNow,
                   CreatedBy = Guid.Empty,
                   UpdatedAt = DateTime.UtcNow,
                   UpdatedBy = Guid.Empty,
                   IsDeleted = 0
               }
           );
        }

    }
}
