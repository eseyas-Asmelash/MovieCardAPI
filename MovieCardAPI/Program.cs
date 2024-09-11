using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieInfrustructure.Data;
using MovieInfrustructure.Extensions;
using MoviePresentation.Controllers;
using System.Reflection;
using System.Reflection.Metadata;

namespace MovieCardAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MovieCardAPIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieCardAPIContext") ?? throw new InvalidOperationException("Connection string 'MovieCardAPIContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllers()
                .AddApplicationPart(typeof(MoviesController).Assembly);

           // builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                await app.SeedDataAsync();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
