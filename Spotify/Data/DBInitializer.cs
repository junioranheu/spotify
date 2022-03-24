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

