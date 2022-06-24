
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Domain.Interfaces.Repositories
{
    public interface IEventoRepository : IBaseRepository<Evento>
    {
        Task<IEnumerable<Evento>> ObterTodosEventoPorTemaAsync(string tema, bool incluirPalestrantes = false);
        Task<IEnumerable<Evento>> ObterTodosEventoAsync(bool incluirPalestrantes = false);        
        Task<Evento> ObterEventoPorId(int id, bool incluirPalestrantes = false);
    }
}