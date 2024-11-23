using Microsoft.EntityFrameworkCore;
using BlueAgenda.Data;
using BlueAgenda.services.BlueAgenda;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Adicione o Swagger


builder.Services.AddScoped<IAgendaInterface, AgendaService>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Configuração do Swagger
    app.UseSwaggerUI();     // Interface do Swagger UI
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
