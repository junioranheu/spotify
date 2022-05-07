using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using static Biblioteca.Biblioteca;

namespace Spotify.Tests.Testing
{
    public class BibliotecaTests
    {
        private readonly ITestOutputHelper _output; // https://xunit.net/docs/capturing-output;

        public BibliotecaTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test_HorarioBrasilia()
        {
            Assert.True(HorarioBrasilia() > DateTime.MinValue);
        }

        [Fact]
        public void Test_Criptografar()
        {
            string senhaTeste = "123";
            Assert.True(!String.IsNullOrEmpty(Criptografar(senhaTeste)));
        }

        [Fact]
        public void Test_CriptografarEValidarSenha()
        {
            List<string> listaSenhas = new() { "123", "Teste300", "TesteTeste", "TesteTeste1" };

            foreach (var senha in listaSenhas)
            {
                bool isOk = ValidarSenha(senha);

                if (isOk)
                {
                    string senhaCriptografada = Criptografar(senha);
                    Assert.True(!String.IsNullOrEmpty(senhaCriptografada));
                    _output.WriteLine($"A senha \"{senha}\" é valida, e foi criptografada: \"{senhaCriptografada}\"");
                }
                else
                {
                    _output.WriteLine($"A senha \"{senha}\" não é valida, portanto não será criptografada");
                }
            }
        }
    }
}
