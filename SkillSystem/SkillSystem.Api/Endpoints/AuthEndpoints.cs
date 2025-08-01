using SkillSystem.Bll.Dtos;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Bll.Services;

namespace SkillSystem.Api.Endpoints;

public static class AuthEndpoints
{
    public static void RegisterAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/auth/login", async (LoginDto request, IAuthService authService) =>
        {
            var res = await authService.LoginAsync(request);
            return res;
        }).WithName("Login")
        .WithTags("Authentication")
        .Produces<LoginResponseDto>(StatusCodes.Status200OK);

        app.MapPost("/api/auth/register", async (UserCreateDto request, IAuthService authService) =>
        {
            var id = await authService.SignUpAsync(request);
            return id;
        }).WithName("register")
        .WithTags("Authentication")
        .Produces<long>(StatusCodes.Status200OK);
    }
}
