﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGamesListAPI.Repository;

namespace MyGamesListAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20180926185714_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyGamesListAPI.Models.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DetailedDescription");

                    b.Property<string>("HeaderImage");

                    b.Property<double>("Price");

                    b.Property<string>("ShortDescription");

                    b.Property<long>("SteamAppid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MyGamesListAPI.Models.OwnedGame", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("GameId");

                    b.Property<long>("PlaytimeForever");

                    b.Property<long>("PlaytimeTwoWeeks");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("OwnedGames");
                });

            modelBuilder.Entity("MyGamesListAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyGamesListAPI.Models.WishlistItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("GameId");

                    b.Property<int>("RankPosition");

                    b.Property<long?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WishlistItems");
                });

            modelBuilder.Entity("MyGamesListAPI.Models.OwnedGame", b =>
                {
                    b.HasOne("MyGamesListAPI.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyGamesListAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyGamesListAPI.Models.WishlistItem", b =>
                {
                    b.HasOne("MyGamesListAPI.Models.User")
                        .WithMany("Wishlist")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
