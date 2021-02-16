﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _2106Proj.Data;

namespace _2106Proj.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20210216163009_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_2106Proj.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Payment");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Payment");
                });

            modelBuilder.Entity("_2106Proj.Models.ReceiptItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostChargeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostChargeId");

                    b.ToTable("ReceiptItem");
                });

            modelBuilder.Entity("_2106Proj.Models.PostCharge", b =>
                {
                    b.HasBaseType("_2106Proj.Models.Payment");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("PostCharge");
                });

            modelBuilder.Entity("_2106Proj.Models.ReservationInvoice", b =>
                {
                    b.HasBaseType("_2106Proj.Models.Payment");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ReservationInvoice");
                });

            modelBuilder.Entity("_2106Proj.Models.ReceiptItem", b =>
                {
                    b.HasOne("_2106Proj.Models.PostCharge", null)
                        .WithMany("ItemList")
                        .HasForeignKey("PostChargeId");
                });
#pragma warning restore 612, 618
        }
    }
}
