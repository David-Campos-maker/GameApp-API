using System;
using GameApp.Domain.Entities;
using GameApp.Domain.Interfaces.Repositories;
using GameApp.Infrastructure.Persistence;

namespace GameApp.Infrastructure.Repositories.Game;

public class GameRepository(GameAppDbContext context) : IGameRepository
{
      public async Task<bool> AddGameAsync(GameEntity game)
      {
            context.Games.Add(game);
            return await context.SaveChangesAsync() > 0;
      }
}
