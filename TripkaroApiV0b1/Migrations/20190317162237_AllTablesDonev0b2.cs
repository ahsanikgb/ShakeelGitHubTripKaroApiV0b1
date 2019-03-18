using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripkaroApiV0b1.Migrations
{
    public partial class AllTablesDonev0b2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DtoVisitingPlacess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DtoVisitingPlacess",
                columns: table => new
                {
                    TripVisitingPlacesid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    NearestLocations = table.Column<string>(nullable: true),
                    PlaceName = table.Column<string>(nullable: true),
                    stayingHours = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoVisitingPlacess", x => x.TripVisitingPlacesid);
                });
        }
    }
}
