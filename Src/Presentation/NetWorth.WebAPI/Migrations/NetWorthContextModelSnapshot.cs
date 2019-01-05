﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetWorth.WebAPI.Models;

namespace NetWorth.WebAPI.Migrations
{
    [DbContext(typeof(NetWorthContext))]
    partial class NetWorthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity("NetWorthApi.Models.NWFactor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CurrentValue");

                    b.Property<bool>("HasInterest");

                    b.Property<double>("InterestRate");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.Property<long>("UserID");

                    b.HasKey("Id");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("NetWorthApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
