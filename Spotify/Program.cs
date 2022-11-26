using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Spotify.API;
using Spotify.API.Data;
using Spotify.API.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
{
    // T�cnica para adicionar o conte�do de "infra" em uma classe centralizada: https://youtu.be/fhM0V2N1GpY?t=2149
    builder.Services.AddDependencyInjection(builder);

    // Filtro de erros;
    builder.Services.AddControllers(o => o.Filters.Add<ErrorHandlingFilterAttribute>());

    // Habilitar API por IP em vez de apenas localhost: https://stackoverflow.com/questions/69532898/asp-net-core-6-0-kestrel-server-is-not-working;
    if (builder.Environment.IsDevelopment())
    {
        builder.WebHost.ConfigureKestrel(options =>
        {
            // Exemplo: https://192.168.8.211:7225/api/Musicas/todos, https://192.168.8.214:7225/api/Musicas/todos 
            options.ListenAnyIP(7225, c => c.UseHttps());
            options.ListenAnyIP(7226);
        });
    }

    // Inserir as informa��es do banco na vari�vel builder antes de build�-la;
    var secretSenhaBancoDados = builder.Configuration["SecretSenhaBancoDados"]; // secrets.json;
    string con = builder.Configuration.GetConnectionString("BaseDadosSpotify") ?? "";
    con = con.Replace("[secretSenhaBancoDados]", secretSenhaBancoDados); // Alterar pela senha do secrets.json;
    builder.Services.AddDbContext<Context>(options => options.UseMySql(con, ServerVersion.AutoDetect(con)));

    // Swagger;
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Spotify", Version = "v1" });

        // https://stackoverflow.com/questions/43447688/setting-up-swagger-asp-net-core-using-the-authorization-headers-bearer
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
            Scheme = "bearer",
            BearerFormat = "JWT",
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Description = "Coloque **_apenas_** o token (JWT Bearer) abaixo!",

            Reference = new OpenApiReference
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        { jwtSecurityScheme, Array.Empty<string>() }
        });
    });

    // Cors;
    builder.Services.AddCors(options =>
        options.AddPolicy(name: builder.Configuration["CORSSettings:Cors"] ?? "", builder =>
        {
            builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials();
        })
    );

    // Adicionar comando "AddNewtonsoftJson" para ignorar "erros" de object cycle - https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported;
    // E tamb�m formatar o resultado JSON retornado pelas APIs;
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    });
}

var app = builder.Build();
{
    // Iniciar banco;
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<Context>();

            // Iniciar o banco de dados, indo para o DbInitializer.cs;
            await DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            string erroBD = ex.Message.ToString();
        }
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spotify v1");
            c.DocExpansion(DocExpansion.None); // https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/279
        });

        app.UseDeveloperExceptionPage();
    }

    // Redirecionar sempre para HTTPS;
    if (app.Environment.IsProduction())
    {
        app.UseHttpsRedirection();
    }

    // Cors;
    app.UseCors(builder.Configuration["CORSSettings:Cors"] ?? "");

    // Outros;
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    // Habilitar static files para exibir as imagens da API: https://youtu.be/jSO5KJLd5Qk?t=86;
    IWebHostEnvironment env = app.Environment;
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Upload")),
        RequestPath = "/Upload",

        // CORS: https://stackoverflow.com/questions/61152499/dotnet-core-3-1-cors-issue-when-serving-static-image-files;
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
        }
    });

    app.Run();
}

// Deixar o Program.cs public para o xUnit;
public partial class Program { }