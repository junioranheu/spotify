using Spotify.Models;
using static Biblioteca.Biblioteca;

namespace Spotify.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            // Exclui o esquema, copia as queries, cria esquema/tabelas, popula o BD;
            bool resetarBd = false;
            if (resetarBd)
            {
                context.Database.EnsureDeleted(); // Excluir o esquema e as tabelas;
                // string sqlErro = context.Database.GenerateCreateScript(); // Query para criar as tabelas;
                context.Database.EnsureCreated(); // Recriar o esquema e as tabelas;

                Seed(context);
            }
        }

        public static void Seed(Context context)
        {
            // Hora atual;
            DateTime dataAgora = HorarioBrasilia();

            #region seed_usuarios
            if (!context.UsuariosTipos.Any())
            {
                context.UsuariosTipos.Add(new UsuarioTipo() { UsuarioTipoId = 1, Tipo = "Administrador", Descricao = "Administrador do sistema", IsAtivo = 1, DataCriacao = dataAgora });
                context.UsuariosTipos.Add(new UsuarioTipo() { UsuarioTipoId = 2, Tipo = "Usuário", Descricao = "Usuário comum", IsAtivo = 1, DataCriacao = dataAgora });
            }

            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario() { UsuarioId = 1, NomeCompleto = "Spotify", Email = "adm@Hotmail.com", NomeUsuarioSistema = "adm", Senha = Criptografar("123"), DataCriacao = dataAgora, UsuarioTipoId = 1, Foto = "", IsAtivo = 1, IsPremium = 1, IsVerificado = 1 });
                context.Usuarios.Add(new Usuario() { UsuarioId = 2, NomeCompleto = "Junior", Email = "juninholorena@Hotmail.com", NomeUsuarioSistema = "junioranheu", Senha = Criptografar("123"), DataCriacao = dataAgora, UsuarioTipoId = 2, Foto = "", IsAtivo = 1, IsPremium = 1, IsVerificado = 1 });
                context.Usuarios.Add(new Usuario() { UsuarioId = 3, NomeCompleto = "Usuário", Email = "usuario@Hotmail.com", NomeUsuarioSistema = "usuario", Senha = Criptografar("123"), DataCriacao = dataAgora, UsuarioTipoId = 2, Foto = "", IsAtivo = 1, IsPremium = 1, IsVerificado = 1 });
            }

            if (!context.UsuariosInformacoes.Any())
            {
                context.UsuariosInformacoes.Add(new UsuarioInformacao()
                {
                    UsuarioInformacaoId = 1,
                    UsuarioId = 2,
                    Genero = 1,
                    DataAniversario = dataAgora,
                    CPF = "44571955880",
                    Telefone = "12 98271-3939",
                    Rua = "José Benedito Ferrari",
                    NumeroResidencia = "480",
                    CEP = "12605-110",
                    Bairro = "Vila Passos",
                    DataUltimaAlteracao = null
                });
            }
            #endregion

            #region seed_musicas
            // Artistas, Bandas e BandasArtistas;
            if (!context.Artistas.Any())
            {
                context.Artistas.Add(new Artista() { ArtistaId = 1, Nome = "Freddie Mercury", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 2, Nome = "Brian May", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 3, Nome = "John Deacon", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 4, Nome = "Mike Grose", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 5, Nome = "Liam Gallagher", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 6, Nome = "Noel Gallagher", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 7, Nome = "Alex Turner", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 8, Nome = "Matt Helders", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 9, Nome = "Kevin Parker", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 10, Nome = "Matt Shultz", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 11, Nome = "Julian Casablancas", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 12, Nome = "Albert Hammond Jr", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 13, Nome = "Fabrizio Moretti", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 14, Nome = "Nikolai Fraiture", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 15, Nome = "James Mercer", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 16, Nome = "Danger Mouse", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 17, Nome = "Joe Newman", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 18, Nome = "Gus Under-Hamilton", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 19, Nome = "Jesse Rutherford", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 20, Nome = "Harry Styles", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 21, Nome = "Zayn Malik", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 22, Nome = "Liam Payne", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 23, Nome = "Louis Tomlison", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 24, Nome = "Niall Horan", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 25, Nome = "Billie Eilish", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 26, Nome = "Chaleco Israel", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 27, Nome = "Junior", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 28, Nome = "Lee Mavers", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 29, Nome = "MC Poze do Rodo", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 30, Nome = "Rúbel Brisolla", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 31, Nome = "Phillip Long", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 32, Nome = "John Mayer", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 33, Nome = "MC Lan", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 34, Nome = "Anthony Kiedis", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 35, Nome = "John Frusciante", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 36, Nome = "John Lennon", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 37, Nome = "Paul McCartney", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 38, Nome = "George Harrison", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 39, Nome = "Ringo Starr", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 40, Nome = "Marisa Monte", Foto = "", IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.Bandas.Any())
            {
                context.Bandas.Add(new Banda() { BandaId = 1, Nome = "Queen", Sobre = "", Foto = "1.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 2, Nome = "Oasis", Sobre = "", Foto = "2.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 3, Nome = "Arctic Monkeys", Sobre = "", Foto = "3.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 4, Nome = "Tame Impala", Sobre = "", Foto = "4.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 5, Nome = "Cage The Elephant", Sobre = "", Foto = "5.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 6, Nome = "The Strokes", Sobre = "", Foto = "6.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 7, Nome = "Broken Bells", Sobre = "", Foto = "7.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 8, Nome = "The Shins", Sobre = "", Foto = "8.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 9, Nome = "alt-J", Sobre = "", Foto = "9.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 10, Nome = "The Neighbourhood", Foto = "10.webp", Sobre = "", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 11, Nome = "One Direction", Sobre = "", Foto = "11.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 12, Nome = "Harry Styles", Sobre = "", Foto = "12.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 13, Nome = "Billie Eilish", Sobre = "", Foto = "13.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 14, Nome = "Zayn", Sobre = "", Foto = "14.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 15, Nome = "Chaleco's Group", Sobre = "", Foto = "15.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 16, Nome = "The La's", Sobre = "", Foto = "16.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 17, Nome = "MC Poze do Rodo", Sobre = "", Foto = "17.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 18, Nome = "Rúbel", Sobre = "", Foto = "18.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 19, Nome = "Phillip Long", Sobre = "", Foto = "19.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 20, Nome = "John Mayer", Sobre = "", Foto = "20.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 21, Nome = "MC Lan", Sobre = "", Foto = "21.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 22, Nome = "Red Hot Chili Peppers", Sobre = "", Foto = "22.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 23, Nome = "The Beatles", Sobre = "", Foto = "23.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 24, Nome = "George Harrison", Sobre = "", Foto = "24.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 25, Nome = "Marisa Monte", Sobre = "", Foto = "25.webp", Seguidores = 0, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.BandasArtistas.Any())
            {
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 1, BandaId = 1, ArtistaId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 2, BandaId = 1, ArtistaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 3, BandaId = 1, ArtistaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 4, BandaId = 1, ArtistaId = 4, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 5, BandaId = 2, ArtistaId = 5, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 6, BandaId = 2, ArtistaId = 6, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 7, BandaId = 3, ArtistaId = 7, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 8, BandaId = 3, ArtistaId = 8, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 9, BandaId = 4, ArtistaId = 9, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 10, BandaId = 5, ArtistaId = 10, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 11, BandaId = 6, ArtistaId = 11, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 12, BandaId = 6, ArtistaId = 12, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 13, BandaId = 6, ArtistaId = 13, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 14, BandaId = 6, ArtistaId = 14, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 15, BandaId = 7, ArtistaId = 15, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 16, BandaId = 7, ArtistaId = 16, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 17, BandaId = 8, ArtistaId = 15, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 18, BandaId = 9, ArtistaId = 17, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 19, BandaId = 9, ArtistaId = 18, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 20, BandaId = 10, ArtistaId = 19, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 21, BandaId = 11, ArtistaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 22, BandaId = 11, ArtistaId = 21, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 23, BandaId = 11, ArtistaId = 22, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 24, BandaId = 11, ArtistaId = 23, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 25, BandaId = 11, ArtistaId = 24, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 26, BandaId = 12, ArtistaId = 20, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 27, BandaId = 13, ArtistaId = 25, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 28, BandaId = 14, ArtistaId = 21, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 29, BandaId = 15, ArtistaId = 26, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 30, BandaId = 15, ArtistaId = 27, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 31, BandaId = 16, ArtistaId = 28, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 32, BandaId = 17, ArtistaId = 29, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 33, BandaId = 18, ArtistaId = 30, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 34, BandaId = 19, ArtistaId = 31, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 35, BandaId = 20, ArtistaId = 32, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 36, BandaId = 21, ArtistaId = 33, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 37, BandaId = 22, ArtistaId = 34, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 38, BandaId = 22, ArtistaId = 35, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 39, BandaId = 23, ArtistaId = 36, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 40, BandaId = 23, ArtistaId = 37, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 41, BandaId = 23, ArtistaId = 38, IsAtivo = 1, DataRegistro = dataAgora });
                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 42, BandaId = 23, ArtistaId = 39, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 43, BandaId = 24, ArtistaId = 38, IsAtivo = 1, DataRegistro = dataAgora });

                context.BandasArtistas.Add(new BandaArtista() { BandaArtistaId = 44, BandaId = 25, ArtistaId = 40, IsAtivo = 1, DataRegistro = dataAgora });
            }

            // Musicas e MusicasBandas;
            if (!context.Musicas.Any())
            {
                context.Musicas.Add(new Musica() { MusicaId = 1, Nome = "Bohemian rhapsody", Ouvintes = 0, DuracaoSegundos = 359, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 2, Nome = "Live forever", Ouvintes = 0, DuracaoSegundos = 277, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 3, Nome = "Happier than ever", Ouvintes = 0, DuracaoSegundos = 298, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 4, Nome = "E aí, gordo", Ouvintes = 0, DuracaoSegundos = 6, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 5, Nome = "Is this it", Ouvintes = 0, DuracaoSegundos = 72, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 6, Nome = "Soma", Ouvintes = 0, DuracaoSegundos = 98, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 7, Nome = "Fluorescent adolescent", Ouvintes = 0, DuracaoSegundos = 117, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 8, Nome = "505", Ouvintes = 0, DuracaoSegundos = 253, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 9, Nome = "There she goes", Ouvintes = 0, DuracaoSegundos = 171, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 10, Nome = "Summer love", Ouvintes = 0, DuracaoSegundos = 209, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 11, Nome = "If I had a gun...", Ouvintes = 0, DuracaoSegundos = 247, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 12, Nome = "Shelter", Ouvintes = 0, DuracaoSegundos = 239, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 13, Nome = "Vida louca", Ouvintes = 0, DuracaoSegundos = 154, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 14, Nome = "Quando bate aquela saudade", Ouvintes = 0, DuracaoSegundos = 394, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 15, Nome = "No. 1 party anthem", Ouvintes = 0, DuracaoSegundos = 243, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 16, Nome = "New light", Ouvintes = 0, DuracaoSegundos = 216, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 17, Nome = "Dark necessities", Ouvintes = 0, DuracaoSegundos = 302, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 18, Nome = "Last train home", Ouvintes = 0, DuracaoSegundos = 187, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 19, Nome = "I guess I just feel like", Ouvintes = 0, DuracaoSegundos = 287, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 20, Nome = "Belief", Ouvintes = 0, DuracaoSegundos = 242, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 21, Nome = "Little James", Ouvintes = 0, DuracaoSegundos = 255, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 22, Nome = "Want someone to remember me", Ouvintes = 0, DuracaoSegundos = 205, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 23, Nome = "Xuliana (anos 80)", Ouvintes = 0, DuracaoSegundos = 128, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 24, Nome = "Hey Jude", Ouvintes = 0, DuracaoSegundos = 425, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 25, Nome = "Don't let me down", Ouvintes = 0, DuracaoSegundos = 215, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 26, Nome = "My sweet lord", Ouvintes = 0, DuracaoSegundos = 263, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 27, Nome = "Amor I love you", Ouvintes = 0, DuracaoSegundos = 102, DataLancamento = dataAgora, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.MusicasBandas.Any())
            {
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 1, MusicaId = 1, BandaId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 2, MusicaId = 2, BandaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 3, MusicaId = 3, BandaId = 13, IsAtivo = 1, DataRegistro = dataAgora });

                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 4, MusicaId = 4, BandaId = 15, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 5, MusicaId = 4, BandaId = 13, IsAtivo = 1, DataRegistro = dataAgora });

                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 6, MusicaId = 5, BandaId = 6, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 7, MusicaId = 6, BandaId = 6, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 8, MusicaId = 7, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 9, MusicaId = 8, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 10, MusicaId = 9, BandaId = 16, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 11, MusicaId = 10, BandaId = 11, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 12, MusicaId = 11, BandaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 13, MusicaId = 12, BandaId = 7, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 14, MusicaId = 13, BandaId = 17, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 15, MusicaId = 14, BandaId = 18, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 16, MusicaId = 15, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 17, MusicaId = 16, BandaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 18, MusicaId = 17, BandaId = 22, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 19, MusicaId = 18, BandaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 20, MusicaId = 19, BandaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 21, MusicaId = 20, BandaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 22, MusicaId = 21, BandaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 23, MusicaId = 22, BandaId = 19, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 24, MusicaId = 23, BandaId = 21, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 25, MusicaId = 24, BandaId = 23, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 26, MusicaId = 25, BandaId = 23, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 27, MusicaId = 26, BandaId = 24, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 28, MusicaId = 27, BandaId = 25, IsAtivo = 1, DataRegistro = dataAgora });
            }

            // Albuns e AlbunsMusicas;
            if (!context.Albuns.Any())
            {
                context.Albuns.Add(new Album() { AlbumId = 1, Nome = "Is This It", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 6, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 2, Nome = "Favourite Worst Nightmare", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 3, Nome = "Continuum", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 4, Nome = "Sob Rock", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 20, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 5, Nome = "Definitely Maybe", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 6, Nome = "Happier Than Ever", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 13, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 7, Nome = "Take Me Home", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 11, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 8, Nome = "AM", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 9, Nome = "The Getaway", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 22, IsAtivo = 1, DataRegistro = dataAgora });
                context.Albuns.Add(new Album() { AlbumId = 10, Nome = "All Things Must Pass", Sobre = "", Foto = "", DataLancamento = dataAgora, BandaId = 24, IsAtivo = 1, DataRegistro = dataAgora });          
            }

            if (!context.AlbunsMusicas.Any())
            {
                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 1, AlbumId = 1, MusicaId = 5, IsAtivo = 1, DataRegistro = dataAgora });
                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 2, AlbumId = 1, MusicaId = 6, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 3, AlbumId = 2, MusicaId = 7, IsAtivo = 1, DataRegistro = dataAgora });
                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 4, AlbumId = 2, MusicaId = 8, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 4, AlbumId = 3, MusicaId = 20, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 4, AlbumId = 4, MusicaId = 16, IsAtivo = 1, DataRegistro = dataAgora });
                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 5, AlbumId = 4, MusicaId = 18, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 6, AlbumId = 5, MusicaId = 2, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 7, AlbumId = 6, MusicaId = 3, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 8, AlbumId = 7, MusicaId = 10, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 9, AlbumId = 8, MusicaId = 15, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 10, AlbumId = 9, MusicaId = 17, IsAtivo = 1, DataRegistro = dataAgora });

                context.AlbunsMusicas.Add(new AlbumMusica() { AlbumMusicaId = 11, AlbumId = 10, MusicaId = 26, IsAtivo = 1, DataRegistro = dataAgora });
            }

            // Playlists e PlaylistsMusicas;
            if (!context.Playlists.Any())
            {
                context.Playlists.Add(new Playlist() { PlaylistId = 1, Nome = "Indie Rock Club", Sobre = "Apenas músicas indies", Foto = "1.webp", UsuarioId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.Playlists.Add(new Playlist() { PlaylistId = 2, Nome = "Energy Booster Rock 🤘", Sobre = "Os mais clássicos", Foto = "2.webp", UsuarioId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.Playlists.Add(new Playlist() { PlaylistId = 3, Nome = "Oi né?", Sobre = "Os hits mais tops do momento, Faraon Love Shady, por exemplo! 👌", Foto = "3.webp", UsuarioId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.Playlists.Add(new Playlist() { PlaylistId = 4, Nome = "Happy Pop Hits 💋", Sobre = "Cabro reklo", Foto = "4.webp", UsuarioId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.Playlists.Add(new Playlist() { PlaylistId = 5, Nome = "Mother Funk", Sobre = "As mais tocadas", Foto = "5.webp", UsuarioId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.Playlists.Add(new Playlist() { PlaylistId = 6, Nome = "Amor, I love you ❤️", Sobre = "Para chorar de amor", Foto = "6.webp", UsuarioId = 1, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.PlaylistsMusicas.Any())
            {
                // Indie;
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 1, PlaylistId = 1, MusicaId = 5, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 2, PlaylistId = 1, MusicaId = 6, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 3, PlaylistId = 1, MusicaId = 7, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 4, PlaylistId = 1, MusicaId = 8, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 5, PlaylistId = 1, MusicaId = 12, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 6, PlaylistId = 1, MusicaId = 15, IsAtivo = 1, DataRegistro = dataAgora });

                // Rock;
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 7, PlaylistId = 2, MusicaId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 8, PlaylistId = 2, MusicaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 9, PlaylistId = 2, MusicaId = 11, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 10, PlaylistId = 2, MusicaId = 17, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 11, PlaylistId = 2, MusicaId = 21, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 12, PlaylistId = 2, MusicaId = 24, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 13, PlaylistId = 2, MusicaId = 25, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 14, PlaylistId = 2, MusicaId = 26, IsAtivo = 1, DataRegistro = dataAgora });

                // Zoados;
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 15, PlaylistId = 3, MusicaId = 4, IsAtivo = 1, DataRegistro = dataAgora });

                // Pop;
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 16, PlaylistId = 4, MusicaId = 3, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 17, PlaylistId = 4, MusicaId = 9, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 18, PlaylistId = 4, MusicaId = 10, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 19, PlaylistId = 4, MusicaId = 16, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 20, PlaylistId = 4, MusicaId = 18, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 21, PlaylistId = 4, MusicaId = 19, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 22, PlaylistId = 4, MusicaId = 20, IsAtivo = 1, DataRegistro = dataAgora });

                // Funk;
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 23, PlaylistId = 5, MusicaId = 13, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 24, PlaylistId = 5, MusicaId = 23, IsAtivo = 1, DataRegistro = dataAgora });

                // Amor;
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 25, PlaylistId = 6, MusicaId = 14, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 26, PlaylistId = 6, MusicaId = 22, IsAtivo = 1, DataRegistro = dataAgora });
                context.PlaylistsMusicas.Add(new PlaylistMusica() { PlaylistMusicaId = 27, PlaylistId = 6, MusicaId = 27, IsAtivo = 1, DataRegistro = dataAgora });
            }
            #endregion

            context.SaveChanges();
        }
    }
}

