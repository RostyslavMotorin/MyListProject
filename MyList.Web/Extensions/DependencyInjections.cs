using Microsoft.OpenApi.Models;
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MyList.Api",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            return services;
        }
    }
}
