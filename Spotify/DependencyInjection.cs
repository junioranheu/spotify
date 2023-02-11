﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Spotify.API.AutoMapper;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using Spotify.API.Repositories;
using Spotify.API.Services;
using System.Text;

namespace Spotify.API
{
    public static class DependencyInjection
    {
        // Como importar o parâmetro "WebApplicationBuilder" caso aconteça algum erro: https://stackoverflow.com/questions/71146292/how-import-webapplicationbuilder-in-a-class-library
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            ConfigurationManager configuration = builder.Configuration;

            // =-=-=-=-=-=-=-=-=-= Configuração do JWT =-=-=-=-=-=-=-=-=-=
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            // =-=-=-=-=-=-=-=-=-= Configuração de depêndencia do AutoMapper =-=-=-=-=-=-=-=-=-=
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // =-=-=-=-=-=-=-=-=-= Serviços =-=-=-=-=-=-=-=-=-=
            builder.Services.AddScoped<IAutenticarService, AutenticarService>();
            services.AddSingleton<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
            builder.Services.AddScoped<ILogRepository, LogRepository>();

            // Interfaces e repositórios;
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IMusicaRepository, MusicaRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // =-=-=-=-=-=-=-=-=-= Autenticação JWT para a API: https://balta.io/artigos/aspnet-5-autenticacao-autorizacao-bearer-jwt =-=-=-=-=-=-=-=-=-=
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Secret"] ?? "")),
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
