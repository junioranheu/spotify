using Spotify.Models;

namespace Spotify.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetTodos();
        Task<Usuario> GetPorId(int id);
        Task<Usuario> GetVerificarEmailSenha(string nomeUsuarioSistema, string senha);
    }
}
