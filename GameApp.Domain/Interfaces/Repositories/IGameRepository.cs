using System;
using GameApp.Domain.Entities;

namespace GameApp.Domain.Interfaces.Repositories;

public interface IGameRepository
{
      Task<bool> AddGameAsync(GameEntity game);
}
