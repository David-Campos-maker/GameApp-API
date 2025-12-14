using System;
using GameApp.Domain.Common;
using GameApp.Domain.Entities.Game;
using GameApp.Domain.Entities.Review;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Persistence;

public class GameAppDbContext(DbContextOptions options) : DbContext(options)
{
      public DbSet<GameEntity> Games { get; set; }
      public DbSet<ReviewEntity> Reviews { get; set; }

      public DbSet<PhotoEntity> Photos { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhotoEntity>()
                  .HasDiscriminator<string>("PhotoType")
                  .HasValue<GamePhotoEntity>("GamePhoto");

            modelBuilder.Entity<GameEntity>()
                  .HasOne(g => g.CoverPhoto)
                  .WithOne(p => p.Game)
                  .HasForeignKey<GamePhotoEntity>(p => p.GameId)
                  .OnDelete(DeleteBehavior.Cascade);
      }
}
