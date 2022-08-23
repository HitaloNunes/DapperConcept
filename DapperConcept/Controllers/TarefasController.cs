using DapperConcept.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperConcept.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepo;
        public TarefasController(ITarefaRepository tarefaRepo)
        {
            _tarefaRepo = tarefaRepo;
        }
    }
}
