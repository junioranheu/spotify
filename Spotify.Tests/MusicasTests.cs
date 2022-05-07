using Newtonsoft.Json;
using Spotify.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests
{
    public class MusicasTests
    {
        [Fact]
        public async Task GetTodos()
        {
            using var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/api/Musicas/todos");
            response.EnsureSuccessStatusCode();

            var contentStr = await response.Content.ReadAsStringAsync(); // Conteúdo da resposta em string (JSON "bagunçado");
            var content = JsonConvert.DeserializeObject<List<Musica>>(contentStr); // Converter string para a classe em si;

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(content?.Count > 0);
        }

        [Fact]
        public async Task GetPorId()
        {
            int id = 1;

            using var client = new TestClientProvider().Client;
            var response = await client.GetAsync($"/api/Musicas/{id}");
            response.EnsureSuccessStatusCode();

            var contentStr = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<Musica>(contentStr);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(content != null);
        }
    }
}