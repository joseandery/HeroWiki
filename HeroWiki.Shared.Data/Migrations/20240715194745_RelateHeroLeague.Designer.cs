﻿// <auto-generated />
using System;
using HeroWiki.Shared.Data.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HeroWiki.Shared.Data.Migrations
{
    [DbContext(typeof(HeroWikiContext))]
    [Migration("20240715194745_RelateHeroLeague")]
    partial class RelateHeroLeague
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HeroLeague", b =>
                {
                    b.Property<int>("HerosId")
                        .HasColumnType("int");

                    b.Property<int>("LeaguesId")
                        .HasColumnType("int");

                    b.HasKey("HerosId", "LeaguesId");

                    b.HasIndex("LeaguesId");

                    b.ToTable("HeroLeague");
                });

            modelBuilder.Entity("HeroWiki.Shared.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("League");
                });

            modelBuilder.Entity("HeroWiki_Console.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slogan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("HeroWiki_Console.Power", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HeroId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("Power");
                });

            modelBuilder.Entity("HeroLeague", b =>
                {
                    b.HasOne("HeroWiki_Console.Hero", null)
                        .WithMany()
                        .HasForeignKey("HerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HeroWiki.Shared.Models.League", null)
                        .WithMany()
                        .HasForeignKey("LeaguesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HeroWiki_Console.Power", b =>
                {
                    b.HasOne("HeroWiki_Console.Hero", "Hero")
                        .WithMany("Powers")
                        .HasForeignKey("HeroId");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("HeroWiki_Console.Hero", b =>
                {
                    b.Navigation("Powers");
                });
#pragma warning restore 612, 618
        }
    }
}
