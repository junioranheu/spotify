﻿using MediaToolkit;
using MediaToolkit.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using TimeZoneConverter;
using VideoLibrary;

namespace Spotify.Utils
{
    public class Biblioteca
    {
        // Pegar informações do appsettings: https://stackoverflow.com/a/58432834 (Necessário instalar o pacote "Microsoft.Extensions.Configuration.Json");
        static readonly string encriptionKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("PasswordEncryptionSettings")["EncryptionKey"] ?? "";

        // Converter para o horário de Brasilia: https://blog.yowko.com/timezoneinfo-time-zone-id-not-found/;
        public static DateTime HorarioBrasilia()
        {
            TimeZoneInfo timeZone = TZConvert.GetTimeZoneInfo("E. South America Standard Time");
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
        }

        // Criptografar e decriptografar senha: https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp;
        public static string Criptografar(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new(password: encriptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }

                clearText = Convert.ToBase64String(ms.ToArray());
            }

            return clearText;
        }

        public static string Descriptografar(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new(password: encriptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }

            return cipherText;
        }

        // Gerar uma string aleatória com base na quantidade de caracteres desejados;
        public static string GerarStringAleatoria(int qtdCaracteres, bool isApenasMaiusculas)
        {
            Random random = new();
            string caracteres = (isApenasMaiusculas ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" : "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");
            string? stringAleatoria = new(Enumerable.Repeat(caracteres, qtdCaracteres).Select(s => s[random.Next(s.Length)]).ToArray());

            return stringAleatoria;
        }

        // Validar se a senha do usuário é forte o suficiente verificando requisitos de senha:
        // #1 - Tem número;
        // #2 - Tem letra maiúscula;
        // #3 - Tem pelo menos X caracteres;
        // #4 - A senha não contém o nome completo, nome de usuário ou e-mail;
        public static Tuple<bool, string> ValidarSenha(string senha, string nomeCompleto, string nomeUsuario, string email)
        {
            bool isValido = true;
            string msgErro = "";

            var temNumero = new Regex(@"[0-9]+");
            if (!temNumero.IsMatch(senha))
            {
                isValido = false;
                msgErro = "A senha deve conter ao menos um número";
                return Tuple.Create(isValido, msgErro);
            }

            var temMaiusculo = new Regex(@"[A-Z]+");
            if (!temMaiusculo.IsMatch(senha))
            {
                isValido = false;
                msgErro = "A senha deve conter ao menos uma letra maiúscula";
                return Tuple.Create(isValido, msgErro);
            }

            int minCaracteres = 6;
            var temXCaracteres = new Regex(@".{" + minCaracteres + ",}");
            if (!temXCaracteres.IsMatch(senha))
            {
                isValido = false;
                msgErro = $"A senha deve conter ao menos {minCaracteres} caracteres";
                return Tuple.Create(isValido, msgErro);
            }

            string nomeCompletoPrimeiraParte = nomeCompleto.Split(' ')[0].ToLowerInvariant();
            bool isRepeteNomeCompleto = senha.ToLowerInvariant().Contains(nomeCompletoPrimeiraParte);
            if (isRepeteNomeCompleto)
            {
                isValido = false;
                msgErro = "A senha não pode conter o seu primeiro nome";
                return Tuple.Create(isValido, msgErro);
            }

            bool isRepeteNomeUsuario = senha.ToLowerInvariant().Contains(nomeUsuario.ToLowerInvariant());
            if (isRepeteNomeUsuario)
            {
                isValido = false;
                msgErro = "A senha não pode conter o seu nome de usuário";
                return Tuple.Create(isValido, msgErro);
            }

            string emailAntesDoArroba = email.Split('@')[0].ToLowerInvariant();
            bool isRepeteEmail = senha.ToLowerInvariant().Contains(emailAntesDoArroba.ToLowerInvariant());
            if (isRepeteEmail)
            {
                isValido = false;
                msgErro = "A senha não pode conter o seu e-mail";
                return Tuple.Create(isValido, msgErro);
            }

            return Tuple.Create(isValido, msgErro);
        }

        // Validar se o e-mail do usuário;
        public static bool ValidarEmail(string email)
        {
            EmailAddressAttribute e = new();
            return e.IsValid(email);
        }

        // Pegar a descrição de um enum: https://stackoverflow.com/questions/50433909/get-string-name-from-enum-in-c-sharp;
        public static string GetDescricaoEnum(Enum enumVal)
        {
            MemberInfo[] memInfo = enumVal.GetType().GetMember(enumVal.ToString());
            DescriptionAttribute attribute = CustomAttributeExtensions.GetCustomAttribute<DescriptionAttribute>(memInfo[0]);
            return attribute.Description;
        }

        // Pegar o tipo da extensão de um arquivo;
        public static string GetMimeType(string caminhoArquivo)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(caminhoArquivo).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();

            return mimeType;
        }

        // Salvar vídeo do Youtube como .mp3: https://stackoverflow.com/questions/39877884/c-sharp-download-the-sound-of-a-youtube-video;
        // Foi necessário instalar o pacote "System.Configuration.ConfigurationManager" também;
        public static async Task<bool> YoutubeToMp3(string pastaDestino, string urlVideo, string nomeArquivoMp3)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // Baixar arquivo do Youtube em formato .mp4;
                    var youtube = YouTube.Default;
                    var vid = youtube.GetVideo(urlVideo);
                    File.WriteAllBytesAsync($"{pastaDestino}{vid.FullName}", vid.GetBytes());

                    // Converter arquivo de .mp4 para .mp3;
                    var inputFile = new MediaFile { Filename = $"{pastaDestino}{vid.FullName}" };
                    var outputFile = new MediaFile { Filename = $"{pastaDestino}{nomeArquivoMp3}.mp3" };
                    using var engine = new Engine();
                    engine.GetMetadata(inputFile);
                    engine.Convert(inputFile, outputFile);

                    // Deletar arquivo .MP4 (inicial);
                    File.Delete($"{pastaDestino}{vid.FullName}");
                }
                catch (Exception ex)
                {
                    return false;
                }

                return true;
            });
        }

        // Converter Base64 para arquivo;
        public static IFormFile Base64ToFile(string base64)
        {
            List<IFormFile> formFiles = new();

            string split = ";base64,";
            string normalizarBase64 = base64.Substring(base64.IndexOf(split) + split.Length);
            byte[] bytes = Convert.FromBase64String(normalizarBase64);
            MemoryStream stream = new(bytes);

            IFormFile file = new FormFile(stream, 0, bytes.Length, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            formFiles.Add(file);

            return formFiles[0];
        }
    }
}
