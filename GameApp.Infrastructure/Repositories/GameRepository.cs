using System;
using GameApp.Domain.Entities.Game;
using GameApp.Domain.Interfaces.Repositories;
using GameApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Repositories;

public class GameRepository(GameAppDbContext context) : IGameRepository
{
      public async Task<bool> AddGameAsync(GameEntity game)
      {
            context.Games.Add(game);
            return await context.SaveChangesAsync() > 0;
      }

      public async Task<bool> DeleteGameAsync(int id)
      {
            var game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (game == null) return false;
            
            context.Games.Remove(game);
            return await context.SaveChangesAsync() > 0;
      }

      public async Task<List<GameEntity>?> GetAllGamesAsync()
      {
            var games = await context.Games
                  .Include(g => g.Reviews)
                  .Include(g => g.CoverPhoto)
                  .ToListAsync();
            
            if (games == null) return null;

            return games;
      }

      public async Task<GameEntity?> GetGameByIdAsync(int id)
      {
            var game = await context.Games
                  .Include(g => g.Reviews)
                  .Include(g => g.CoverPhoto)
                  .FirstOrDefaultAsync(g => g.Id == id);

            if (game == null) return null;
            
            return game;
      }

      public async Task<bool> UpdateGameAsync(GameEntity game)
      {
            context.Games.Update(game);
            return await context.SaveChangesAsync() > 0;
      }
}
