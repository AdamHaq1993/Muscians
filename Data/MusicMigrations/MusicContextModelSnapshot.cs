﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using solution_MVC_Music.Data;

namespace solution_MVC_Music.Data.MusicMigrations
{
    [DbContext(typeof(MusicContext))]
    partial class MusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MUSIC")
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("solution_MVC_Music.Models.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GenreID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("Price");

                    b.Property<string>("YearProduced")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("ID");

                    b.HasIndex("GenreID");

                    b.HasIndex("Name", "YearProduced")
                        .IsUnique();

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Instrument", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Musician", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("InstrumentID");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(30);

                    b.Property<long>("Phone");

                    b.Property<string>("SIN")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.HasKey("ID");

                    b.HasIndex("InstrumentID");

                    b.HasIndex("SIN")
                        .IsUnique();

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Performance", b =>
                {
                    b.Property<int>("MusicianID");

                    b.Property<int>("SongID");

                    b.HasKey("MusicianID", "SongID");

                    b.HasIndex("SongID");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Plays", b =>
                {
                    b.Property<int>("MusicianID");

                    b.Property<int>("InstrumentID");

                    b.HasKey("MusicianID", "InstrumentID");

                    b.HasIndex("InstrumentID");

                    b.ToTable("Plays");
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Song", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumID");

                    b.Property<int>("GenreID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("GenreID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Album", b =>
                {
                    b.HasOne("solution_MVC_Music.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Musician", b =>
                {
                    b.HasOne("solution_MVC_Music.Models.Instrument", "Instrument")
                        .WithMany("Musicians")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Performance", b =>
                {
                    b.HasOne("solution_MVC_Music.Models.Musician", "Musician")
                        .WithMany("Performances")
                        .HasForeignKey("MusicianID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("solution_MVC_Music.Models.Song", "Song")
                        .WithMany("Performances")
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Plays", b =>
                {
                    b.HasOne("solution_MVC_Music.Models.Instrument", "Instrument")
                        .WithMany("Plays")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("solution_MVC_Music.Models.Musician", "Musician")
                        .WithMany("Plays")
                        .HasForeignKey("MusicianID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("solution_MVC_Music.Models.Song", b =>
                {
                    b.HasOne("solution_MVC_Music.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("solution_MVC_Music.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
