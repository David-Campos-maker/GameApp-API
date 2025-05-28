using System;

namespace GameApp.API.Interfaces;

public interface IEndpoint
{
      static abstract void Map(IEndpointRouteBuilder app);
}
