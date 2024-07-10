using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    DDD = table.Column<int>(type: "INT", nullable: false),
                    Location = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.DDD);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DDD = table.Column<int>(type: "INT", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Contact_Region_DDD",
                        column: x => x.DDD,
                        principalTable: "Region",
                        principalColumn: "DDD");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_DDD",
                table: "Contact",
                column: "DDD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
