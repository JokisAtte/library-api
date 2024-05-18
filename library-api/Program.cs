using LibraryApi.Services;
using LibraryApi.Controllers;
using LibraryApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<BooksService, BooksService>();

var app = builder.Build();

app.MapGet("/health-check", () => "ok");
app.MapControllers();
app.UseRouting(); // Add this line to enable routing
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.Run();
