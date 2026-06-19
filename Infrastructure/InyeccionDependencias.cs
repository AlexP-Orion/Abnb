using Domain;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InyeccionDependencias
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        var connectionString = services
            .BuildServiceProvider()
            .GetRequiredService<IConfiguration>()
            .GetConnectionString("abnbdb");
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
    }
}
