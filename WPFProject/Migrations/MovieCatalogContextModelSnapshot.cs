﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPFProject.DB.Data;

namespace WPFProject.Migrations
{
    [DbContext(typeof(MovieCatalogContext))]
    partial class MovieCatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WPFProject.DB.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreName = "Komedia"
                        },
                        new
                        {
                            Id = 2,
                            GenreName = "Akcja"
                        },
                        new
                        {
                            Id = 3,
                            GenreName = "Science fiction"
                        },
                        new
                        {
                            Id = 4,
                            GenreName = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            GenreName = "Romans"
                        },
                        new
                        {
                            Id = 6,
                            GenreName = "Dramat"
                        },
                        new
                        {
                            Id = 7,
                            GenreName = "Thriller"
                        },
                        new
                        {
                            Id = 8,
                            GenreName = "Kryminał"
                        },
                        new
                        {
                            Id = 9,
                            GenreName = "Inny"
                        });
                });

            modelBuilder.Entity("WPFProject.DB.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int?>("RatingId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("PlatformId");

                    b.HasIndex("RatingId");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WPFProject.DB.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PlatformName = "Netflix"
                        },
                        new
                        {
                            Id = 2,
                            PlatformName = "HBO"
                        },
                        new
                        {
                            Id = 3,
                            PlatformName = "Disney+"
                        },
                        new
                        {
                            Id = 4,
                            PlatformName = "Canal+"
                        },
                        new
                        {
                            Id = 5,
                            PlatformName = "CDA"
                        },
                        new
                        {
                            Id = 6,
                            PlatformName = "Player"
                        },
                        new
                        {
                            Id = 7,
                            PlatformName = "Inne"
                        });
                });

            modelBuilder.Entity("WPFProject.DB.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RatingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RatingValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RatingName = "Nieporozumienie",
                            RatingValue = 1
                        },
                        new
                        {
                            Id = 2,
                            RatingName = "Ujdzie",
                            RatingValue = 2
                        },
                        new
                        {
                            Id = 3,
                            RatingName = "Średni",
                            RatingValue = 3
                        },
                        new
                        {
                            Id = 4,
                            RatingName = "Dobry",
                            RatingValue = 4
                        },
                        new
                        {
                            Id = 5,
                            RatingName = "Świetny",
                            RatingValue = 5
                        });
                });

            modelBuilder.Entity("WPFProject.DB.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "Anonim"
                        });
                });

            modelBuilder.Entity("WPFProject.DB.Models.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("WPFProject.DB.Models.Movie", b =>
                {
                    b.HasOne("WPFProject.DB.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("WPFProject.DB.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId");

                    b.HasOne("WPFProject.DB.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingId");

                    b.HasOne("WPFProject.DB.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Genre");

                    b.Navigation("Platform");

                    b.Navigation("Rating");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
