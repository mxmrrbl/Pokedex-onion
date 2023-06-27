using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region tables

            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<Region>().ToTable("Regions");
            modelBuilder.Entity<PokemonType>().ToTable("PokemonTypes");

            #endregion

            #region "primary keys"

            modelBuilder.Entity<Pokemon>().HasKey(pokemon => pokemon.id);
            modelBuilder.Entity<Region>().HasKey(region => region.id);
            modelBuilder.Entity<PokemonType>().HasKey(ptype => ptype.id);

            #endregion

            #region relationships

            modelBuilder.Entity<Region>()
                .HasMany<Pokemon>(pokemon => pokemon.Pokemons)
                .WithOne(region => region.Region)
                .HasForeignKey(region => region.region)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Pokemon>()
                .HasOne(ptype1 => ptype1.PokemonType1)
                .WithMany(pokemon => pokemon.Pokemons1)
                .HasForeignKey(type1 => type1.type1)
                .OnDelete(DeleteBehavior.ClientSetNull);



            modelBuilder.Entity<Pokemon>()
                .HasOne(ptype1 => ptype1.PokemonType2)
                .WithMany(pokemon => pokemon.Pokemons2)
                .HasForeignKey(type1 => type1.type2)
                .OnDelete(DeleteBehavior.ClientSetNull);


            /*
               modelBuilder.Entity<PokemonType>()
              .HasMany<Pokemon>(pokemon => pokemon.Pokemons)
              .WithOne(ptype => ptype.PokemonType2)
              .HasForeignKey(type2 => type2.type2)
              .OnDelete(DeleteBehavior.Cascade);
            */

            #endregion

            #region "props config"


            #region Pokemon
            modelBuilder.Entity<Pokemon>()
                    .Property(pokemon => pokemon.name)
                    .HasMaxLength(150)
                    .IsRequired();
            #endregion

            #region Region
            modelBuilder.Entity<Region>()
                .Property(region => region.name)
                .HasMaxLength(150)
                .IsRequired();
            #endregion

            #region Type
            modelBuilder.Entity<PokemonType>()
                .Property(pokemonType => pokemonType.name)
                .HasMaxLength(150)
                .IsRequired();
            #endregion


            #endregion
        }
    }
}
