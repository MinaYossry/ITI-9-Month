﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TraineesDbT.Models;

#nullable disable

namespace TraineesDbT.Migrations
{
    [DbContext(typeof(TraineesDbContext))]
    [Migration("20230316115004_Trainees")]
    partial class Trainees
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TraineesDbT.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TraineesDbT.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("TraineesDbT.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("TraineesDbT.Models.Course", b =>
                {
                    b.HasOne("TraineesDbT.Models.Track", "Track")
                        .WithMany("Courses")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("TraineesDbT.Models.Trainee", b =>
                {
                    b.HasOne("TraineesDbT.Models.Track", "Track")
                        .WithMany("Trainees")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("TraineesDbT.Models.Track", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
