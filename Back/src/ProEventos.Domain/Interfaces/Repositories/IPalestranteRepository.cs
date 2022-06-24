using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Domain.Interfaces.Repositories
{
    public interface IPalestranteRepository : IBaseRepository<Palestrante>
    {
        Task<IEnumerable<Palestrante>> ObterTodosPalestrantesPorNomeAsync(string nome, bool incluirEventos = false);
        Task<IEnumerable<Palestrante>> ObterTodosPalestrantesAsync(bool incluirEventos = false);        
        Task<Palestrante> ObterPalestrantePorId(int id, bool incluirEventos = false);
    }
}