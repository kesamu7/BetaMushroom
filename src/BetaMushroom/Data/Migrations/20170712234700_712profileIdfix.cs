using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class _712profileIdfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_ProfileIdID",
                table: "Profiles");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_ProfileIDID",
                table: "Profiles",
                column: "ProfileIdID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "ProfileIdID",
                table: "Profiles",
                newName: "ProfileIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProfileIdID",
                table: "Profiles",
                newName: "IX_Profiles_ProfileIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Profiles_ProfileIDID",
                table: "Profiles");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Profiles_ProfileIdID",
                table: "Profiles",
                column: "ProfileIDID",
                principalTable: "Profiles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "ProfileIDID",
                table: "Profiles",
                newName: "ProfileIdID");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProfileIDID",
                table: "Profiles",
                newName: "IX_Profiles_ProfileIdID");
        }
    }
}
