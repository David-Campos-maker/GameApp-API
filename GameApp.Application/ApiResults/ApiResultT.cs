using System;

namespace GameApp.Application.ApiResults;

public class ApiResult<TData>
{
      public TData? Data { get; set; }
      public bool Succeed { get; set; }
      public string Message { get; set; } = string.Empty;

      public static ApiResult<TData> Success(TData data, string message = "")
      {
            return new ApiResult<TData> { Data = data, Succeed = true, Message = message };
      }
      public static ApiResult<TData> Failure(string message = "")
      {
            return new ApiResult<TData> { Data = default, Succeed = false, Message = message };
      }
}
