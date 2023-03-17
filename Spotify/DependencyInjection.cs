using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Spotify.API.AutoMapper;
using Spotify.API.Data;
using Spotify.API.Filters;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using Spotify.API.Repositories;
using Spotify.API.Services;
using System.IO.Compression;
using System.Text;

namespace Spotify.API
{
    public static class DependencyInjection
    {
        // Como importar o parâmetro "WebApplicationBuilder" caso aconteça algum erro: https://stackoverflow.com/questions/71146292/how-import-webapplicationbuilder-in-a-class-library
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            AddCompression(builder);
            AddControllers(builder);
            AddJwtSettings(services, builder);
            AddAutoMapper(services);
            AddServices(services, builder);
            AddAuth(services, builder);
            AddBancoDeDados(builder);
            AddSwagger(builder);
            AddCors(builder);

            return services;
        }

        private static void AddCompression(WebApplicationBuilder builder)
        {
            builder.Services.AddResponseCompression(o =>
            {
                o.EnableForHttps = true;
                o.Providers.Add<BrotliCompressionProvider>();
                o.Providers.Add<GzipCompressionProvider>();
            });

            builder.Services.Configure<BrotliCompressionProviderOptions>(o =>
            {
                o.Level = CompressionLevel.Optimal;
            });

            builder.Services.Configure<GzipCompressionProviderOptions>(o =>
            {
                o.Level = CompressionLevel.Optimal;
            });
        }

        private static void AddControllers(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(o => o.Filters.Add<RequestFilter>());
            builder.Services.AddControllers(o => o.Filters.Add<ErrorFilter>());

            builder.Services.AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                });
        }

        private static void AddJwtSettings(IServiceCollection services, WebApplicationBuilder builder)
        {
            ConfigurationManager configuration = builder.Configuration;
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            // Serviços;
            builder.Services.AddScoped<IAutenticarService, AutenticarService>();
            services.AddSingleton<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
            builder.Services.AddScoped<ILogRepository, LogRepository>();

            // Interfaces e repositórios;
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IMusicaRepository, MusicaRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        private static void AddAuth(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(x =>
              {
                  x.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
                  x.SaveToken = true;
                  x.IncludeErrorDetails = true;
                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Secret"] ?? string.Empty)),
                      ValidateIssuer = true,
                      ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                      ValidateAudience = true,
                      ValidAudience = builder.Configuration["JwtSettings:Audience"],
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero
                  };
              });
        }

        private static void AddBancoDeDados(WebApplicationBuilder builder)
        {
            // Inserir as informações do banco na variável builder antes de buildá-la;
            var secretSenhaBancoDados = builder.Configuration["SecretSenhaBancoDados"]; // secrets.json;
            string con = builder.Configuration.GetConnectionString("BaseDadosSpotify") ?? string.Empty;
            con = con.Replace("[secretSenhaBancoDados]", secretSenhaBancoDados); // Alterar pela senha do secrets.json;
            builder.Services.AddDbContext<Context>(options => options.UseMySql(con, ServerVersion.AutoDetect(con)));
        }

        private static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Spotify", Version = "v1" });

                // https://stackoverflow.com/questions/43447688/setting-up-swagger-asp-net-core-using-the-authorization-headers-bearer
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Coloque **_apenas_** o token (JWT Bearer) abaixo!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });


        }

        private static void AddCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
                options.AddPolicy(name: builder.Configuration["CORSSettings:Cors"] ?? string.Empty, builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                })
            );
        }
    }
}
