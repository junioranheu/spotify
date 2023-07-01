using Spotify.API.DTOs;
using System.Collections.Generic;
using static Spotify.Utils.Biblioteca;

namespace Spotify.Tests.Fixtures.Mocks
{
    public static class MusicaMock
    {
        public static MusicaAdicionarDTO CriarInput(string nome, int ouvintes, int duracaoSegundos)
        {
            MusicaAdicionarDTO usuario = new()
            {
                Nome = !string.IsNullOrEmpty(nome) ? nome : GerarStringAleatoria(5, false),
                Ouvintes = ouvintes > 0 ? ouvintes : 1,
                DuracaoSegundos = duracaoSegundos > 0 ? duracaoSegundos : 1,
                UsuarioId = 1,
                IsAtivo = true
            };

            return usuario;
        }

        public static List<MusicaAdicionarDTO> CriarListaInput()
        {
            List<MusicaAdicionarDTO> lista = new()
            {
                CriarInput(GerarStringAleatoria(5, false), 1, 1),
                CriarInput(GerarStringAleatoria(5, false), 1, 1)
            };

            return lista;
        }
    }
}