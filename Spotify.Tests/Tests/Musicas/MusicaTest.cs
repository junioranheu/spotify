using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spotify.API.Data;
using Spotify.API.DTOs;
using Spotify.API.Models;
using Spotify.API.Repositories;
using Spotify.Tests.Fixtures;
using Spotify.Tests.Fixtures.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests.Tests.Musicas
{
    public sealed class MusicaTest
    {
        private readonly Context _context;
        private readonly IMapper _map;

        public MusicaTest()
        {
            _context = Fixture.CriarContext();
            _map = Fixture.CriarMapper();
        }

        [Theory]
        [InlineData("Junior de Souza", 1, 60, true)]
        [InlineData("Mariana Scalzaretto", 100, 60, true)]
        [InlineData("", 0, 0, false)]
        public async Task Criar_ChecarResultadoEsperado(string nome, int ouvintes, int duracaoSegundos, bool esperado)
        {
            // Arrange;
            var repository = new MusicaRepository(_context, _map);
            MusicaAdicionarDTO input = MusicaMock.CriarInput(nome, ouvintes, duracaoSegundos);

            // Act;
            await repository.Adicionar(input)!;
            var db = await _context.Musicas.FirstOrDefaultAsync(x => x.Nome == nome);

            // Assert;
            Assert.Equal(db is not null, esperado);
        }

        [Fact]
        public async Task Listar_ChecarResultadoEsperado()
        {
            // Arrange;
            List<MusicaAdicionarDTO> listaInput = MusicaMock.CriarListaInput();
            List<Musica>? lista = _map.Map<List<Musica>>(listaInput);

            await _context.Musicas.AddRangeAsync(lista);
            await _context.SaveChangesAsync();

            var repository = new MusicaRepository(_context, _map);

            // Act;
            var resp = await repository.GetTodos()!;

            // Assert;
            Assert.True(resp.Any());
        }
    }
}