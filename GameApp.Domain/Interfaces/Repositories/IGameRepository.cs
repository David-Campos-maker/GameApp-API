using System;
using GameApp.Domain.Entities.Game;

namespace GameApp.Domain.Interfaces.Repositories
{
      public interface IGameRepository
      {
            Task<bool> AddGameAsync(GameEntity game);
            Task<GameEntity?> GetGameByIdAsync(int id);
            Task<List<GameEntity>?> GetAllGamesAsync();
            Task<bool> UpdateGameAsync(GameEntity game);
            Task<bool> DeleteGameAsync(int id);
      }
}
