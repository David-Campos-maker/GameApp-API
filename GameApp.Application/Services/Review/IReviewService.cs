using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Review;

namespace GameApp.Application.Services.Review;

public interface IReviewService
{
      Task<ApiResult> CreateReviewAsync(NewReviewDto request);

      Task<ApiResult> DeleteReviewAsync(int id);
}
