using Microsoft.AspNetCore.Authorization;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Bll.Services;
using System.Security.Claims;

namespace SkillSystem.Api.Endpoints;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this WebApplication app)
    {
        var userGroup = app.MapGroup("/api/admin")
            .RequireAuthorization()       // Require [Authorize] globally for this group
            .WithTags("User Management"); // Swagger section name

        userGroup.MapPatch("/updateRole", [Authorize(Roles = "SuperAdmin")]
        async (long userId, UserRoleDto userRoleDto, IUserService userService) =>
        {
            await userService.UpdateRoleAsync(userId, userRoleDto);
            return Results.Ok();
        })
        .WithName("UpdateUserRole");

        userGroup.MapGet("/getUsers", [Authorize(Roles = "Admin,SuperAdmin")]
        async (IUserService userService) =>
        {
            var users = await userService.GetAllUsersAsync();
            return users;
        })
        .WithName("getUsers");
    }
}

