using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spotify.API.AutoMapper;
using Spotify.API.Data;
using System;

namespace Spotify.Tests.Fixtures
{
    public static class Fixture
    {
        public static Context CriarContext()
        {
            DbContextOptions<Context> mock = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            Context? context = new(mock);

            return context;
        }

        public static IMapper CriarMapper()
        {
            MapperConfiguration mockMapper = new(x =>
            {
                x.AddProfile(new AutoMapperConfig());
            });

            IMapper map = mockMapper.CreateMapper();

            return map;
        }
    }
}