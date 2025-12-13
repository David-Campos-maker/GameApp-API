using System;
using GameApp.Domain.Entities;
using GameApp.Domain.Interfaces.Repositories;
using GameApp.Infrastructure.Persistence;

namespace GameApp.Infrastructure.Repositories.Review;

public class ReviewRepository(GameAppDbContext context) : IReviewRepository
{
      public async Task<bool> CreateReviewAsync(ReviewEntity review)
      {
            context.Reviews.Add(review);
            return await context.SaveChangesAsync() > 0;
      }
}
