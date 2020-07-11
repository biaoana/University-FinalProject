﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using University.DataAccess;

namespace University.DataAccess.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    [Migration("20200707211100_Assignem")]
    partial class Assignem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("University.AppLogic.Models.Assignments", b =>
                {
                    b.Property<Guid>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassroomID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DueTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("WorkPosted")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentID");

                    b.HasIndex("ClassroomID");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("University.AppLogic.Models.Classroom", b =>
                {
                    b.Property<Guid>("ClassroomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClassroomID");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("University.AppLogic.Models.Require", b =>
                {
                    b.Property<Guid>("RequireID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassroomID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid?>("StudentIdUserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RequireID");

                    b.HasIndex("ClassroomID");

                    b.HasIndex("StudentIdUserID");

                    b.ToTable("Requires");
                });

            modelBuilder.Entity("University.AppLogic.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("University.AppLogic.Models.Assignments", b =>
                {
                    b.HasOne("University.AppLogic.Models.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomID");
                });

            modelBuilder.Entity("University.AppLogic.Models.Require", b =>
                {
                    b.HasOne("University.AppLogic.Models.Classroom", "ClassroomId")
                        .WithMany()
                        .HasForeignKey("ClassroomID");

                    b.HasOne("University.AppLogic.Models.User", "StudentId")
                        .WithMany()
                        .HasForeignKey("StudentIdUserID");
                });
#pragma warning restore 612, 618
        }
    }
}
