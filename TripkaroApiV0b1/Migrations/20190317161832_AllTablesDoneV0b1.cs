using Microsoft.EntityFrameworkCore.Migrations;

namespace TripkaroApiV0b1.Migrations
{
    public partial class AllTablesDoneV0b1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitingPlacesId",
                table: "CurrentTrips");

            migrationBuilder.AlterColumn<string>(
                name: "stayingHours",
                table: "TripVisitingPlacess",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CurrentTripId",
                table: "TripVisitingPlacess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TripDuration",
                table: "CurrentTrips",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTripId",
                table: "TripVisitingPlacess");

            migrationBuilder.AlterColumn<int>(
                name: "stayingHours",
                table: "TripVisitingPlacess",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripDuration",
                table: "CurrentTrips",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitingPlacesId",
                table: "CurrentTrips",
                nullable: false,
                defaultValue: 0);
        }
    }
}
