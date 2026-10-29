using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var key = builder.Configuration [ "Jwt:Key" ]
    ?? throw new Exception("Не задан секретный ключ jwt");

if (Encoding.UTF8.GetByteCount(key) < 32)
    throw new Exception("Ключ JWT слишком короткий");


builder.Services.AddControllers( );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer( );
builder.Services.AddSwaggerGen( );

var app = builder.Build( );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment( ))
{
    app.UseSwagger( );
    app.UseSwaggerUI( );
}

app.UseHttpsRedirection( );

app.UseAuthorization( );

app.MapControllers( );

app.Run( );
