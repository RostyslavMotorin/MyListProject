using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Data.Contexts;
using MyList.Data.Repositories;

namespace MyList.Data
{
    public static class DependencyInjectionDataExtentions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDBContext>(provider => provider.GetRequiredService<ApplicationDBContext>());

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ISerialRepository, SerialRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IAnimeRepository, AnimeRepository>();

            return services;
        }
    }
}
