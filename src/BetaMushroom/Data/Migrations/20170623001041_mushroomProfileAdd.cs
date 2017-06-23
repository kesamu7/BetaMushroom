using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BetaMushroom.Data.Migrations
{
    public partial class mushroomProfileAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileShrooms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MushroomID = table.Column<int>(nullable: true),
                    ProfileID = table.Column<int>(nullable: false),
                    ShroomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileShrooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProfileShrooms_Mushrooms_MushroomID",
                        column: x => x.MushroomID,
                        principalTable: "Mushrooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileShrooms_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileShrooms_MushroomID",
                table: "ProfileShrooms",
                column: "MushroomID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileShrooms_ProfileID",
                table: "ProfileShrooms",
                column: "ProfileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileShrooms");
        }
    }
}
