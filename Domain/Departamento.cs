using System.ComponentModel.DataAnnotations.Schema;
using Domain.Comunes;

namespace Domain;

public class Departamento : Entidad
{
    public Nombre Nombre { get; set; } = new Nombre(string.Empty);

    // public Dinero Precio { get; set; } = new Dinero(0, Moneda.USD);
}

public record Nombre(string Value);

public record Dinero(decimal Value, Moneda Moneda);

public record Moneda
{
    public static Moneda USD = new Moneda("USD");
    public static Moneda EUR = new Moneda("EUR");
    public string Codigo { get; private init; }

    private Moneda(string codigo)
    {
        Codigo = codigo;
    }
}

public interface IDepartamentoRepository
{
    Task<List<Departamento>> GetAllAsync();
    Task<Departamento?> GetByIdAsync(int id);
    Task AddAsync(Departamento departamento);
    Task UpdateAsync(Departamento departamento);
    Task DeleteAsync(int id);
}
