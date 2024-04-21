using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLM.User.Infrastructure.Persistence.Migrations
{
    public partial class InitialDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "EntityID", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("7349edfd-1251-4b0f-b99a-56fc5333e5cf"), new DateTime(2024, 4, 21, 23, 5, 26, 125, DateTimeKind.Utc).AddTicks(1507), new Guid("00000000-0000-0000-0000-000000000000"), "This is a super admin designation and will be only one user", 0, "Super-Admin", new DateTime(2024, 4, 21, 23, 5, 26, 125, DateTimeKind.Utc).AddTicks(1508), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "EntityID", "CreatedAt", "CreatedBy", "Description", "IsDeleted", "TypeName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("3f99dbbf-8102-41f0-9ae2-2643aeb0f2cb"), new DateTime(2024, 4, 21, 23, 5, 26, 125, DateTimeKind.Utc).AddTicks(1192), new Guid("00000000-0000-0000-0000-000000000000"), "This user will be having access to all and will also create the users", 0, "Adminstrator", new DateTime(2024, 4, 21, 23, 5, 26, 125, DateTimeKind.Utc).AddTicks(1200), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityID", "Country", "CreatedAt", "CreatedBy", "DateOfBirth", "DesignationId", "Email", "Firstname", "IsDeleted", "Lastname", "MiddleName", "PhoneNumber", "PostalCode", "State", "UpdatedAt", "UpdatedBy", "UserTypeId" },
                values: new object[] { new Guid("adcb634d-ef78-41ad-b34f-9910061b222c"), "India", new DateTime(2024, 4, 21, 23, 5, 26, 125, DateTimeKind.Utc).AddTicks(1557), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 21, 23, 5, 26, 125, DateTimeKind.Utc).AddTicks(1553), new Guid("7349edfd-1251-4b0f-b99a-56fc5333e5cf"), "Devkranth@gmail.com", "Super", 0, "Administrator", "SA", "9999999999", "999999", "Karnataka", new DateTime(2024, 4, 21, 23, 5, 26, 125, DateTimeKind.Utc).AddTicks(1558), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("3f99dbbf-8102-41f0-9ae2-2643aeb0f2cb") });

            migrationBuilder.InsertData(
                table: "UserCredentials",
                columns: new[] { "EntityID", "CreatedAt", "CreatedBy", "DtPasswordChanged", "HashedPassword", "IsDeleted", "PasswordChanged", "UpdatedAt", "UpdatedBy", "UserId", "Username" },
                values: new object[] { new Guid("97a50f44-a519-4188-a231-8a3e094edc4b"), new DateTime(2024, 4, 21, 23, 5, 26, 140, DateTimeKind.Utc).AddTicks(1149), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 4, 21, 23, 5, 26, 140, DateTimeKind.Utc).AddTicks(1144), "/s2QonTnu4iTJAxnYopEqS2ja5D+VRCwO+/uZ+11K19ZWXVhGZJiF5EZQiAs1XqX", 0, 1, new DateTime(2024, 4, 21, 23, 5, 26, 140, DateTimeKind.Utc).AddTicks(1153), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("adcb634d-ef78-41ad-b34f-9910061b222c"), "Adminstrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCredentials",
                keyColumn: "EntityID",
                keyValue: new Guid("97a50f44-a519-4188-a231-8a3e094edc4b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "EntityID",
                keyValue: new Guid("adcb634d-ef78-41ad-b34f-9910061b222c"));

            migrationBuilder.DeleteData(
                table: "Designations",
                keyColumn: "EntityID",
                keyValue: new Guid("7349edfd-1251-4b0f-b99a-56fc5333e5cf"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "EntityID",
                keyValue: new Guid("3f99dbbf-8102-41f0-9ae2-2643aeb0f2cb"));
        }
    }
}
