using Domain;

namespace Application.Departamentos.Queries;

public interface IDepartamentoGetById
{
    Task<DepartamentoGetByIdDto?> Execute(int id);
}

public class DepartamentoGetById : IDepartamentoGetById
{
    private readonly IDepartamentoRepository _repositoryDepartamento;

    public DepartamentoGetById(IDepartamentoRepository repositoryDepartamento)
    {
        _repositoryDepartamento = repositoryDepartamento;
    }

    public async Task<DepartamentoGetByIdDto?> Execute(int id)
    {
        var departamento = await _repositoryDepartamento.GetByIdAsync(id);
        if (departamento == null)
        {
            return null;
        }
        return new DepartamentoGetByIdDto(departamento.Id, departamento.Nombre.Value);
    }
}

public record DepartamentoGetByIdDto(int Id, string Nombre);
