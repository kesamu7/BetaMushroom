using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BetaMushroom.Data.Migrations
{
    public partial class shroomProfileRelationReverse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Mushrooms_mActivityID",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Types_mTypeID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_mActivityID",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_mTypeID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "mActivityID",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "mTypeID",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mActivityID",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mTypeID",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_mActivityID",
                table: "Profiles",
                column: "mActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_mTypeID",
                table: "Profiles",
                column: "mTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Mushrooms_mActivityID",
                table: "Profiles",
                column: "mActivityID",
                principalTable: "Mushrooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Types_mTypeID",
                table: "Profiles",
                column: "mTypeID",
                principalTable: "Types",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
