using Microsoft.Extensions.DependencyInjection;
using MovieCup.Domain.CommandHandlers;
using MovieCup.Domain.Commands;
using MovieCup.Domain.Interfaces;
using MovieCup.Infra.Data.Repository;
using MovieCup.Shared.Commands;

namespace MovieCup.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain - Commands
            services.AddScoped<ICommandHandler<NewCompetitionCommand>, CompetitionCommandHandler>();

            // Infra - Data
            services.AddTransient<IMovieRepository, MovieRepository>();
        }
    }
}
