using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Game;
using GameApp.Application.Extensions.Game;
using GameApp.Application.Services.Photo;
using GameApp.Domain.Entities.Game;
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

                  var folder = "GameApp/Games";

                  var result = await photoService.AddPhotoAsync(photo, folder);
                  if (result.Error != null) return ApiResult.Failure(result.Error.Message);

                  var gamePhotoEntity = new GamePhotoEntity
                  (
                        result.SecureUrl.AbsoluteUri,
                        result.PublicId
                  );

                  game.SetCoverPhoto(gamePhotoEntity);

                  if (await repository.UpdateGameAsync(game))
                        return ApiResult.Success("Photo successfully added to the game");

                  return ApiResult.Failure("Something went wrong while adding the photo");
            }
            catch (Exception ex)
            {
                  return ApiResult.Failure(ex.Message);
            }
      }

      public async Task<ApiResult> DeleteGameAsync(int id)
      {
            try
            {
                  var game = await repository.GetGameByIdAsync(id);
                  if (game == null) return ApiResult.Failure("Game not found");

                  var deleted = await repository.DeleteGameAsync(id);
                  if (deleted) return ApiResult.Success("Game successfully deleted");

                  return ApiResult.Failure("Something went wrong while deleting the game");
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

      public async Task<ApiResult<List<GameDto>>> GetGamesAsync()
      {
            try
            {
                  var games = await repository.GetAllGamesAsync();
                  if (games != null)
                  {
                        var results = games.Select(g => g.EntityToDto()).ToList();
                        return ApiResult<List<GameDto>>.Success(results);
                  }

                  return ApiResult<List<GameDto>>.Failure("No games found");
            }
            catch (Exception ex)
            {
                  return ApiResult<List<GameDto>>.Failure(ex.Message);
            }
      }

      public async Task<ApiResult<GameDto>> RemoveGamePhotoAsync(int gameId)
      {
            try
            {
                  var game = await repository.GetGameByIdAsync(gameId);
                  if (game == null) return ApiResult<GameDto>.Failure("Game not found");

                  if (game.CoverPhoto?.PublicId != null)
                  {
                        var deleteResult = await photoService.DeletePhotoAsync(game.CoverPhoto.PublicId);

                        if (deleteResult.Error != null)
                              return ApiResult<GameDto>
                                          .Failure("Could not delete the photo. " + deleteResult.Error);

                        game.RemoveCoverPhoto();

                        var result = await repository.UpdateGameAsync(game);

                        if (result) return ApiResult<GameDto>.Success(game.EntityToDto());

                        return ApiResult<GameDto>.Failure("Something went wrong while removing the photo");
                  }

                  return ApiResult<GameDto>.Failure("Game does not have a photo to remove");
            }
            catch (Exception ex)
            {
                  return ApiResult<GameDto>.Failure(ex.Message);
            }
      }

      public async Task<ApiResult<GameDto>> UpdateGameAsync(UpdateGameDto request)
      {
            try
            {
                  var existingGame = await repository.GetGameByIdAsync(request.Id);

                  if (existingGame == null) return ApiResult<GameDto>.Failure("Game not found");

                  existingGame.Update(request.Name, request.Published, request.Platforms, request.Genders);

                  var result = await repository.UpdateGameAsync(existingGame);

                  if (result)
                        return ApiResult<GameDto>.Success(existingGame.EntityToDto());

                  return ApiResult<GameDto>.Failure("Something went wrong while updating the game");
            }
            catch (Exception ex)
            {
                  return ApiResult<GameDto>.Failure(ex.Message);
            }
      }

      public async Task<ApiResult<GameDto>> UpdateGamePhotoAsync(int gameId, IFormFile newPhoto)
      {
            try
            {
                  var game = await repository.GetGameByIdAsync(gameId);
                  if (game == null) return ApiResult<GameDto>.Failure("Game not found");

                  if (game.CoverPhoto?.PublicId != null)
                  {
                        var deleteResult = await photoService.DeletePhotoAsync(game.CoverPhoto.PublicId);

                        if (deleteResult.Error != null) 
                              return ApiResult<GameDto>
                                    .Failure("Could not delete the old photo. " + deleteResult.Error.Message);
                  }

                  var folder = "GameApp/Games";

                  var result = await photoService.AddPhotoAsync(newPhoto, folder);
                  if (result.Error != null)
                  {
                        return ApiResult<GameDto>.Failure(result.Error.Message);
                  }

                  var gamePhotoEntity = new GamePhotoEntity
                  (
                        result.SecureUrl.AbsoluteUri, 
                        result.PublicId
                  );

                  game.SetCoverPhoto(gamePhotoEntity);

                  if (await repository.UpdateGameAsync(game)) return ApiResult<GameDto>.Success(game.EntityToDto());

                  return ApiResult<GameDto>.Failure("Something went wrong while saving the new photo");
            }
            catch (Exception ex)
            {
                  return ApiResult<GameDto>.Failure(ex.Message);
            }
      }
}
