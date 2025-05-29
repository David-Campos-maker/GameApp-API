using System;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace GameApp.Application.Services.Photo;

public interface IPhotoService
{
      Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
      Task<DeletionResult> DeletePhotoAsync(string publicId);
}
