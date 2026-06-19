using Application.Departamentos.Queries;
using Domain;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.AddServiceDefaults();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();
builder.Services.AddScoped<IDepartamentoGetById, DepartamentoGetById>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
    if (!dbContext.Departamentos.Any())
    {
        dbContext.Departamentos.AddRange(
            new Departamento { Nombre = new Nombre("Departamento 1") },
            new Departamento { Nombre = new Nombre("Departamento 2") },
            new Departamento { Nombre = new Nombre("Departamento 3") }
        );
        dbContext.SaveChanges();
    }
}
app.MapGet(
    "/departamentos/{id}",
    async (int id, IDepartamentoGetById departamentoGetById) =>
    {
        var departamento = await departamentoGetById.Execute(id);
        if (departamento == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(departamento);
    }
);
app.MapGet(
        "/departamentos",
        async (IDepartamentoGetAll departamentoGetAll) =>
        {
            var departamentos = await departamentoGetAll.Execute();
            return Results.Ok(departamentos);
        }
    )
    .WithName("GetDepartamentos");

app.UseHttpsRedirection();

app.Run();
