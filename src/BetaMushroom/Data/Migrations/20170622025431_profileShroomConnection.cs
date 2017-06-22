using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class profileShroomConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Types_mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Types",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_UserId",
                table: "Types",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Types_AspNetUsers_UserId",
                table: "Types",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Types_AspNetUsers_UserId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_UserId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Types");

            migrationBuilder.AddColumn<int>(
                name: "mushTypeID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_mushTypeID",
                table: "AspNetUsers",
                column: "mushTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Types_mushTypeID",
                table: "AspNetUsers",
                column: "mushTypeID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
