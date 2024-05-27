using LibraryApi.Services;
using LibraryApi.Controllers;
using LibraryApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//TODO: Selvitä mitä tekee
//TODO: Toinen service pitäis olla interface
builder.Services.AddScoped<IBooksService, BooksService>();

//TODO Korjaa oikea portti
//TODO Korjaa warningit
var app = builder.Build();

app.MapGet("/health-check", () => "ok");
app.MapControllers();
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
