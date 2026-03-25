using EventPlus.WebAPI.BdContextEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using EventPlus.WebAPI.Interface;
using System.Reflection.Metadata;
using EventPlus.WebAPI.Repositories;
using Azure.AI.ContentSafety;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();

builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();

builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();

builder.Services.AddScoped<IEventoRepository, EventoRepository> ();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IComentarioEventoRepository, ComentarioRepository>();

builder.Services.AddScoped<IPresencaRepository, PresencaRepository>();



//var client = new ContentSafetyClient(new Uri(endpoint), new Azure.AzureKeyCredential(apiKey));
//builder.Services.AddSingleton(client);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "Api de eventos",
        TermsOfService = new Uri("https://open.spotify.com/intl-pt/track/2VKGO4DNyUK5UxCQB3b3DF?si=c86684e639fc41a9"),
        Contact = new OpenApiContact
        {
            Name = "Mayra Ap",
            Url = new Uri ("https://www.linkedin.com/in/mayra-ap-pacheco-vachiani-88264837a?originalSubdomain=br")
        },
        License = new OpenApiLicense
        {
            Name = "lICENSA DE EXEMPLO",
            Url = new Uri("htttps://example/com/license")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    { 
    
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira Token JWT: "
 
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList()
    });

});


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger(options => { });
    app.UseSwaggerUI(options => {

        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
