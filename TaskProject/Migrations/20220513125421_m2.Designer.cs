// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskProject.Models;

namespace TaskProject.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220513125421_m2")]
    partial class m2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TaskProject.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("TaskProject.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CityNameID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZipcodeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CityNameID");

                    b.HasIndex("ZipcodeID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TaskProject.Models.User", b =>
                {
                    b.HasOne("TaskProject.Models.City", "CityName")
                        .WithMany()
                        .HasForeignKey("CityNameID");

                    b.HasOne("TaskProject.Models.City", "Zipcode")
                        .WithMany()
                        .HasForeignKey("ZipcodeID");

                    b.Navigation("CityName");

                    b.Navigation("Zipcode");
                });
#pragma warning restore 612, 618
        }
    }
}
