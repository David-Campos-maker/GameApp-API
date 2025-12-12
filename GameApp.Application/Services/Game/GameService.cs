using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Game;
using GameApp.Application.Extensions.Game;
using GameApp.Application.Services.Photo;
using GameApp.Domain.Entities;
using GameApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;

namespace GameApp.Application.Services.Game;

public class GameService(IGameRepository repository, IPhotoService photoService) : IGameService
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

      public async Task<ApiResult> AddGamePhoto(int gameId, IFormFile photo)
      {
            try
            {
                  var game = await repository.GetGameByIdAsync(gameId);
                  if (game == null) return ApiResult.Failure("Game not found");

                  var result = await photoService.AddPhotoAsync(photo);
                  if (result.Error != null) return ApiResult.Failure(result.Error.Message);

                  var photoEntity = new PhotoEntity
                  (
                        result.SecureUrl.AbsoluteUri,
                        result.PublicId
                  );

                  game.SetCoverPhoto(photoEntity);

                  if (await repository.UpdateGameAsync(game))
                        return ApiResult.Success("Photo successfully added to the game");

                  return ApiResult.Failure("Something went wrong while adding the photo");
            }
            catch (Exception ex)
            {
                  return ApiResult.Failure(ex.Message);
            }
      }

      public async Task<ApiResult<GameDto>> GetGameByIdAsync(int id)
      {
            try
            {
                  var game = await repository.GetGameByIdAsync(id);
                  if (game != null) return ApiResult<GameDto>.Success(game.EntityToDto());  

                  return ApiResult<GameDto>.Failure("Game not found");    
            }
            catch(Exception ex)
            {
                  return ApiResult<GameDto>.Failure(ex.Message);
            }
      }
}
