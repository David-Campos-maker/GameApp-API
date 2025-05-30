using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Game;

namespace GameApp.Application.Services.Game;

public interface IGameService
{
      Task<ApiResult> AddGameAsync(NewGameDto request);
}
