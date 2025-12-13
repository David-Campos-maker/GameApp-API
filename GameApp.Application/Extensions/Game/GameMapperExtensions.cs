using System;
using GameApp.Application.DTOs.Game;
using GameApp.Domain.Entities;

namespace GameApp.Application.Extensions.Game;

public static class GameMapperExtensions
{
      public static GameEntity NewDtoToEntity(this NewGameDto dto)
      {
            return new GameEntity
            (
                  dto.Name,
                  dto.Published,
                  dto.Platform,
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
                  entity.Platform,
                  entity.Genders,
                  entity.CoverPhoto?.Url
            );
      }
}
