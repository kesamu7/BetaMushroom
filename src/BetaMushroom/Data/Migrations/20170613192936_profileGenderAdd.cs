using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using BetaMushroom.Models;

namespace BetaMushroom.Data.Migrations
{
    public partial class profileGenderAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Profiles",
                nullable: false,
                defaultValue: Gender.Male);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Profiles");
        }
    }
}
