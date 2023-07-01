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

namespace Spotify.Tests.Tests.Usuarios
{
    public sealed class UsuarioTest
    {
        private readonly Context _context;
        private readonly IMapper _map;

        public UsuarioTest()
        {
            _context = Fixture.CriarContext();
            _map = Fixture.CriarMapper();
        }

        [Theory]
        [InlineData("Junior de Souza", "junioranheu", "junioranheu@gmail.com", "Juninho26@", true)]
        [InlineData("Mariana Scalzaretto", "elfamscal", "elfa@gmail.com", "Marianinha26@", true)]
        [InlineData("Ju", "aea", "aea@gmail.com", "aea@", true)]
        [InlineData("Junior de S.", "junioranheu", "junioranheu@gmail.com", "tmr-pes-weon", true)]
        [InlineData("", "", "", "", false)]
        public async Task Criar_ChecarResultadoEsperado(string nomeCompleto, string nomeUsuarioSistema, string email, string senha, bool esperado)
        {
            // Arrange;
            var repository = new UsuarioRepository(_context, _map);
            UsuarioSenhaDTO input = UsuarioMock.CriarInput(nomeCompleto, nomeUsuarioSistema, email, senha);

            // Act;
            await repository.Adicionar(input)!;
            var db = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);

            // Assert;
            Assert.Equal(db is not null, esperado);
        }

        [Fact]
        public async Task Listar_ChecarResultadoEsperado()
        {
            // Arrange;
            List<UsuarioSenhaDTO> listaInput = UsuarioMock.CriarListaInput();
            List<Usuario>? lista = _map.Map<List<Usuario>>(listaInput);

            await _context.Usuarios.AddRangeAsync(lista);
            await _context.SaveChangesAsync();

            var repository = new UsuarioRepository(_context, _map);

            // Act;
            var resp = await repository.GetTodos()!;

            // Assert;
            Assert.True(resp.Any());
        }
    }
}