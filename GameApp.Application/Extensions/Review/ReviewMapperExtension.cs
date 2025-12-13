using System;
using GameApp.Application.DTOs.Review;
using GameApp.Domain.Entities;

namespace GameApp.Application.Extensions.Review;

public static class ReviewMapperExtension
{
      public static ReviewEntity NewDtoToEntity(this NewReviewDto dto)
      {
            return new ReviewEntity
            (
                  dto.GameId,
                  dto.Commentary,
                  dto.Rate
            );
      }

      public static ReviewDto EntityToDto(this ReviewEntity entity)
      {
            return new ReviewDto
            (
                  entity.Id,
                  entity.GameId,
                  entity.Commentary,
                  entity.Rate,
                  entity.CreatedDate
            );
      }
}
