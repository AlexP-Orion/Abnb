using Domain;

namespace Application.Departamentos.Queries;

public interface IDepartamentoGetAll
{
    Task<IList<DepartamentoGetAllDto>> Execute();
}

public class DepartamentoGetAll : IDepartamentoGetAll
{
    private readonly IDepartamentoRepository _repositoryDepartamento;

    public DepartamentoGetAll(IDepartamentoRepository repositoryDepartamento)
    {
        _repositoryDepartamento = repositoryDepartamento;
    }

    public async Task<IList<DepartamentoGetAllDto>> Execute()
    {
        var departamentos = await _repositoryDepartamento.GetAllAsync();
        return departamentos.Select(d => new DepartamentoGetAllDto(d.Id, d.Nombre.Value)).ToList();
    }
}

public record DepartamentoGetAllDto(int Id, string Nombre);
