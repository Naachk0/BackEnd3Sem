using ConnectPlus.BdContextEvent;
using ConnectPlus.Interface;
using ConnectPlus.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
{
    Version = "v1",
    Title = "Api de eventos",
    TermsOfService = new Uri("https://pin.it/5TPkMLpzC"),
    Contact = new OpenApiContact
    {
        Name = "May",
        Url = new Uri("https://www.linkedin.com/in/mayra-ap-pacheco-vachiani-88264837a?originalSubdomain=br")
    },
    License = new OpenApiLicense
    {
        Name = "lICENSA DE EXEMPLO",
        Url = new Uri("htttps://example/com/license")
    }
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
