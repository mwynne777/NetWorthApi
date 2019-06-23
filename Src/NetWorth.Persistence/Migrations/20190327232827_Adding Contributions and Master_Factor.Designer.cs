﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetWorth.Persistence;

namespace NetWorth.Persistence.Migrations
{
    [DbContext(typeof(NetWorthContext))]
    [Migration("20190327232827_Adding Contributions and Master_Factor")]
    partial class AddingContributionsandMaster_Factor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("NetWorth.Domain.Entities.Asset", b =>
                {
                    b.Property<long>("Id");

                    b.Property<double>("CurrentValue")
                        .HasColumnType("money");

                    b.Property<long>("FactorID");

                    b.Property<bool>("HasInterest")
                        .HasMaxLength(1);

                    b.Property<double>("InterestRate")
                        .HasColumnType("decimal");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<int>("Type")
                        .HasMaxLength(2);

                    b.Property<long>("UserID");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("NetWorth.Domain.Entities.Contribution", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount")
                        .HasColumnType("money");

                    b.Property<long?>("AssetId");

                    b.Property<long>("FactorID");

                    b.Property<long?>("LiabilityId");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("LiabilityId");

                    b.ToTable("Contributions");
                });

            modelBuilder.Entity("NetWorth.Domain.Entities.FactorIdentifier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Type")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Factor_Master");
                });

            modelBuilder.Entity("NetWorth.Domain.Entities.Liability", b =>
                {
                    b.Property<long>("Id");

                    b.Property<double>("CurrentValue")
                        .HasColumnType("money");

                    b.Property<long>("FactorID");

                    b.Property<bool>("HasInterest")
                        .HasMaxLength(1);

                    b.Property<double>("InterestRate")
                        .HasColumnType("decimal");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<int>("Type")
                        .HasMaxLength(2);

                    b.Property<long>("UserID");

                    b.HasKey("Id");

                    b.ToTable("Liabilities");
                });

            modelBuilder.Entity("NetWorth.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .HasMaxLength(20);

                    b.Property<string>("UserName")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NetWorth.Domain.Entities.Asset", b =>
                {
                    b.HasOne("NetWorth.Domain.Entities.User", "User")
                        .WithMany("Assets")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Assets_Users")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NetWorth.Domain.Entities.Contribution", b =>
                {
                    b.HasOne("NetWorth.Domain.Entities.Asset")
                        .WithMany("Contributions")
                        .HasForeignKey("AssetId");

                    b.HasOne("NetWorth.Domain.Entities.Liability")
                        .WithMany("Contributions")
                        .HasForeignKey("LiabilityId");
                });

            modelBuilder.Entity("NetWorth.Domain.Entities.Liability", b =>
                {
                    b.HasOne("NetWorth.Domain.Entities.User", "User")
                        .WithMany("Liabilities")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_Liabilities_Users")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
