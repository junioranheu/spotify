using Spotify.API.DTOs;
using System.Collections.Generic;
using static Spotify.Utils.Biblioteca;

namespace Spotify.Tests.Fixtures.Mocks
{
    public static class UsuarioMock
    {
        public static UsuarioSenhaDTO CriarUsuarioInput(string nomeCompleto, string nomeUsuarioSistema, string email, string senha)
        {
            UsuarioSenhaDTO usuario = new()
            {
                NomeCompleto = !string.IsNullOrEmpty(nomeCompleto) ? nomeCompleto : GerarStringAleatoria(5, false),
                NomeUsuarioSistema = !string.IsNullOrEmpty(nomeUsuarioSistema) ? nomeUsuarioSistema : GerarStringAleatoria(5, false),
                Email = !string.IsNullOrEmpty(email) ? email : GerarStringAleatoria(5, false),
                Senha = !string.IsNullOrEmpty(senha) ? senha : GerarStringAleatoria(5, false),
                UsuarioTipoId = 1,
                UsuariosTipos = new()
            };

            return usuario;
        }

        public static List<UsuarioSenhaDTO> CriarListaUsuarioInput()
        {
            List<UsuarioSenhaDTO> lista = new()
            {
                CriarUsuarioInput(GerarStringAleatoria(5, false), GerarStringAleatoria(5, false), GerarStringAleatoria(5, false), GerarStringAleatoria(5, false)),
                CriarUsuarioInput(GerarStringAleatoria(5, false), GerarStringAleatoria(5, false), GerarStringAleatoria(5, false), GerarStringAleatoria(5, false))
            };

            return lista;
        }
    }
}