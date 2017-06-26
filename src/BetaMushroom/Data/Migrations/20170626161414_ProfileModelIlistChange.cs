using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class ProfileModelIlistChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mushrooms_Profiles_ProfileID",
                table: "Mushrooms");

            migrationBuilder.DropIndex(
                name: "IX_Mushrooms_ProfileID",
                table: "Mushrooms");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Mushrooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Mushrooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mushrooms_ProfileID",
                table: "Mushrooms",
                column: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mushrooms_Profiles_ProfileID",
                table: "Mushrooms",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
