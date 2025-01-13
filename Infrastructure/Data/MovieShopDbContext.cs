using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> context) : base(context) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite keys for join tables
            modelBuilder.Entity<MovieCast>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });

            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.MovieId, r.UserId });

            modelBuilder.Entity<Purchase>()
                .HasKey(p => new { p.MovieId, p.UserId });

            // Many-to-Many: Movie and Genre
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenres",
                    j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j => j.ToTable("MovieGenres")
                );

            // Many-to-Many: Movie and User (Favorites)
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Users)
                .WithMany(u => u.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "Favorites",
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    j => j.ToTable("Favorites")
                );

            // Many-to-Many: User and Role
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRoles",
                    j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.ToTable("UserRoles")
                );
        }


    }
}
