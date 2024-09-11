using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieModels.Entities;

namespace MovieInfrustructure.Data
{
    public class MovieCardAPIContext : DbContext
    {
        public MovieCardAPIContext (DbContextOptions<MovieCardAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Rating)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies);

           
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies);

          
            modelBuilder.Entity<Director>()
                .HasOne(d => d.ContactInfo)
                .WithOne(c => c.Director)
                .HasForeignKey<ContactInformation>(c => c.DirectorId);
        }
    }
}
