
using Microsoft.AspNetCore.Identity.Data;
using SkillSystem.Api.Configurations;
using SkillSystem.Api.Endpoints;
using SkillSystem.Api.Middlewares;
using SkillSystem.Bll.Dtos;
using SkillSystem.Bll.Services;

namespace SkillSystem.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddMemoryCache();
        builder.Services.AddResponseCaching();
        builder.ConfigureDatabase();
        builder.ConfigureDI();
        builder.ConfigureSerilog();
        builder.ConfigureJwtAuth();


        var app = builder.Build();

        app.UseMiddleware<RequestLoggingMiddleware>();
        app.UseMiddleware<AddSkillsCountHeaderMiddleware>();
        app.RegisterTimingMiddleware();
        //app.RegisterAddSkillsCountHeaderMiddleware();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseResponseCaching();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.RegisterAuthEndpoints();
        app.RegisterUserEndpoints();
        app.Run();
    }
}
