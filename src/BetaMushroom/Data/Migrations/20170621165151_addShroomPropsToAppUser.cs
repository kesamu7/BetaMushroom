using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class addShroomPropsToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mushActivityID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mushTypeID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_mushActivityID",
                table: "AspNetUsers",
                column: "mushActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_mushTypeID",
                table: "AspNetUsers",
                column: "mushTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Mushrooms_mushActivityID",
                table: "AspNetUsers",
                column: "mushActivityID",
                principalTable: "Mushrooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Types_mushTypeID",
                table: "AspNetUsers",
                column: "mushTypeID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Mushrooms_mushActivityID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Types_mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_mushActivityID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_mushTypeID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "mushActivityID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "mushTypeID",
                table: "AspNetUsers");
        }
    }
}
