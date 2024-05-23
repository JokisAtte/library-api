using LibraryApi.Services;
using LibraryApi.Controllers;
using LibraryApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<BooksService, BooksService>();

var app = builder.Build();

app.MapGet("/health-check", () => "ok");
app.MapControllers();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
