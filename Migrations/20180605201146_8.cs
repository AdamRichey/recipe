using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace plate2.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonFollowedid",
                table: "Network",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Following",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Personid = table.Column<int>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Following", x => x.id);
                    table.ForeignKey(
                        name: "FK_Following_Users_Personid",
                        column: x => x.Personid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Network_PersonFollowedid",
                table: "Network",
                column: "PersonFollowedid");

            migrationBuilder.CreateIndex(
                name: "IX_Following_Personid",
                table: "Following",
                column: "Personid");

            migrationBuilder.AddForeignKey(
                name: "FK_Network_Following_PersonFollowedid",
                table: "Network",
                column: "PersonFollowedid",
                principalTable: "Following",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Network_Following_PersonFollowedid",
                table: "Network");

            migrationBuilder.DropTable(
                name: "Following");

            migrationBuilder.DropIndex(
                name: "IX_Network_PersonFollowedid",
                table: "Network");

            migrationBuilder.DropColumn(
                name: "PersonFollowedid",
                table: "Network");
        }
    }
}
