using Microsoft.EntityFrameworkCore;
using Spotify.API.Enums;
using Spotify.API.Models;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(Context context)
        {
            // Exclui o esquema, copia as queries, cria esquema/tabelas, popula o BD;
            if (false)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();

                await Seed(context, HorarioBrasilia());
            }
        }

        private static async Task Seed(Context context, DateTime dataAgora)
        {
            #region seed_usuarios
            if (!await context.UsuariosTipos.AnyAsync())
            {
                await context.UsuariosTipos.AddAsync(new UsuarioTipo() { UsuarioTipoId = (int)UsuarioTipoEnum.Administrador, Tipo = nameof(UsuarioTipoEnum.Administrador), Descricao = "Administrador do sistema", IsAtivo = true, DataRegistro = dataAgora });
                await context.UsuariosTipos.AddAsync(new UsuarioTipo() { UsuarioTipoId = (int)UsuarioTipoEnum.Usuario, Tipo = GetDescricaoEnum(UsuarioTipoEnum.Usuario), Descricao = "Usuário comum", IsAtivo = true, DataRegistro = dataAgora });
            }

            if (!await context.Usuarios.AnyAsync())
            {
                await context.Usuarios.AddAsync(new Usuario() { UsuarioId = 1, NomeCompleto = "Administrador do Spotify", Email = "adm@Hotmail.com", NomeUsuarioSistema = "adm", Senha = Criptografar("123"), DataRegistro = dataAgora, UsuarioTipoId = (int)UsuarioTipoEnum.Administrador, Foto = "1AAAAA.webp", IsAtivo = true, IsVerificado = false });
                await context.Usuarios.AddAsync(new Usuario() { UsuarioId = 2, NomeCompleto = "Junior Souza", Email = "juninholorena@Hotmail.com", NomeUsuarioSistema = "junioranheu", Senha = Criptografar("123"), DataRegistro = dataAgora, UsuarioTipoId = (int)UsuarioTipoEnum.Usuario, Foto = "2AAAAA.webp", IsAtivo = true, IsVerificado = true });
            }
            #endregion

            #region seed_musicas
            if (!await context.Artistas.AnyAsync())
            {
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 1, Nome = "Freddie Mercury", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 2, Nome = "Brian May", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 3, Nome = "John Deacon", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 4, Nome = "Mike Grose", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 5, Nome = "Liam Gallagher", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 6, Nome = "Noel Gallagher", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 7, Nome = "Alex Turner", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 8, Nome = "Matt Helders", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 9, Nome = "Kevin Parker", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 10, Nome = "Matt Shultz", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 11, Nome = "Julian Casablancas", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 12, Nome = "Albert Hammond Jr", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 13, Nome = "Fabrizio Moretti", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 14, Nome = "Nikolai Fraiture", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 15, Nome = "James Mercer", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 16, Nome = "Danger Mouse", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 17, Nome = "Joe Newman", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 18, Nome = "Gus Under-Hamilton", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 19, Nome = "Jesse Rutherford", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 20, Nome = "Harry Styles", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 21, Nome = "Zayn Malik", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 22, Nome = "Liam Payne", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 23, Nome = "Louis Tomlison", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 24, Nome = "Niall Horan", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 25, Nome = "Billie Eilish", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 26, Nome = "Chaleco Israel", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 27, Nome = "Junior", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 28, Nome = "Lee Mavers", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 29, Nome = "MC Poze do Rodo", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 30, Nome = "Rúbel Brisolla", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 31, Nome = "Phillip Long", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 32, Nome = "John Mayer", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 33, Nome = "MC Lan", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 34, Nome = "Anthony Kiedis", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 35, Nome = "John Frusciante", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 36, Nome = "John Lennon", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 37, Nome = "Paul McCartney", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 38, Nome = "George Harrison", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 39, Nome = "Ringo Starr", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
                await context.Artistas.AddAsync(new Artista() { ArtistaId = 40, Nome = "Marisa Monte", Foto = "", IsAtivo = true, DataRegistro = dataAgora });
            }

            if (!await context.Bandas.AnyAsync())
            {
                await context.Bandas.AddAsync(new Banda() { BandaId = 1, Nome = "Queen", Sobre = "", Foto = "1.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(194, 46, 65, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 2, Nome = "Oasis", Sobre = "", Foto = "2.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(34, 19, 24, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 3, Nome = "Arctic Monkeys", Sobre = "", Foto = "3.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(80, 124, 147, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 4, Nome = "Tame Impala", Sobre = "", Foto = "4.webp", Seguidores = 0, IsAtivo = true, CorDominante = null, DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 5, Nome = "Cage The Elephant", Sobre = "", Foto = "5.webp", Seguidores = 0, IsAtivo = true, CorDominante = null, DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 6, Nome = "The Strokes", Sobre = "", Foto = "6.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(27, 34, 40, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 7, Nome = "Broken Bells", Sobre = "", Foto = "7.webp", Seguidores = 0, IsAtivo = true, CorDominante = null, DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 8, Nome = "The Shins", Sobre = "", Foto = "8.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(180, 222, 201, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 9, Nome = "alt-J", Sobre = "", Foto = "9.webp", Seguidores = 0, IsAtivo = true, CorDominante = null, DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 10, Nome = "The Neighbourhood", Foto = "10.webp", Sobre = "", Seguidores = 0, IsAtivo = true, CorDominante = null, DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 11, Nome = "One Direction", Sobre = "", Foto = "11.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(181, 224, 200, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 12, Nome = "Harry Styles", Sobre = "", Foto = "12.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(203, 120, 123, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 13, Nome = "Billie Eilish", Sobre = "", Foto = "13.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(249, 187, 94, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 14, Nome = "Zayn", Sobre = "", Foto = "14.webp", Seguidores = 0, IsAtivo = true, CorDominante = null, DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 15, Nome = "Chaleco's Group", Sobre = "", Foto = "15.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(144, 162, 120, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 16, Nome = "The La's", Sobre = "", Foto = "16.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(246, 162, 63, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 17, Nome = "MC Poze do Rodo", Sobre = "", Foto = "17.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(217, 45, 64, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 18, Nome = "Rúbel", Sobre = "", Foto = "18.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(19, 19, 19, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 19, Nome = "Phillip Long", Sobre = "", Foto = "19.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(246, 162, 63, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 20, Nome = "John Mayer", Sobre = "", Foto = "20.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(252, 181, 180, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 21, Nome = "MC Lan", Sobre = "", Foto = "21.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(215, 44, 63, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 22, Nome = "Red Hot Chili Peppers", Sobre = "", Foto = "22.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(17, 17, 17, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 23, Nome = "The Beatles", Sobre = "", Foto = "23.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(43, 59, 60, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 24, Nome = "George Harrison", Sobre = "", Foto = "24.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(217, 217, 217, 1)", DataRegistro = dataAgora });
                await context.Bandas.AddAsync(new Banda() { BandaId = 25, Nome = "Marisa Monte", Sobre = "", Foto = "25.webp", Seguidores = 0, IsAtivo = true, CorDominante = "rgba(230, 202, 179, 1)", DataRegistro = dataAgora });
            }

            if (!await context.BandasArtistas.AnyAsync())
            {
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 1, BandaId = 1, ArtistaId = 1, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 2, BandaId = 1, ArtistaId = 2, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 3, BandaId = 1, ArtistaId = 3, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 4, BandaId = 1, ArtistaId = 4, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 5, BandaId = 2, ArtistaId = 5, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 6, BandaId = 2, ArtistaId = 6, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 7, BandaId = 3, ArtistaId = 7, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 8, BandaId = 3, ArtistaId = 8, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 9, BandaId = 4, ArtistaId = 9, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 10, BandaId = 5, ArtistaId = 10, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 11, BandaId = 6, ArtistaId = 11, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 12, BandaId = 6, ArtistaId = 12, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 13, BandaId = 6, ArtistaId = 13, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 14, BandaId = 6, ArtistaId = 14, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 15, BandaId = 7, ArtistaId = 15, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 16, BandaId = 7, ArtistaId = 16, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 17, BandaId = 8, ArtistaId = 15, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 18, BandaId = 9, ArtistaId = 17, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 19, BandaId = 9, ArtistaId = 18, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 20, BandaId = 10, ArtistaId = 19, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 21, BandaId = 11, ArtistaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 22, BandaId = 11, ArtistaId = 21, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 23, BandaId = 11, ArtistaId = 22, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 24, BandaId = 11, ArtistaId = 23, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 25, BandaId = 11, ArtistaId = 24, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 26, BandaId = 12, ArtistaId = 20, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 27, BandaId = 13, ArtistaId = 25, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 28, BandaId = 14, ArtistaId = 21, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 29, BandaId = 15, ArtistaId = 26, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 30, BandaId = 15, ArtistaId = 27, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 31, BandaId = 16, ArtistaId = 28, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 32, BandaId = 17, ArtistaId = 29, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 33, BandaId = 18, ArtistaId = 30, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 34, BandaId = 19, ArtistaId = 31, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 35, BandaId = 20, ArtistaId = 32, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 36, BandaId = 21, ArtistaId = 33, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 37, BandaId = 22, ArtistaId = 34, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 38, BandaId = 22, ArtistaId = 35, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 39, BandaId = 23, ArtistaId = 36, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 40, BandaId = 23, ArtistaId = 37, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 41, BandaId = 23, ArtistaId = 38, IsAtivo = true, DataRegistro = dataAgora });
                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 42, BandaId = 23, ArtistaId = 39, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 43, BandaId = 24, ArtistaId = 38, IsAtivo = true, DataRegistro = dataAgora });

                await context.BandasArtistas.AddAsync(new BandaArtista() { BandaArtistaId = 44, BandaId = 25, ArtistaId = 40, IsAtivo = true, DataRegistro = dataAgora });
            }

            // Musicas e MusicasBandas;
            if (!await context.Musicas.AnyAsync())
            {
                await context.Musicas.AddAsync(new Musica() { MusicaId = 1, Nome = "Bohemian rhapsody", Ouvintes = 0, DuracaoSegundos = 359, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 2, Nome = "Live forever", Ouvintes = 0, DuracaoSegundos = 277, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 3, Nome = "Happier than ever", Ouvintes = 0, DuracaoSegundos = 298, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 4, Nome = "E aí, gordo", Ouvintes = 0, DuracaoSegundos = 6, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 5, Nome = "Is this it", Ouvintes = 0, DuracaoSegundos = 72, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 6, Nome = "Soma", Ouvintes = 0, DuracaoSegundos = 98, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 7, Nome = "Fluorescent adolescent", Ouvintes = 0, DuracaoSegundos = 117, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 8, Nome = "505", Ouvintes = 0, DuracaoSegundos = 253, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 9, Nome = "There she goes", Ouvintes = 0, DuracaoSegundos = 171, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 10, Nome = "Summer love", Ouvintes = 0, DuracaoSegundos = 209, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 11, Nome = "If I had a gun...", Ouvintes = 0, DuracaoSegundos = 247, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 12, Nome = "Shelter", Ouvintes = 0, DuracaoSegundos = 239, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 13, Nome = "Vida louca", Ouvintes = 0, DuracaoSegundos = 154, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 14, Nome = "Quando bate aquela saudade", Ouvintes = 0, DuracaoSegundos = 394, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 15, Nome = "No. 1 party anthem", Ouvintes = 0, DuracaoSegundos = 243, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 16, Nome = "New light", Ouvintes = 0, DuracaoSegundos = 216, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 17, Nome = "Dark necessities", Ouvintes = 0, DuracaoSegundos = 302, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 18, Nome = "Last train home", Ouvintes = 0, DuracaoSegundos = 187, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 19, Nome = "I guess I just feel like", Ouvintes = 0, DuracaoSegundos = 287, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 20, Nome = "Belief", Ouvintes = 0, DuracaoSegundos = 242, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 21, Nome = "Little James", Ouvintes = 0, DuracaoSegundos = 255, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 22, Nome = "Want someone to remember me", Ouvintes = 0, DuracaoSegundos = 205, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 23, Nome = "Xuliana (anos 80)", Ouvintes = 0, DuracaoSegundos = 128, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 24, Nome = "Hey Jude", Ouvintes = 0, DuracaoSegundos = 425, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 25, Nome = "Don't let me down", Ouvintes = 0, DuracaoSegundos = 215, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 26, Nome = "My sweet lord", Ouvintes = 0, DuracaoSegundos = 263, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 27, Nome = "Amor I love you", Ouvintes = 0, DuracaoSegundos = 102, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
                await context.Musicas.AddAsync(new Musica() { MusicaId = 28, Nome = "As it was", Ouvintes = 0, DuracaoSegundos = 163, DataLancamento = dataAgora, IsAtivo = true, DataRegistro = dataAgora });
            }

            if (!await context.MusicasBandas.AnyAsync())
            {
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 1, MusicaId = 1, BandaId = 1, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 2, MusicaId = 2, BandaId = 2, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 3, MusicaId = 3, BandaId = 13, IsAtivo = true, DataRegistro = dataAgora });

                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 4, MusicaId = 4, BandaId = 15, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 5, MusicaId = 4, BandaId = 13, IsAtivo = true, DataRegistro = dataAgora });

                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 6, MusicaId = 5, BandaId = 6, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 7, MusicaId = 6, BandaId = 6, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 8, MusicaId = 7, BandaId = 3, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 9, MusicaId = 8, BandaId = 3, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 10, MusicaId = 9, BandaId = 16, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 11, MusicaId = 10, BandaId = 11, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 12, MusicaId = 11, BandaId = 2, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 13, MusicaId = 12, BandaId = 7, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 14, MusicaId = 13, BandaId = 17, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 15, MusicaId = 14, BandaId = 18, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 16, MusicaId = 15, BandaId = 3, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 17, MusicaId = 16, BandaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 18, MusicaId = 17, BandaId = 22, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 19, MusicaId = 18, BandaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 20, MusicaId = 19, BandaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 21, MusicaId = 20, BandaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 22, MusicaId = 21, BandaId = 2, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 23, MusicaId = 22, BandaId = 19, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 24, MusicaId = 23, BandaId = 21, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 25, MusicaId = 24, BandaId = 23, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 26, MusicaId = 25, BandaId = 23, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 27, MusicaId = 26, BandaId = 24, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 28, MusicaId = 27, BandaId = 25, IsAtivo = true, DataRegistro = dataAgora });
                await context.MusicasBandas.AddAsync(new MusicaBanda() { MusicaBandaId = 29, MusicaId = 28, BandaId = 12, IsAtivo = true, DataRegistro = dataAgora });
            }

            // Albuns e AlbunsMusicas;
            if (!await context.Albuns.AnyAsync())
            {
                await context.Albuns.AddAsync(new Album() { AlbumId = 1, Nome = "Is This It", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 6, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 2, Nome = "Favourite Worst Nightmare", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 3, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 3, Nome = "Continuum", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 4, Nome = "Sob Rock", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 5, Nome = "Definitely Maybe", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 2, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 6, Nome = "Happier Than Ever", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 13, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 7, Nome = "Take Me Home", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 11, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 8, Nome = "AM", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 3, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 9, Nome = "The Getaway", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 22, IsAtivo = true, DataRegistro = dataAgora });
                await context.Albuns.AddAsync(new Album() { AlbumId = 10, Nome = "All Things Must Pass", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 24, IsAtivo = true, DataRegistro = dataAgora });
            }

            if (!await context.AlbunsMusicas.AnyAsync())
            {
                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 1, AlbumId = 1, MusicaId = 5, IsAtivo = true, DataRegistro = dataAgora });
                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 2, AlbumId = 1, MusicaId = 6, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 3, AlbumId = 2, MusicaId = 7, IsAtivo = true, DataRegistro = dataAgora });
                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 4, AlbumId = 2, MusicaId = 8, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 5, AlbumId = 3, MusicaId = 20, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 6, AlbumId = 4, MusicaId = 16, IsAtivo = true, DataRegistro = dataAgora });
                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 7, AlbumId = 4, MusicaId = 18, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 8, AlbumId = 5, MusicaId = 2, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 9, AlbumId = 6, MusicaId = 3, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 10, AlbumId = 7, MusicaId = 10, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 11, AlbumId = 8, MusicaId = 15, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 12, AlbumId = 9, MusicaId = 17, IsAtivo = true, DataRegistro = dataAgora });

                await context.AlbunsMusicas.AddAsync(new AlbumMusica() { AlbumMusicaId = 13, AlbumId = 10, MusicaId = 26, IsAtivo = true, DataRegistro = dataAgora });
            }

            // Playlists e PlaylistsMusicas;
            if (!await context.Playlists.AnyAsync())
            {
                await context.Playlists.AddAsync(new Playlist() { PlaylistId = 1, Nome = "Indie Rock Club", Sobre = "Apenas músicas indies", Foto = "1.webp", CorDominante = "rgba(207, 26, 46, 1)", UsuarioId = 1, IsAtivo = true, DataRegistro = dataAgora });
                await context.Playlists.AddAsync(new Playlist() { PlaylistId = 2, Nome = "Energy Booster Rock 🤘", Sobre = "Os mais clássicos", Foto = "2.webp", CorDominante = "rgba(236, 30, 52, 1)", UsuarioId = 1, IsAtivo = true, DataRegistro = dataAgora });
                await context.Playlists.AddAsync(new Playlist() { PlaylistId = 3, Nome = "Oi né?", Sobre = "Os hits mais tops do momento, Faraon Love Shady, por exemplo! 👌", Foto = "3.webp", CorDominante = "rgba(45, 216, 145, 1)", UsuarioId = 1, IsAtivo = false, DataRegistro = dataAgora });
                await context.Playlists.AddAsync(new Playlist() { PlaylistId = 4, Nome = "Happy Pop Hits 💋", Sobre = "Cabro reklo", Foto = "4.webp", CorDominante = "rgba(81, 155, 246, 1)", UsuarioId = 1, IsAtivo = true, DataRegistro = dataAgora });
                await context.Playlists.AddAsync(new Playlist() { PlaylistId = 5, Nome = "Mother Funk", Sobre = "As mais tocadas", Foto = "5.webp", CorDominante = "rgba(34, 54, 104, 1)", UsuarioId = 1, IsAtivo = true, DataRegistro = dataAgora });
                await context.Playlists.AddAsync(new Playlist() { PlaylistId = 6, Nome = "Amor, I love you ❤️", Sobre = "Para chorar de amor", Foto = "6.webp", CorDominante = "rgba(233, 32, 52, 1)", UsuarioId = 1, IsAtivo = true, DataRegistro = dataAgora });
            }

            if (!await context.PlaylistsMusicas.AnyAsync())
            {
                // Indie;
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 1, PlaylistId = 1, MusicaId = 5, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 2, PlaylistId = 1, MusicaId = 6, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 3, PlaylistId = 1, MusicaId = 7, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 4, PlaylistId = 1, MusicaId = 8, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 5, PlaylistId = 1, MusicaId = 12, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 6, PlaylistId = 1, MusicaId = 15, IsAtivo = true, DataRegistro = dataAgora });

                // Rock;
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 7, PlaylistId = 2, MusicaId = 1, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 8, PlaylistId = 2, MusicaId = 2, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 9, PlaylistId = 2, MusicaId = 11, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 10, PlaylistId = 2, MusicaId = 17, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 11, PlaylistId = 2, MusicaId = 21, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 12, PlaylistId = 2, MusicaId = 24, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 13, PlaylistId = 2, MusicaId = 25, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 14, PlaylistId = 2, MusicaId = 26, IsAtivo = true, DataRegistro = dataAgora });

                // Zoados;
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 15, PlaylistId = 3, MusicaId = 4, IsAtivo = true, DataRegistro = dataAgora });

                // Pop;
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 16, PlaylistId = 4, MusicaId = 3, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 17, PlaylistId = 4, MusicaId = 9, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 18, PlaylistId = 4, MusicaId = 10, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 19, PlaylistId = 4, MusicaId = 16, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 20, PlaylistId = 4, MusicaId = 18, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 21, PlaylistId = 4, MusicaId = 19, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 22, PlaylistId = 4, MusicaId = 20, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 23, PlaylistId = 4, MusicaId = 28, IsAtivo = true, DataRegistro = dataAgora });

                // Funk;
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 24, PlaylistId = 5, MusicaId = 13, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 25, PlaylistId = 5, MusicaId = 23, IsAtivo = true, DataRegistro = dataAgora });

                // Amor;
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 26, PlaylistId = 6, MusicaId = 14, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 27, PlaylistId = 6, MusicaId = 22, IsAtivo = true, DataRegistro = dataAgora });
                await context.PlaylistsMusicas.AddAsync(new PlaylistMusica() { PlaylistMusicaId = 28, PlaylistId = 6, MusicaId = 27, IsAtivo = true, DataRegistro = dataAgora });
            }
            #endregion

            await context.SaveChangesAsync();
        }
    }
}

