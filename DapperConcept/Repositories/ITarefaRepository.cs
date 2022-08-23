using DapperConcept.Data;

namespace DapperConcept.Repositories
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> GetTarefasAsync();
        Task<Tarefa> GetTarefaByIdAsync(int id);
        Task<TarefaContainer> GetTarefaEContadorAsync();
        Task<int> SaveAsync(Tarefa novaTarefa);
        Task<int> UpdateTarefaStatusAsync(Tarefa atualizaTarefa);
        Task<int> DeleteAsync(int id);
    }
}
