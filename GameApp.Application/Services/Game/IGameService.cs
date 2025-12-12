using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Game;
using Microsoft.AspNetCore.Http;

namespace GameApp.Application.Services.Game;

public interface IGameService
{
      Task<ApiResult> AddGameAsync(NewGameDto request);
      Task<ApiResult> AddGamePhoto(int gameId, IFormFile photo);
      Task<ApiResult<GameDto>> GetGameByIdAsync(int id);
}
