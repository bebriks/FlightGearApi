﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20240418104712_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Domain.Entities.AirportRunway", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AirportId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ArrivalFunctionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartureFunctionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.HasIndex("ArrivalFunctionId");

                    b.HasIndex("DepartureFunctionId");

                    b.ToTable("AirportRunways");
                });

            modelBuilder.Entity("Domain.Entities.FlightPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArrivalRunwayId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DepartureRunwayId")
                        .HasColumnType("uuid");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalRunwayId");

                    b.HasIndex("DepartureRunwayId");

                    b.ToTable("FlightPlans");
                });

            modelBuilder.Entity("Domain.Entities.FlightPropertiesShot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("AccelerationNormal")
                        .HasColumnType("double precision");

                    b.Property<double>("AccelerationX")
                        .HasColumnType("double precision");

                    b.Property<double>("AccelerationY")
                        .HasColumnType("double precision");

                    b.Property<double>("Airspeed")
                        .HasColumnType("double precision");

                    b.Property<double>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<double>("AltitudeAgl")
                        .HasColumnType("double precision");

                    b.Property<double>("AltitudeIndicatedBaro")
                        .HasColumnType("double precision");

                    b.Property<Guid>("FlightSessionId")
                        .HasColumnType("uuid");

                    b.Property<double>("Heading")
                        .HasColumnType("double precision");

                    b.Property<double>("HeadingMagnetic")
                        .HasColumnType("double precision");

                    b.Property<double>("HeadingMagneticIndicated")
                        .HasColumnType("double precision");

                    b.Property<double>("IndicatedSpeed")
                        .HasColumnType("double precision");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Mach")
                        .HasColumnType("double precision");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<double>("PilotOverload")
                        .HasColumnType("double precision");

                    b.Property<double>("Pitch")
                        .HasColumnType("double precision");

                    b.Property<double>("Roll")
                        .HasColumnType("double precision");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<double>("UBodyMps")
                        .HasColumnType("double precision");

                    b.Property<double>("VBodyMps")
                        .HasColumnType("double precision");

                    b.Property<double>("VerticalBaroSpeed")
                        .HasColumnType("double precision");

                    b.Property<double>("WBodyMps")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FlightSessionId");

                    b.ToTable("FlightPropertiesShots");
                });

            modelBuilder.Entity("Domain.Entities.FlightSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DurationSec")
                        .HasColumnType("integer");

                    b.Property<int>("PropertiesReadsPerSec")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FlightSessions");
                });

            modelBuilder.Entity("Domain.Entities.FunctionPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<Guid>("FunctionId")
                        .HasColumnType("uuid");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.Property<double>("Speed")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.ToTable("FunctionPoints");
                });

            modelBuilder.Entity("Domain.Entities.ReadyFlightFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FlightFunctions");
                });

            modelBuilder.Entity("Domain.Entities.RoutePoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Altitude")
                        .HasColumnType("double precision");

                    b.Property<Guid>("FlightPlanId")
                        .HasColumnType("uuid");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("Remarks")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlightPlanId");

                    b.ToTable("RoutePoints");
                });

            modelBuilder.Entity("Domain.Entities.AirportRunway", b =>
                {
                    b.HasOne("Domain.Entities.Airport", "Airport")
                        .WithMany("Runways")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ReadyFlightFunction", "ArrivalFunction")
                        .WithMany()
                        .HasForeignKey("ArrivalFunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ReadyFlightFunction", "DepartureFunction")
                        .WithMany()
                        .HasForeignKey("DepartureFunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airport");

                    b.Navigation("ArrivalFunction");

                    b.Navigation("DepartureFunction");
                });

            modelBuilder.Entity("Domain.Entities.FlightPlan", b =>
                {
                    b.HasOne("Domain.Entities.AirportRunway", "ArrivalRunway")
                        .WithMany()
                        .HasForeignKey("ArrivalRunwayId");

                    b.HasOne("Domain.Entities.AirportRunway", "DepartureRunway")
                        .WithMany()
                        .HasForeignKey("DepartureRunwayId");

                    b.Navigation("ArrivalRunway");

                    b.Navigation("DepartureRunway");
                });

            modelBuilder.Entity("Domain.Entities.FlightPropertiesShot", b =>
                {
                    b.HasOne("Domain.Entities.FlightSession", "FlightSession")
                        .WithMany("PropertiesCollection")
                        .HasForeignKey("FlightSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightSession");
                });

            modelBuilder.Entity("Domain.Entities.FunctionPoint", b =>
                {
                    b.HasOne("Domain.Entities.ReadyFlightFunction", "Function")
                        .WithMany("FunctionPoints")
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");
                });

            modelBuilder.Entity("Domain.Entities.RoutePoint", b =>
                {
                    b.HasOne("Domain.Entities.FlightPlan", "FlightPlan")
                        .WithMany("RoutePoints")
                        .HasForeignKey("FlightPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightPlan");
                });

            modelBuilder.Entity("Domain.Entities.Airport", b =>
                {
                    b.Navigation("Runways");
                });

            modelBuilder.Entity("Domain.Entities.FlightPlan", b =>
                {
                    b.Navigation("RoutePoints");
                });

            modelBuilder.Entity("Domain.Entities.FlightSession", b =>
                {
                    b.Navigation("PropertiesCollection");
                });

            modelBuilder.Entity("Domain.Entities.ReadyFlightFunction", b =>
                {
                    b.Navigation("FunctionPoints");
                });
#pragma warning restore 612, 618
        }
    }
}
