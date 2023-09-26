﻿// <auto-generated />
using System;
using BookStoreDBFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreDBFirst.Migrations
{
    [DbContext(typeof(ChannelAdDbContext))]
    partial class ChannelAdDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreDBFirst.Models.Ad", b =>
                {
                    b.Property<int>("AdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdID"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BroadcastDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ChannelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTimes")
                        .HasColumnType("int");

                    b.HasKey("AdID");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("BookStoreDBFirst.Models.Channel", b =>
                {
                    b.Property<int>("ChannelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChannelID"));

                    b.Property<string>("ChannelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CommercialPerAd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("POCName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChannelID");

                    b.ToTable("Channels");
                });
#pragma warning restore 612, 618
        }
    }
}
