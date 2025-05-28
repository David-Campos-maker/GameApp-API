using System;

namespace GameApp.Application.ApiResults;

public class ApiResult
{
      public bool Succeed { get; set; }
      public string Message { get; set; } = string.Empty;

      public static ApiResult Success(string message = "") =>
            new() { Succeed = true, Message = message };

      public static ApiResult Failure(string message) =>
            new() { Succeed = false, Message = message };
}
