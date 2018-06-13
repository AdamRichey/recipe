using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace plate2.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    First = table.Column<string>(nullable: true),
                    Last = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Followerid = table.Column<int>(nullable: false),
                    Personid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.id);
                    table.ForeignKey(
                        name: "FK_Network_Users_Personid",
                        column: x => x.Personid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Directions = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Personid = table.Column<int>(nullable: false),
                    Serves = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_Personid",
                        column: x => x.Personid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Personid = table.Column<int>(nullable: true),
                    Recipeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_Personid",
                        column: x => x.Personid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Recipes_Recipeid",
                        column: x => x.Recipeid,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Personid = table.Column<int>(nullable: false),
                    Recipeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_Personid",
                        column: x => x.Personid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Recipes_Recipeid",
                        column: x => x.Recipeid,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Recipeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_Recipeid",
                        column: x => x.Recipeid,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shopping",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Personid = table.Column<int>(nullable: false),
                    Recipeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shopping_Users_Personid",
                        column: x => x.Personid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Recipes_Recipeid",
                        column: x => x.Recipeid,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Shoppingid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.id);
                    table.ForeignKey(
                        name: "FK_Others_Shopping_Shoppingid",
                        column: x => x.Shoppingid,
                        principalTable: "Shopping",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Personid",
                table: "Comments",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Recipeid",
                table: "Comments",
                column: "Recipeid");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Personid",
                table: "Favorites",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Recipeid",
                table: "Favorites",
                column: "Recipeid");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Recipeid",
                table: "Ingredients",
                column: "Recipeid");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Personid",
                table: "Network",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Others_Shoppingid",
                table: "Others",
                column: "Shoppingid");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Personid",
                table: "Recipes",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Personid",
                table: "Shopping",
                column: "Personid");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Recipeid",
                table: "Shopping",
                column: "Recipeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Shopping");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
