using System;
using GameApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Persistence;

public class GameAppDbContext(DbContextOptions options) : DbContext(options)
{
      public DbSet<GameEntity> Games { get; set; }
      public DbSet<ReviewEntity> Reviews { get; set; }
}
