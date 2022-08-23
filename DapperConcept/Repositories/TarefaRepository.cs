using Dapper;
using DapperConcept.Data;

namespace DapperConcept.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private DbSession _db;
        public TarefaRepository(DbSession dbSession)
        {
            _db = dbSession;
        }

        public async Task<List<Tarefa>> GetTarefasAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Tarefa";
                List<Tarefa> tarefas = (await conn.QueryAsync<Tarefa>(sql: query)).ToList();
                return tarefas;
            }
        }

        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Tarefa WHERE Id = @id";
                Tarefa tarefa = await conn.QueryFirstOrDefaultAsync<Tarefa>(sql: query, param: new { id });
                return tarefa;
            }
        }

        public async Task<TarefaContainer> GetTarefaEContadorAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = 
                    @"SELECT COUNT(*) FROM Tarefas
                    SELECT * FROM Tarefas";
                var reader = await conn.QueryMultipleAsync(sql: query);

                return new TarefaContainer
                {
                    Contador = (await reader.ReadAsync<int>()).FirstOrDefault(),
                    Tarefas = (await reader.ReadAsync<Tarefa>()).ToList()
                };
            }
        }

        public async Task<int> SaveAsync(Tarefa novaTarefa)
        {
            using (var conn = _db.Connection)
            {
                string command = @"INSERT INTO Tarefas(Descricao, IsCompleta) VALUES (@Descricao, @IsCompleta)";
                var result = await conn.ExecuteAsync(sql: command, param: novaTarefa);
                return result;
            }
        }

        public async Task<int> UpdateTarefaStatusAsync(Tarefa atualizaTarefa)
        {
            using (var conn = _db.Connection)
            {
                string command = @"UDPATE Tarefa SET IsCompleta = @IsCompleta WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: atualizaTarefa);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string command = @"DELETE FROM Tarefa WHERE Id = @id";
                var result = await conn.ExecuteAsync(sql: command, param: new { id });
                return result;
            }
        }
    }
}
