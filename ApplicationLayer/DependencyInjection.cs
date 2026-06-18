using ApplicationLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using ApplicationLayer.Interfaces;

namespace ApplicationLayer
{
    public static class DependencyInjection
    {
        // Registers application-layer services into the dependency injection container.
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<ITournamentService, TournamentService>();
            return services;
        }
    }
}
           
