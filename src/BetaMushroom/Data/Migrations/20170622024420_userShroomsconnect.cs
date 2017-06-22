using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class userShroomsconnect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Mushrooms_mushActivityID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_mushActivityID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "mushActivityID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Mushrooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Mushrooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mushrooms_ProfileID",
                table: "Mushrooms",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Mushrooms_UserId",
                table: "Mushrooms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mushrooms_Profiles_ProfileID",
                table: "Mushrooms",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mushrooms_AspNetUsers_UserId",
                table: "Mushrooms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mushrooms_Profiles_ProfileID",
                table: "Mushrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Mushrooms_AspNetUsers_UserId",
                table: "Mushrooms");

            migrationBuilder.DropIndex(
                name: "IX_Mushrooms_ProfileID",
                table: "Mushrooms");

            migrationBuilder.DropIndex(
                name: "IX_Mushrooms_UserId",
                table: "Mushrooms");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Mushrooms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Mushrooms");

            migrationBuilder.AddColumn<int>(
                name: "mushActivityID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_mushActivityID",
                table: "AspNetUsers",
                column: "mushActivityID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Mushrooms_mushActivityID",
                table: "AspNetUsers",
                column: "mushActivityID",
                principalTable: "Mushrooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
