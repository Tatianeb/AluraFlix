using AluraFlix.Business.Interfaces;
using AluraFlix.Business.Notificacoes;
using AluraFlix.Business.Services;
using AluraFlix.Data.Context;
using AluraFlix.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AluraFlix.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<INotificador, Notificador>();
            return services;
        }
    }
}