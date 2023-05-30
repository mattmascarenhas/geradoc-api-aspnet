using Geradoc.Domain.Handlers;
using Geradoc.Domain.Interfaces;
using Geradoc.Infra;
using Geradoc.Infra.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //usar rotas em controllers
//builder.Services.AddResponseCompression(); //comprimir as requisições
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<GeradocData, GeradocData>();
builder.Services.AddTransient<IClienteRespositorio, ClienteRepositorio>();
builder.Services.AddTransient<ClienteHandler, ClienteHandler>();


var app = builder.Build();

app.UseRouting();


//utilizando rotas do controller
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

//usando a compressao das req
//app.UseResponseCompression();

app.Run();
