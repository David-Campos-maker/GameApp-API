using System;
using GameApp.Domain.Entities.Review;

namespace GameApp.Domain.Interfaces.Repositories
{
      public interface IReviewRepository
      {
            Task<bool> CreateReviewAsync(ReviewEntity review);

            Task<bool> DeleteReviewAsync(ReviewEntity review);

            Task<ReviewEntity?> GetReviewByIdAsync(int id);
      }
}