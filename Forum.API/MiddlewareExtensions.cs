using Forum.Application.Identity;
using Forum.Application.Interfaces;
using Forum.Application.Services;
using Forum.Core.Interfaces;
using Forum.Infrastructure.Persistence;
using Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Forum.API
{
    public static class MiddlewareExtensions
    {
        public static void AddDatabaseContext(this WebApplicationBuilder builder) => builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection")));
        public static void ConfigureJwtOptions(this WebApplicationBuilder builder) => builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
        public static void AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<IdentityUser,  IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            JwtOptions jwtOptions = new();
            builder.Configuration.GetSection("ApiSettings:JwtOptions").Bind(jwtOptions);
            var secret = jwtOptions.Secret;
            var issuer = jwtOptions.Issuer;
            var audience = jwtOptions.Audience;
            var key = Encoding.UTF8.GetBytes(secret!);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        }

        public static void AddHttpContextAccessor(this WebApplicationBuilder builder) => builder.Services.AddHttpContextAccessor();

        public static void AddScopedServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITopicService, TopicService>();
            builder.Services.AddScoped<ITopicRepository, TopicRepository>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
        }
        public static void AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                options.Filters.Add(new ProducesAttribute("application/json", "text/plain"));
            }).AddNewtonsoftJson();
        }
        public static void AddEndpointsApiExplorer(this WebApplicationBuilder builder) => builder.Services.AddEndpointsApiExplorer();

        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string example: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}
