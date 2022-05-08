using Newtonsoft.Json;
using Spotify.Models;
using Spotify.Tests.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests.Testing
{
    public class MusicasTests
    {
        private readonly TestClientProvider _testProvider;
        private const string caminhoApi = "/api/Musicas";

        public MusicasTests()
        {
            _testProvider = new TestClientProvider();
        }

        [Fact]
        public async Task Test_GetTodos()
        {
            using var client = _testProvider.Client;
            var response = await client.GetAsync($"{caminhoApi}/todos");
            response.EnsureSuccessStatusCode();

            var contentStr = await response.Content.ReadAsStringAsync(); // Conteúdo da resposta em string (JSON "bagunçado");
            var content = JsonConvert.DeserializeObject<List<Musica>>(contentStr); // Converter string para a classe em si;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(content?.Count > 0);
        }

        [Theory]
        [InlineData(1, HttpStatusCode.OK)]
        [InlineData(10, HttpStatusCode.OK)]
        [InlineData(100, HttpStatusCode.NotFound)]
        public async Task Test_GetPorId(int musicaId, HttpStatusCode resultadoEsperado)
        {
            using var client = _testProvider.Client;
            var response = await client.GetAsync($"{caminhoApi}/{musicaId}");
            // response.EnsureSuccessStatusCode();

            var contentStr = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<Musica>(contentStr);

            Assert.Equal(resultadoEsperado, response.StatusCode);
        }

        [Fact]
        public async Task Test_PostIncrementarOuvinte()
        {
            int id = 1;

            using var client = _testProvider.Client;
            var response = await client.PostAsync($"{caminhoApi}/incrementarOuvinte?musicaId={id}", null);
            response.EnsureSuccessStatusCode();

            var contentStr = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(contentStr == "true");
        }

        [Fact]
        public async Task Test_PostCriar()
        {
            // Autenticar;
            var token = await _testProvider.AutenticarTesteUnitario();

            // Ajustar client, objeto json, token, etc;
            using var client = _testProvider.Client;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Musica m = new()
            {
                // MusicaId = xxx,
                Nome = Biblioteca.Biblioteca.GerarPalavraAleatoria(10),
                Ouvintes = 0,
                DuracaoSegundos = Convert.ToInt32(Biblioteca.Biblioteca.NumeroAleatorio(3)),
                DataLancamento = Biblioteca.Biblioteca.HorarioBrasilia(),
                IsAtivo = 1,
                DataRegistro = Biblioteca.Biblioteca.HorarioBrasilia(),

                MusicasBandas = new List<MusicaBanda>(),
                AlbunsMusicas = new List<AlbumMusica>(),
                PlaylistsMusicas = new List<PlaylistMusica>()
            };

            var objetoJson = JsonConvert.SerializeObject(m);
            var musica = new StringContent(objetoJson, Encoding.UTF8, "application/json");

            // Teste;
            var response = await client.PostAsync($"{caminhoApi}/criar", musica);
            response.EnsureSuccessStatusCode();

            var contentStr = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(contentStr == "true");
        }
    }
}