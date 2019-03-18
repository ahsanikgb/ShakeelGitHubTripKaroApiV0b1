using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripkaroApiV0b1.Migrations
{
    public partial class AllWorkDoneV0B1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfArival",
                table: "TripPackgess");

            migrationBuilder.DropColumn(
                name: "DateOfDeparture",
                table: "TripPackgess");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfArival",
                table: "CurrentTrips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeparture",
                table: "CurrentTrips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfArival",
                table: "CurrentTrips");

            migrationBuilder.DropColumn(
                name: "DateOfDeparture",
                table: "CurrentTrips");

            migrationBuilder.AddColumn<decimal>(
                name: "DateOfArival",
                table: "TripPackgess",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DateOfDeparture",
                table: "TripPackgess",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
