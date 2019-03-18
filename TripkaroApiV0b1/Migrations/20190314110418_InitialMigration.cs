using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripkaroApiV0b1.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingCustomers",
                columns: table => new
                {
                    BookingCustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: true),
                    PackgesId = table.Column<int>(nullable: false),
                    IsSpecialOfferUser = table.Column<bool>(nullable: false),
                    SpecialOfferId = table.Column<int>(nullable: false),
                    IsCustomPackegeUser = table.Column<bool>(nullable: false),
                    CustomPackgesId = table.Column<int>(nullable: false),
                    TotalPaid = table.Column<decimal>(nullable: false),
                    RemaningBudget = table.Column<decimal>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCustomers", x => x.BookingCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "BookingSeatTokens",
                columns: table => new
                {
                    BookingTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfPerson = table.Column<string>(nullable: true),
                    SeatNumber = table.Column<int>(nullable: false),
                    TotalSeats = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSeatTokens", x => x.BookingTokenId);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTrips",
                columns: table => new
                {
                    CurrentTripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripName = table.Column<string>(nullable: true),
                    StartingLocation = table.Column<string>(nullable: true),
                    TotalBudget = table.Column<decimal>(nullable: false),
                    Descount = table.Column<decimal>(nullable: false),
                    VisitingPlacesId = table.Column<int>(nullable: false),
                    TripDuration = table.Column<int>(nullable: false),
                    AdvisorsContact1 = table.Column<string>(nullable: true),
                    AdvisorsContact2 = table.Column<string>(nullable: true),
                    TotalSeats = table.Column<int>(nullable: false),
                    RemainingSeats = table.Column<int>(nullable: false),
                    TripPackgesId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTrips", x => x.CurrentTripId);
                });

            migrationBuilder.CreateTable(
                name: "DtoVisitingPlacess",
                columns: table => new
                {
                    TripVisitingPlacesid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaceName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NearestLocations = table.Column<string>(nullable: true),
                    stayingHours = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DtoVisitingPlacess", x => x.TripVisitingPlacesid);
                });

            migrationBuilder.CreateTable(
                name: "SeatReservations",
                columns: table => new
                {
                    SeatReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReservationName = table.Column<string>(nullable: true),
                    BookingTokenId = table.Column<int>(nullable: false),
                    ReservedSeatNumber = table.Column<int>(nullable: false),
                    RemainingSeats = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatReservations", x => x.SeatReservationId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffers",
                columns: table => new
                {
                    SpecialOfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecialOfferName = table.Column<string>(nullable: true),
                    DealCode = table.Column<string>(nullable: true),
                    Descount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffers", x => x.SpecialOfferId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOfferUserss",
                columns: table => new
                {
                    SpecialOfferUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecialOfferUserName = table.Column<string>(nullable: true),
                    SpecialOfferId = table.Column<int>(nullable: false),
                    OfferVoutureCode = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOfferUserss", x => x.SpecialOfferUserId);
                });

            migrationBuilder.CreateTable(
                name: "TripPackgess",
                columns: table => new
                {
                    TripPackgesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PackageQuantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EstimatedCost = table.Column<decimal>(nullable: false),
                    DateOfDeparture = table.Column<decimal>(nullable: false),
                    DateOfArival = table.Column<decimal>(nullable: false),
                    PackageType = table.Column<string>(nullable: true),
                    CurrentTripId = table.Column<int>(nullable: false),
                    IsSpecialOffer = table.Column<bool>(nullable: false),
                    SpecialOfferId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripPackgess", x => x.TripPackgesId);
                });

            migrationBuilder.CreateTable(
                name: "TripVisitingPlacess",
                columns: table => new
                {
                    TripVisitingPlacesid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaceName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NearestLocations = table.Column<string>(nullable: true),
                    stayingHours = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripVisitingPlacess", x => x.TripVisitingPlacesid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSelfPackgess",
                columns: table => new
                {
                    UserSelfPackgesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ActualCost = table.Column<decimal>(nullable: false),
                    Descount = table.Column<decimal>(nullable: false),
                    RecentCost = table.Column<decimal>(nullable: false),
                    UserPackgesId = table.Column<int>(nullable: false),
                    IsSpecialOfferUser = table.Column<bool>(nullable: false),
                    SpecialOfferId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelfPackgess", x => x.UserSelfPackgesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingCustomers");

            migrationBuilder.DropTable(
                name: "BookingSeatTokens");

            migrationBuilder.DropTable(
                name: "CurrentTrips");

            migrationBuilder.DropTable(
                name: "DtoVisitingPlacess");

            migrationBuilder.DropTable(
                name: "SeatReservations");

            migrationBuilder.DropTable(
                name: "SpecialOffers");

            migrationBuilder.DropTable(
                name: "SpecialOfferUserss");

            migrationBuilder.DropTable(
                name: "TripPackgess");

            migrationBuilder.DropTable(
                name: "TripVisitingPlacess");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserSelfPackgess");
        }
    }
}
