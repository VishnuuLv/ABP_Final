﻿// <auto-generated />
using System;
using Flight.Services.ManageAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flight.Services.ManageAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220428134338_newone")]
    partial class newone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flight.Services.ManageAPI.Models.Airline", b =>
                {
                    b.Property<int>("flightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("flightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isActive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("flightId");

                    b.ToTable("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}