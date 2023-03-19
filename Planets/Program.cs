using Planets.Application;
using Planets.Application.UseCases.GetAllPlanets;
using Planets.Application.UseCases.GetPlanet;
using Planets.Infrastructure;

namespace Planets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<GetAllPlanetsQuery>();
            builder.Services.AddScoped<GetPlanetQuery>();
            builder.Services.AddSingleton<IPlanetRepository, InMemoryPlanetRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
            );

            app.Run();
        }
    }
}
