var builder = WebApplication.CreateBuilder(args);

// Agrega servicios a la aplicaci�n
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
    });
}

// Configuraci�n adicional de middleware
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
