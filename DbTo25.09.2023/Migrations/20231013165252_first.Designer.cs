﻿// <auto-generated />
using CW_25._09._2023.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbTo25._09._2023.Migrations
{
    [DbContext(typeof(GovorunDbContext))]
    [Migration("20231013165252_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CW_25._09._2023.Entities.AnswerFelling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FellAnswers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answers = "I'm fine"
                        },
                        new
                        {
                            Id = 2,
                            Answers = "As usual"
                        },
                        new
                        {
                            Id = 3,
                            Answers = "Bad"
                        },
                        new
                        {
                            Id = 4,
                            Answers = "Wie zu Hitlers Lebzeiten!"
                        });
                });

            modelBuilder.Entity("CW_25._09._2023.Entities.Farewell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Farewells")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Farewells");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Farewells = "See u later"
                        },
                        new
                        {
                            Id = 2,
                            Farewells = "Bye"
                        },
                        new
                        {
                            Id = 3,
                            Farewells = "Auf Wiedersehen!"
                        });
                });

            modelBuilder.Entity("CW_25._09._2023.Entities.Greeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Greets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Hello"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Hi Gitler"
                        },
                        new
                        {
                            Id = 3,
                            Answer = "Good afternoon"
                        });
                });

            modelBuilder.Entity("CW_25._09._2023.Entities.WeatherAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WeatherAnswers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Warm"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Not too warm"
                        },
                        new
                        {
                            Id = 3,
                            Answer = "Cold"
                        },
                        new
                        {
                            Id = 4,
                            Answer = "Wie im 2. Weltkrieg!"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
