﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransitTracer.Persistence.Database;

#nullable disable

namespace TransitTracer.Persistence.Migrations
{
    [DbContext(typeof(TransitTrackerDbContext))]
    [Migration("20231021192420_AddDateToBusStopData")]
    partial class AddDateToBusStopData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TransitTracer.Domain.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("RouteId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.BusStop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("BusStops");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.BusStopData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BusStopId")
                        .HasColumnType("int");

                    b.Property<int>("Cycle")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("In")
                        .HasColumnType("int");

                    b.Property<int>("Out")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BusStopId");

                    b.HasIndex("RouteId");

                    b.ToTable("BusStopData");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("RouteNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.RouteStop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("StopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.HasIndex("StopId");

                    b.ToTable("RouteStops");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.Bus", b =>
                {
                    b.HasOne("TransitTracer.Domain.Models.Car", "Car")
                        .WithOne("Bus")
                        .HasForeignKey("TransitTracer.Domain.Models.Bus", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransitTracer.Domain.Models.Route", "Route")
                        .WithMany("Buses")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.BusStopData", b =>
                {
                    b.HasOne("TransitTracer.Domain.Models.BusStop", "BusStop")
                        .WithMany("BusStopData")
                        .HasForeignKey("BusStopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransitTracer.Domain.Models.Route", "Route")
                        .WithMany("BusStopData")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusStop");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.RouteStop", b =>
                {
                    b.HasOne("TransitTracer.Domain.Models.Route", "Route")
                        .WithMany("Stops")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransitTracer.Domain.Models.BusStop", "Stop")
                        .WithMany("RouteStops")
                        .HasForeignKey("StopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("Stop");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.BusStop", b =>
                {
                    b.Navigation("BusStopData");

                    b.Navigation("RouteStops");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.Car", b =>
                {
                    b.Navigation("Bus");
                });

            modelBuilder.Entity("TransitTracer.Domain.Models.Route", b =>
                {
                    b.Navigation("BusStopData");

                    b.Navigation("Buses");

                    b.Navigation("Stops");
                });
#pragma warning restore 612, 618
        }
    }
}