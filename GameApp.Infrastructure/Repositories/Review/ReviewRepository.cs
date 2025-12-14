using System;
using GameApp.Domain.Entities;
using GameApp.Domain.Interfaces.Repositories;
using GameApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameApp.Infrastructure.Repositories.Review;

public class ReviewRepository(GameAppDbContext context) : IReviewRepository
{
      public async Task<bool> CreateReviewAsync(ReviewEntity review)
      {
            context.Reviews.Add(review);
            return await context.SaveChangesAsync() > 0;
      }

     public async Task<bool> DeleteReviewAsync(ReviewEntity review)
      {
            context.Reviews.Remove(review);
            return await context.SaveChangesAsync() > 0;
      }

    public async Task<ReviewEntity?> GetReviewByIdAsync(int id)
    {
            var review = await context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review == null) return null;
            return review;
    }
}
