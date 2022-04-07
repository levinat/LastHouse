using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace House.Data.Migrations
{
    public partial class HouseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    ApartmentNumber = table.Column<double>(nullable: false),
                    Floor = table.Column<double>(nullable: false),
                    Typeofheating = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    Parking = table.Column<double>(nullable: false),
                    CreatedAT = table.Column<DateTime>(nullable: false),
                    ModifiedAT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
