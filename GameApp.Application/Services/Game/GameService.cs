using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Game;
using GameApp.Application.Extensions.Game;
using GameApp.Domain.Interfaces.Repositories;

namespace GameApp.Application.Services.Game;

public class GameService(IGameRepository repository) : IGameService
{
      public async Task<ApiResult> AddGameAsync(NewGameDto request)
      {
            try
            {
                  var newGame = request.NewDtoToEntity();
                  if (await repository.AddGameAsync(newGame))
                        return ApiResult.Success("Game successfully added");

                  return ApiResult.Failure("Something went wrong while adding game");
            }
            catch (Exception ex)
            {
                  return ApiResult.Failure(ex.Message);
            }
      }
}
