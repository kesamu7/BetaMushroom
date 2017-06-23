using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class changedUsertoAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mushrooms_AspNetUsers_UserId",
                table: "Mushrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Types_AspNetUsers_UserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_UserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Mushrooms_UserId",
                table: "Mushrooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Mushrooms");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Mushrooms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mushTypeID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mushrooms_AppUserId1",
                table: "Mushrooms",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_mushTypeID",
                table: "AspNetUsers",
                column: "mushTypeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Types_mushTypeID",
                table: "AspNetUsers",
                column: "mushTypeID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mushrooms_AspNetUsers_AppUserId1",
                table: "Mushrooms",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Types_mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Mushrooms_AspNetUsers_AppUserId1",
                table: "Mushrooms");

            migrationBuilder.DropIndex(
                name: "IX_Mushrooms_AppUserId1",
                table: "Mushrooms");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Mushrooms");

            migrationBuilder.DropColumn(
                name: "mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Types",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Mushrooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_UserId",
                table: "Types",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mushrooms_UserId",
                table: "Mushrooms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mushrooms_AspNetUsers_UserId",
                table: "Mushrooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_AspNetUsers_UserId",
                table: "Types",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
