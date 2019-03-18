using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripkaroApiV0b1.Migrations
{
    public partial class AllWorkDoneV0B2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userid",
                table: "TripVisitingPlacess",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "SpecialOfferUserss",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "BookingSeatTokens",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TripVisitingPlacess",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TripVisitingPlacess",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "TripVisitingPlacess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TripPackgess",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TripPackgess",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "TripPackgess",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SpecialOfferUserss",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SpecialOfferUserss",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "SpecialOfferUserss",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SpecialOffers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SpecialOffers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "SpecialOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SeatReservations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SeatReservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "SeatReservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CurrentTrips",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CurrentTrips",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "CurrentTrips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "BookingSeatTokens",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "BookingSeatTokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "BookingSeatTokens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "BookingCustomers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "BookingCustomers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedUserId",
                table: "BookingCustomers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TripVisitingPlacess");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TripVisitingPlacess");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "TripVisitingPlacess");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TripPackgess");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TripPackgess");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "TripPackgess");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SpecialOfferUserss");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SpecialOfferUserss");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "SpecialOfferUserss");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SpecialOffers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SpecialOffers");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "SpecialOffers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SeatReservations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SeatReservations");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "SeatReservations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CurrentTrips");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CurrentTrips");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "CurrentTrips");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BookingSeatTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "BookingSeatTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "BookingSeatTokens");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BookingCustomers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "BookingCustomers");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "BookingCustomers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TripVisitingPlacess",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SpecialOfferUserss",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BookingSeatTokens",
                newName: "userId");
        }
    }
}
