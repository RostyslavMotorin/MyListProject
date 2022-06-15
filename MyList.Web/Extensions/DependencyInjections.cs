using MyList.Application.Common.Interfaces;
using MyList.Application.Common.Interfaces.Repositories;
using MyList.Application.Services;
using MyList.Data.Repositories;
using MyList.Domain.Interfaces;
using MyList.Web.Services;

namespace MyList.Web.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddObjectExtensions(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorizeService, AuthorizeService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
