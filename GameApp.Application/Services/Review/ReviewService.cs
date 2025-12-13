using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Review;
using GameApp.Application.Extensions.Review;
using GameApp.Domain.Interfaces.Repositories;

namespace GameApp.Application.Services.Review;

public class ReviewService(IReviewRepository repository) : IReviewService
{
      public async Task<ApiResult> CreateReviewAsync(NewReviewDto request)
      {
            try
            {
                  var review = await repository.CreateReviewAsync(request.NewDtoToEntity());

                  if (!review) return ApiResult.Failure("Failed to create review.");

                  return ApiResult.Success("Review created successfully.");
            }
            catch (Exception ex)
            {
                  return ApiResult.Failure(ex.Message);
            }
      }
}
