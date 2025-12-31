var builder = WebApplication.CreateBuilder(args);

// 🔥 REGISTRAR CONTROLLERS
builder.Services.AddControllers();

// 🔥 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

// 🔥 Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 🔥 MAPEAR CONTROLLERS
app.MapControllers();
app.MapControllers();

app.Run();
