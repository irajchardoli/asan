using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASAN.DataLayer.Migrations
{
    public partial class _1InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ASAN");

            migrationBuilder.CreateTable(
                name: "Owners",
                schema: "ASAN",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDateTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                schema: "ASAN",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 125, nullable: false),
                    Area = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    OwnerId = table.Column<long>(nullable: false),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedDateTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                    table.UniqueConstraint("AK_Estates_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Estates_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "ASAN",
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_OwnerId",
                schema: "ASAN",
                table: "Estates",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estates",
                schema: "ASAN");

            migrationBuilder.DropTable(
                name: "Owners",
                schema: "ASAN");
        }
    }
}
