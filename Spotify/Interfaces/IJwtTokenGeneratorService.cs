using Spotify.API.DTOs;
using System.Security.Claims;

namespace Spotify.API.Interfaces
{
    public interface IJwtTokenGeneratorService
    {
        string GerarToken(UsuarioSenhaDTO usuario, IEnumerable<Claim>? listaClaims);
        string GerarRefreshToken();
        ClaimsPrincipal? GetInfoTokenExpirado(string? token);
    }
}
