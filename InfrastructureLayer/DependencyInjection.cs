using ApplicationLayer.Interfaces;
using DomainLayer.Models;
using InfrastructureLayer.Database;
using InfrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
            options.UseSqlServer(configuration.GetConnectionString("NemoCleanArchitectureDbString"));
            });
                
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}

           


        
