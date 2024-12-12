using DashboardApp.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext yap�land�rmas�
builder.Services.AddDbContext<DashboardDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS Yap�land�rmas� (T�m Originlere �zin Veriliyor)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin() // Herhangi bir kaynaktan gelen isteklere izin verir
               .AllowAnyHeader() // Header k�s�tlamas� yok
               .AllowAnyMethod(); // GET, POST, PUT, DELETE gibi her metoda izin verir
    });
});

// Di�er servis yap�land�rmalar�
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

// CORS Middleware (T�m originlere izin veren yap�land�rmay� etkinle�tirir)
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
