﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex.Infrastructure.Persistence.Contexts;

#nullable disable

namespace Pokedex.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Pokemon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("region")
                        .HasColumnType("int");

                    b.Property<int>("type1")
                        .HasColumnType("int");

                    b.Property<int?>("type2")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("region");

                    b.HasIndex("type1");

                    b.HasIndex("type2");

                    b.ToTable("Pokemons", (string)null);
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.PokemonType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("id");

                    b.ToTable("PokemonTypes", (string)null);
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Region", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("id");

                    b.ToTable("Regions", (string)null);
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Pokemon", b =>
                {
                    b.HasOne("Pokedex.Core.Domain.Entities.Region", "Region")
                        .WithMany("Pokemons")
                        .HasForeignKey("region")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokedex.Core.Domain.Entities.PokemonType", "PokemonType1")
                        .WithMany("Pokemons1")
                        .HasForeignKey("type1")
                        .IsRequired();

                    b.HasOne("Pokedex.Core.Domain.Entities.PokemonType", "PokemonType2")
                        .WithMany("Pokemons2")
                        .HasForeignKey("type2");

                    b.Navigation("PokemonType1");

                    b.Navigation("PokemonType2");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.PokemonType", b =>
                {
                    b.Navigation("Pokemons1");

                    b.Navigation("Pokemons2");
                });

            modelBuilder.Entity("Pokedex.Core.Domain.Entities.Region", b =>
                {
                    b.Navigation("Pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}