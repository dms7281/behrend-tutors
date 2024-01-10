﻿// <auto-generated />
using System;
using BehrendTutors.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BehrendTutors.Migrations
{
    [DbContext(typeof(BehrendTutorsContext))]
    partial class BehrendTutorsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BehrendTutors.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("BehrendTutors.Models.Class", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ClassNum")
                        .HasColumnType("int");

                    b.Property<string>("ClassTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseNum")
                        .HasColumnType("int");

                    b.Property<int>("SectionNum")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("TutorId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("BehrendTutors.Models.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tutor");
                });

            modelBuilder.Entity("BehrendTutors.Models.TutorSession", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Classid")
                        .HasColumnType("int");

                    b.Property<DateTime>("SessionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Classid");

                    b.HasIndex("TutorId");

                    b.ToTable("TutorSession");
                });

            modelBuilder.Entity("BehrendTutors.Models.Class", b =>
                {
                    b.HasOne("BehrendTutors.Models.Tutor", null)
                        .WithMany("Classes")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("BehrendTutors.Models.TutorSession", b =>
                {
                    b.HasOne("BehrendTutors.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("Classid");

                    b.HasOne("BehrendTutors.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");

                    b.Navigation("Class");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("BehrendTutors.Models.Tutor", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}
