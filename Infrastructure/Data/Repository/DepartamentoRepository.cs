using Domain;

namespace Infrastructure.Data.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    public Task AddAsync(Departamento departamento)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Departamento>> GetAllAsync()
    {
        return await Task.FromResult(
            new List<Departamento>
            {
                new() { Id = 1, Nombre = "Recursos Humanos" },
                new() { Id = 2, Nombre = "Finanzas" },
                new() { Id = 3, Nombre = "Tecnología" },
            }
        );
    }

    public Task<Departamento?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Departamento departamento)
    {
        throw new NotImplementedException();
    }
}
