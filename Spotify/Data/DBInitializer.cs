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

            if (!context.Artistas.Any())
            {
                context.Artistas.Add(new Artista() { ArtistaId = 1, Nome = "Freddie Mercury", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 2, Nome = "Brian May", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 3, Nome = "John Deacon", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 4, Nome = "Mike Grose", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 5, Nome = "Liam Gallagher", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 6, Nome = "Noel Gallagher", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 7, Nome = "Billie Eilish", IsAtivo = 1, DataRegistro = dataAgora });
                context.Artistas.Add(new Artista() { ArtistaId = 8, Nome = "Chaleco Israel", IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.MusicasArtistas.Any())
            {
                context.MusicasArtistas.Add(new MusicaArtista() { MusicaArtistaId = 1, MusicaId = 3, ArtistaId = 7, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasArtistas.Add(new MusicaArtista() { MusicaArtistaId = 2, MusicaId = 3, ArtistaId = 8, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.Bandas.Any())
            {
                context.Bandas.Add(new Banda() { BandaId = 1, Nome = "Queen", IsAtivo = 1, DataRegistro = dataAgora });
                context.Bandas.Add(new Banda() { BandaId = 2, Nome = "Oasis", IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.MusicasBandas.Any())
            {
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 1, MusicaId = 1, BandaId = 1, IsAtivo = 1, DataRegistro = dataAgora });
                context.MusicasBandas.Add(new MusicaBanda() { MusicaBandaId = 2, MusicaId = 2, BandaId = 2, IsAtivo = 1, DataRegistro = dataAgora });
            }

            if (!context.Musicas.Any())
            {
                context.Musicas.Add(new Musica() { MusicaId = 1, Nome = "Bohemian Rhapsody", IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 2, Nome = "Live forever", IsAtivo = 1, DataRegistro = dataAgora });
                context.Musicas.Add(new Musica() { MusicaId = 3, Nome = "Happier than ever", IsAtivo = 1, DataRegistro = dataAgora });
            }

            context.SaveChanges();
        }
    }
}

