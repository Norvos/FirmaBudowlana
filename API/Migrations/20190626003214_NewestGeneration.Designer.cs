﻿// <auto-generated />
using System;
using FirmaBudowlana.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FirmaBudowlana.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20190626003214_NewestGeneration")]
    partial class NewestGeneration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("FirmaBudowlana.Core.Models.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Cost");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("Paid");

                    b.Property<DateTime>("StartDate");

                    b.Property<Guid>("UserID");

                    b.Property<bool>("Validated");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.OrderTeam", b =>
                {
                    b.Property<Guid>("OrderID");

                    b.Property<Guid>("TeamID");

                    b.HasKey("OrderID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("OrderTeam");
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.Payment", b =>
                {
                    b.Property<Guid>("PaymentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<Guid>("OrderID");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<Guid>("WorkerID");

                    b.HasKey("PaymentID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.Team", b =>
                {
                    b.Property<Guid>("TeamID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Salt");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.Worker", b =>
                {
                    b.Property<Guid>("WorkerID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<decimal>("ManHour");

                    b.Property<string>("Specialization");

                    b.HasKey("WorkerID");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.WorkerTeam", b =>
                {
                    b.Property<Guid>("WorkerID");

                    b.Property<Guid>("TeamID");

                    b.HasKey("WorkerID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("WorkerTeam");
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.OrderTeam", b =>
                {
                    b.HasOne("FirmaBudowlana.Core.Models.Order")
                        .WithMany("OrderTeam")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirmaBudowlana.Core.Models.Team")
                        .WithMany("OrderTeam")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FirmaBudowlana.Core.Models.WorkerTeam", b =>
                {
                    b.HasOne("FirmaBudowlana.Core.Models.Team")
                        .WithMany("WorkerTeam")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirmaBudowlana.Core.Models.Worker")
                        .WithMany("WorkerTeam")
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
