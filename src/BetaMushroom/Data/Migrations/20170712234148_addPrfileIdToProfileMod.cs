using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class addPrfileIdToProfileMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileIdID",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileIdID",
                table: "Profiles",
                column: "ProfileIdID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_ProfileIdID",
                table: "Profiles",
                column: "ProfileIdID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_ProfileIdID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileIdID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileIdID",
                table: "Profiles");
        }
    }
}
