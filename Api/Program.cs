using Application.Departamentos.Queries;
using Infrastructure;
using Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

app.MapGet(
    "/departamentos",
    async (IDepartamentoGetAll departamentoGetAll) =>
    {
        var departamentos = await departamentoGetAll.Execute();
        return Results.Ok(departamentos);
    }
);

app.UseHttpsRedirection();

app.Run();
