using DashboardApp.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext yapýlandýrmasý
builder.Services.AddDbContext<DashboardDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS Yapýlandýrmasý (Tüm Originlere Ýzin Veriliyor)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin() // Herhangi bir kaynaktan gelen isteklere izin verir
               .AllowAnyHeader() // Header kýsýtlamasý yok
               .AllowAnyMethod(); // GET, POST, PUT, DELETE gibi her metoda izin verir
    });
});

// Diðer servis yapýlandýrmalarý
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS Middleware (Tüm originlere izin veren yapýlandýrmayý etkinleþtirir)
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
