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
                new Departamento { Id = 1, Nombre = "Departamento 1" },
                new Departamento { Id = 2, Nombre = "Departamento 2" },
                new Departamento { Id = 3, Nombre = "Departamento 3" },
            }
        );
    }

    public async Task<Departamento?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Departamento departamento)
    {
        throw new NotImplementedException();
    }
}
