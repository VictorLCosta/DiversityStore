using System.Text;

using Api.Application.Common.Interfaces;
using Api.Web.Filters;
using Api.Web.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddHttpContextAccessor();

        services.AddHealthChecks();

        services.AddControllers(opt => {
            opt.Filters.Add<ValidationErrorFilter>();
        });
        services.AddEndpointsApiExplorer();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { 
                Title = "DiversityStore Api", 
                Version = "v1",
                Description = "API built in ASP.NET Core for managing a diversity store" 
            });

            opt.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Name = "Authorization",
                Scheme = "Bearer",
                In = ParameterLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement 
            {
                    {
                        new OpenApiSecurityScheme 
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
            });
        });

        var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]!);

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
            };
        });

        services.AddAuthorization();

        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();

        return services;
    }
}
