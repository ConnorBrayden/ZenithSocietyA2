using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ZenithSocietyA2.Data.Migrations
{
    public partial class ActivityCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			/*
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserTokens");
			*/

			/*
            migrationBuilder.DropColumn(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserClaims");
		
            migrationBuilder.DropColumn(
                name: "Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetRoleClaims");
			*/
            migrationBuilder.CreateTable(
                name: "ActivityCategories",
                columns: table => new
                {
                    ActivityCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityDescription = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCategories", x => x.ActivityCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EnteredByUsername = table.Column<string>(type: "TEXT", nullable: true),
                    FromDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ToDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
               /*     table.ForeignKey(
                        name: "FK_Events_ActivityCategories_ActivityCategoryId",
                        column: x => x.ActivityCategoryId,
                        principalTable: "ActivityCategories",
                        principalColumn: "ActivityCategoryId",
                        onDelete: ReferentialAction.Cascade);
			   */
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ActivityCategoryId",
                table: "Events",
                column: "ActivityCategoryId");
	/*
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
			*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			/*
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");
			*/
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ActivityCategories");

			/*
            migrationBuilder.AddColumn<string>(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserClaims",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetRoleClaims",
                nullable: true);
			*/
			/*
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetRoleClaims",
                column: "Microsoft.AspNetCore.Identity.IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserClaims",
                column: "ZenithSocietyA2.Models.ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserLogins",
                column: "ZenithSocietyA2.Models.ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_Microsoft.AspNetCore.Identity.IdentityRoleId",
                table: "AspNetUserRoles",
                column: "Microsoft.AspNetCore.Identity.IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ZenithSocietyA2.Models.ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_ZenithSocietyA2.Models.ApplicationUserId",
                table: "AspNetUserTokens",
                column: "ZenithSocietyA2.Models.ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
			*/
        }
    }
}
