using System;
using GameApp.Application.DTOs.Game;
using GameApp.Application.Extensions.Review;
using GameApp.Domain.Entities.Game;

namespace GameApp.Application.Extensions.Game;

public static class GameMapperExtensions
{
      public static GameEntity NewDtoToEntity(this NewGameDto dto)
      {
            return new GameEntity
            (
                  dto.Name,
                  dto.Published,
                  dto.Platforms,
                  dto.Genders
            );
      }

      public static GameDto EntityToDto(this GameEntity entity)
      {
            return new GameDto
            (
                  entity.Id,
                  entity.Name,
                  entity.Published,
                  entity.Platforms,
                  entity.Genders,
                  entity.CoverPhoto?.Url,
                  [.. entity.Reviews.Select(r => r.EntityToDto())]
            );
      }
}
