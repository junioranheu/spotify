using Newtonsoft.Json;
using Spotify.Models;
using Spotify.Tests.Services;
using System.Collections.Generic;
using System.Net;
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

            var contentStr = await response.Content.ReadAsStringAsync(); // Conte�do da resposta em string (JSON "bagun�ado");
            var content = JsonConvert.DeserializeObject<List<Musica>>(contentStr); // Converter string para a classe em si;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(content?.Count > 0);
        }

        [Fact]
        public async Task Test_GetPorId()
        {
            int id = 1;

            using var client = _testProvider.Client;
            var response = await client.GetAsync($"{caminhoApi}/{id}");
            response.EnsureSuccessStatusCode();

            var contentStr = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<Musica>(contentStr);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(content != null);
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
    }
}