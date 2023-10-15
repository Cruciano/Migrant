﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MigrantCore;

#nullable disable

namespace MigrantCore.Migrations
{
    [DbContext(typeof(MigrantCoreContext))]
    [Migration("20231015144611_AddPlaces")]
    partial class AddPlaces
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("MigrantCore.Entities.RegistrationPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Place = "ЦНАП"
                        },
                        new
                        {
                            Id = 2,
                            Place = "Степові хутори"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
