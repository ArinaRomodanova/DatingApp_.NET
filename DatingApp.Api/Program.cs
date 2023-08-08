using DatingApp.Dal;
using DatingApp.Dal.Repos;
using DatingApp.Dal.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;
using DatingApp.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args).ConfigureSeriLog();

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DatingApp");
        builder.Services.AddDbContextPool<DatabaseContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
        });
        builder.Services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
        builder.Services.AddScoped<IUserRepo, UserRepo>();
        builder.Services.AddScoped<IAccountRepo, AccountRepo>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}