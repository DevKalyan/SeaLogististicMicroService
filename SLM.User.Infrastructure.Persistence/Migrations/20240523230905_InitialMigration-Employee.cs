using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLM.User.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigrationEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SLM_Master_TblDesignation",
                columns: table => new
                {
                    desingationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    designationCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    designationName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    designationDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblDesignation", x => x.desingationId);
                });

            migrationBuilder.CreateTable(
                name: "SLM_Master_TblEmailTemplate",
                columns: table => new
                {
                    emailTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    emailTemplateCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    emailTemplateName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    emailTemplateDesc = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    emailTemplate = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblEmailTemplate", x => x.emailTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "SLM_Master_TblMenu",
                columns: table => new
                {
                    menuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    menuCode = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    menuTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    menuOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblMenu", x => x.menuId);
                });

            migrationBuilder.CreateTable(
                name: "SLM_Master_TblUserType",
                columns: table => new
                {
                    userTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    userName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblUserType", x => x.userTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SLM_Master_TblMenuItems_Details",
                columns: table => new
                {
                    menuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parentMenuCd = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    menuItemCd = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    menuTitle = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    menuDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    menuUrl = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    menuItemOrder = table.Column<int>(type: "int", nullable: false),
                    MenuEntityID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblMenuItems_Details", x => x.menuItemId);
                    table.ForeignKey(
                        name: "FK_SLM_Master_TblMenuItems_Details_SLM_Master_TblMenu_MenuEntityID",
                        column: x => x.MenuEntityID,
                        principalTable: "SLM_Master_TblMenu",
                        principalColumn: "menuId");
                });

            migrationBuilder.CreateTable(
                name: "SLM_Master_TblUsersBasicDetail",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    middleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValue: ""),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    postalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    phoneNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblUsersBasicDetail", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_SLM_Master_TblUsersBasicDetail_SLM_Master_TblDesignation_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "SLM_Master_TblDesignation",
                        principalColumn: "desingationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SLM_Master_TblUsersBasicDetail_SLM_Master_TblUserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "SLM_Master_TblUserType",
                        principalColumn: "userTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SLM_Master_TblUserCredentialDetail",
                columns: table => new
                {
                    userCredentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    passsword = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PasswordChanged = table.Column<int>(type: "int", nullable: false),
                    passwordChangedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEntityID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblUserCredentialDetail", x => x.userCredentialId);
                    table.ForeignKey(
                        name: "FK_SLM_Master_TblUserCredentialDetail_SLM_Master_TblUsersBasicDetail_UserEntityID",
                        column: x => x.UserEntityID,
                        principalTable: "SLM_Master_TblUsersBasicDetail",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_SLM_Master_TblUserCredentialDetail_SLM_Master_TblUsersBasicDetail_userId",
                        column: x => x.userId,
                        principalTable: "SLM_Master_TblUsersBasicDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SLM_Master_TblUserMenuDetail",
                columns: table => new
                {
                    userMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    allocatedMenuCode = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UserEntityID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLM_Master_TblUserMenuDetail", x => x.userMenuId);
                    table.ForeignKey(
                        name: "FK_SLM_Master_TblUserMenuDetail_SLM_Master_TblUsersBasicDetail_UserEntityID",
                        column: x => x.UserEntityID,
                        principalTable: "SLM_Master_TblUsersBasicDetail",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_SLM_Master_TblUserMenuDetail_SLM_Master_TblUsersBasicDetail_userId",
                        column: x => x.userId,
                        principalTable: "SLM_Master_TblUsersBasicDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SLM_Master_TblMenuItems_Details_MenuEntityID",
                table: "SLM_Master_TblMenuItems_Details",
                column: "MenuEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_SLM_Master_TblUserCredentialDetail_UserEntityID",
                table: "SLM_Master_TblUserCredentialDetail",
                column: "UserEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_SLM_Master_TblUserCredentialDetail_userId",
                table: "SLM_Master_TblUserCredentialDetail",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLM_Master_TblUserMenuDetail_UserEntityID",
                table: "SLM_Master_TblUserMenuDetail",
                column: "UserEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_SLM_Master_TblUserMenuDetail_userId",
                table: "SLM_Master_TblUserMenuDetail",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SLM_Master_TblUsersBasicDetail_DesignationId",
                table: "SLM_Master_TblUsersBasicDetail",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_SLM_Master_TblUsersBasicDetail_UserTypeId",
                table: "SLM_Master_TblUsersBasicDetail",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SLM_Master_TblEmailTemplate");

            migrationBuilder.DropTable(
                name: "SLM_Master_TblMenuItems_Details");

            migrationBuilder.DropTable(
                name: "SLM_Master_TblUserCredentialDetail");

            migrationBuilder.DropTable(
                name: "SLM_Master_TblUserMenuDetail");

            migrationBuilder.DropTable(
                name: "SLM_Master_TblMenu");

            migrationBuilder.DropTable(
                name: "SLM_Master_TblUsersBasicDetail");

            migrationBuilder.DropTable(
                name: "SLM_Master_TblDesignation");

            migrationBuilder.DropTable(
                name: "SLM_Master_TblUserType");
        }
    }
}
