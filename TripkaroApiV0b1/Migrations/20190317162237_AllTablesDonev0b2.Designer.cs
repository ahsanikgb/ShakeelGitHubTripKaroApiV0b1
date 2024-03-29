﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripkaroApiV0b1.Helpers;

namespace TripkaroApiV0b1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190317162237_AllTablesDonev0b2")]
    partial class AllTablesDonev0b2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.BookingCustomer", b =>
                {
                    b.Property<int>("BookingCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomPackgesId");

                    b.Property<int>("CustomerId");

                    b.Property<int>("CustomerName");

                    b.Property<bool>("IsCustomPackegeUser");

                    b.Property<bool>("IsSpecialOfferUser");

                    b.Property<int>("PackgesId");

                    b.Property<decimal>("RemaningBudget");

                    b.Property<int>("SpecialOfferId");

                    b.Property<decimal>("TotalPaid");

                    b.Property<int>("UserId");

                    b.Property<string>("phoneNumber");

                    b.HasKey("BookingCustomerId");

                    b.ToTable("BookingCustomers");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.BookingSeatToken", b =>
                {
                    b.Property<int>("BookingTokenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("NameOfPerson");

                    b.Property<int>("SeatNumber");

                    b.Property<int>("TotalSeats");

                    b.Property<int>("userId");

                    b.HasKey("BookingTokenId");

                    b.ToTable("BookingSeatTokens");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.CurrentTrip", b =>
                {
                    b.Property<int>("CurrentTripId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdvisorsContact1");

                    b.Property<string>("AdvisorsContact2");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("Descount");

                    b.Property<int>("RemainingSeats");

                    b.Property<string>("StartingLocation");

                    b.Property<decimal>("TotalBudget");

                    b.Property<int>("TotalSeats");

                    b.Property<string>("TripDuration");

                    b.Property<string>("TripName");

                    b.Property<int>("TripPackgesId");

                    b.Property<int>("UserId");

                    b.HasKey("CurrentTripId");

                    b.ToTable("CurrentTrips");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.SeatReservation", b =>
                {
                    b.Property<int>("SeatReservationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingTokenId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("RemainingSeats");

                    b.Property<string>("ReservationName");

                    b.Property<int>("ReservedSeatNumber");

                    b.Property<int>("UserId");

                    b.HasKey("SeatReservationId");

                    b.ToTable("SeatReservations");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.SpecialOffer", b =>
                {
                    b.Property<int>("SpecialOfferId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DealCode");

                    b.Property<decimal>("Descount");

                    b.Property<string>("Description");

                    b.Property<string>("SpecialOfferName");

                    b.Property<int>("UserId");

                    b.HasKey("SpecialOfferId");

                    b.ToTable("SpecialOffers");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.SpecialOfferUsers", b =>
                {
                    b.Property<int>("SpecialOfferUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("OfferVoutureCode");

                    b.Property<int>("SpecialOfferId");

                    b.Property<string>("SpecialOfferUserName");

                    b.Property<int>("userId");

                    b.HasKey("SpecialOfferUserId");

                    b.ToTable("SpecialOfferUserss");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.TripPackges", b =>
                {
                    b.Property<int>("TripPackgesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CurrentTripId");

                    b.Property<decimal>("DateOfArival");

                    b.Property<decimal>("DateOfDeparture");

                    b.Property<string>("Description");

                    b.Property<decimal>("EstimatedCost");

                    b.Property<bool>("IsSpecialOffer");

                    b.Property<string>("Name");

                    b.Property<int>("PackageQuantity");

                    b.Property<string>("PackageType");

                    b.Property<int>("SpecialOfferId");

                    b.Property<int>("UserId");

                    b.HasKey("TripPackgesId");

                    b.ToTable("TripPackgess");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.TripVisitingPlaces", b =>
                {
                    b.Property<int>("TripVisitingPlacesid")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CurrentTripId");

                    b.Property<string>("Description");

                    b.Property<string>("NearestLocations");

                    b.Property<string>("PlaceName");

                    b.Property<string>("stayingHours");

                    b.Property<int>("userid");

                    b.HasKey("TripVisitingPlacesid");

                    b.ToTable("TripVisitingPlacess");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Role");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TripkaroApiV0b1.MyDbContext.UserSelfPackges", b =>
                {
                    b.Property<int>("UserSelfPackgesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ActualCost");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("Descount");

                    b.Property<bool>("IsSpecialOfferUser");

                    b.Property<string>("Name");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("RecentCost");

                    b.Property<int>("SpecialOfferId");

                    b.Property<int>("UserId");

                    b.Property<int>("UserPackgesId");

                    b.HasKey("UserSelfPackgesId");

                    b.ToTable("UserSelfPackgess");
                });
#pragma warning restore 612, 618
        }
    }
}
