﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Plate.Models;
using System;

namespace plate2.Migrations
{
    [DbContext(typeof(platecontext))]
    partial class platecontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Plate.Models.Comments", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int?>("Personid");

                    b.Property<int>("Recipeid");

                    b.HasKey("id");

                    b.HasIndex("Personid");

                    b.HasIndex("Recipeid");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Plate.Models.Favorites", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Personid");

                    b.Property<int>("Recipeid");

                    b.HasKey("id");

                    b.HasIndex("Personid");

                    b.HasIndex("Recipeid");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Plate.Models.Following", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Personid");

                    b.Property<DateTime>("Start");

                    b.HasKey("id");

                    b.HasIndex("Personid");

                    b.ToTable("Following");
                });

            modelBuilder.Entity("Plate.Models.Ingredients", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount")
                        .IsRequired();

                    b.Property<string>("Comment");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Recipeid");

                    b.HasKey("id");

                    b.HasIndex("Recipeid");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Plate.Models.Network", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Followerid");

                    b.Property<int?>("PersonFollowedid");

                    b.Property<int>("Personid");

                    b.HasKey("id");

                    b.HasIndex("PersonFollowedid");

                    b.HasIndex("Personid");

                    b.ToTable("Network");
                });

            modelBuilder.Entity("Plate.Models.Others", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Shoppingid");

                    b.HasKey("id");

                    b.HasIndex("Shoppingid");

                    b.ToTable("Others");
                });

            modelBuilder.Entity("Plate.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("First");

                    b.Property<string>("Last");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Plate.Models.Recipes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Directions");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Personid");

                    b.Property<string>("Serves");

                    b.Property<DateTime>("Start");

                    b.HasKey("id");

                    b.HasIndex("Personid");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Plate.Models.Shopping", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Personid");

                    b.Property<int>("Recipeid");

                    b.HasKey("id");

                    b.HasIndex("Personid");

                    b.HasIndex("Recipeid");

                    b.ToTable("Shopping");
                });

            modelBuilder.Entity("Plate.Models.Comments", b =>
                {
                    b.HasOne("Plate.Models.Person", "Person")
                        .WithMany("Comments")
                        .HasForeignKey("Personid");

                    b.HasOne("Plate.Models.Recipes", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("Recipeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plate.Models.Favorites", b =>
                {
                    b.HasOne("Plate.Models.Person", "Person")
                        .WithMany("Favorites")
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Plate.Models.Recipes", "Recipe")
                        .WithMany("Favorites")
                        .HasForeignKey("Recipeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plate.Models.Following", b =>
                {
                    b.HasOne("Plate.Models.Person", "Person")
                        .WithMany("Following")
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plate.Models.Ingredients", b =>
                {
                    b.HasOne("Plate.Models.Recipes", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("Recipeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plate.Models.Network", b =>
                {
                    b.HasOne("Plate.Models.Following", "PersonFollowed")
                        .WithMany("Network")
                        .HasForeignKey("PersonFollowedid");

                    b.HasOne("Plate.Models.Person", "PersonFollowing")
                        .WithMany("Network")
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plate.Models.Others", b =>
                {
                    b.HasOne("Plate.Models.Shopping", "Shopping")
                        .WithMany("Other")
                        .HasForeignKey("Shoppingid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plate.Models.Recipes", b =>
                {
                    b.HasOne("Plate.Models.Person", "Person")
                        .WithMany("Recipes")
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plate.Models.Shopping", b =>
                {
                    b.HasOne("Plate.Models.Person", "Person")
                        .WithMany("Shopping")
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Plate.Models.Recipes", "Recipe")
                        .WithMany("Shopping")
                        .HasForeignKey("Recipeid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
