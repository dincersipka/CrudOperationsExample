using COE.Persistence;
using COE.Application;
using COE.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

builder.Services.AddCors(c => c.AddDefaultPolicy(p => p.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors();

app.Run();
