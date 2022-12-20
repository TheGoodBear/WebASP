﻿// <auto-generated />
using System;
using MVMVC_EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVMVC_EF.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20221219092606_PersonAddress")]
    partial class PersonAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVMVC_EF.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Complement")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Road")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdProject")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Technology")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProject");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.ToTable("Group");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ITLevel")
                        .HasColumnType("int");

                    b.Property<int?>("IdGroup")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ProfileImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdGroup");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("MVMVC_EF.Models.PersonAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAddress");

                    b.HasIndex("IdPerson");

                    b.ToTable("PersonAddress");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Group", b =>
                {
                    b.HasOne("MVMVC_EF.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Person", b =>
                {
                    b.HasOne("MVMVC_EF.Models.Group", "Group")
                        .WithMany("Persons")
                        .HasForeignKey("IdGroup");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("MVMVC_EF.Models.PersonAddress", b =>
                {
                    b.HasOne("MVMVC_EF.Models.Address", "Address")
                        .WithMany("PersonAddresses")
                        .HasForeignKey("IdAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVMVC_EF.Models.Person", "Person")
                        .WithMany("PersonAddresses")
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Address", b =>
                {
                    b.Navigation("PersonAddresses");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Group", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("MVMVC_EF.Models.Person", b =>
                {
                    b.Navigation("PersonAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}