using System;
using GameApp.Domain.Common;
using GameApp.Domain.Entities.Game;
using GameApp.Domain.Entities.Review;
using GameApp.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Persistence;

public class GameAppDbContext(DbContextOptions<GameAppDbContext> options) : IdentityDbContext<UserEntity, IdentityRole<int>, int>(options)
{
      public DbSet<GameEntity> Games { get; set; }
      public DbSet<ReviewEntity> Reviews { get; set; }

      public DbSet<PhotoEntity> Photos { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhotoEntity>()
                  .HasDiscriminator<string>("PhotoType")
                  .HasValue<GamePhotoEntity>("GamePhoto")
                  .HasValue<UserPhotoEntity>("UserPhoto");

            modelBuilder.Entity<GameEntity>()
                  .HasOne(g => g.CoverPhoto)
                  .WithOne(p => p.Game)
                  .HasForeignKey<GamePhotoEntity>(p => p.GameId)
                  .OnDelete(DeleteBehavior.Cascade);

            // User entoty setup 
            List<IdentityRole<int>> roles = new List<IdentityRole<int>>
            {
                  new() {
                        Id = 1,
                        Name = "Moderator",
                        NormalizedName = "MODERATOR"
                  },
                  new() {
                        Id = 2,
                        Name = "User",
                        NormalizedName = "USER"
                  }
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(roles);

            modelBuilder.Entity<UserEntity>()
                  .HasOne(u => u.ProfilePhoto)
                  .WithOne(p => p.User)
                  .HasForeignKey<UserPhotoEntity>(p => p.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
      }
}
