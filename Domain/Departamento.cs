using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Departamento
{
    public int Id { get; set; }
    public Nombre Nombre { get; set; } = new Nombre(string.Empty);
}

[NotMapped]
public record Nombre(string Value);

public interface IDepartamentoRepository
{
    Task<List<Departamento>> GetAllAsync();
    Task<Departamento?> GetByIdAsync(int id);
    Task AddAsync(Departamento departamento);
    Task UpdateAsync(Departamento departamento);
    Task DeleteAsync(int id);
}
