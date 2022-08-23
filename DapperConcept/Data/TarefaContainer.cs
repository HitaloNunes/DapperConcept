namespace DapperConcept.Data
{
    public class TarefaContainer
    {
        public int Contador { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}
