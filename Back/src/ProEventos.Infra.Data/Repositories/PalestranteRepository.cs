using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Infra.Data.Contexts;

namespace ProEventos.Infra.Data.Repositories
{
    public class PalestranteRepository : BaseRepository<ProEventosContext, Palestrante>, IPalestranteRepository
    {
        public PalestranteRepository(ProEventosContext context) : base(context)
        {
        }

        public async Task<Palestrante> ObterPalestrantePorId(int id, bool incluirEventos = false)
        {
            IQueryable<Palestrante> consulta = Consulta(incluirEventos);
            
            consulta = consulta.OrderBy(p => p.Id);

            return await consulta.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Palestrante>> ObterTodosPalestrantesAsync(bool incluirEventos = false)
        {
            IQueryable<Palestrante> consulta = Consulta(incluirEventos);
            
            consulta = consulta.OrderBy(p => p.Id);

            return await consulta.ToListAsync();
        }

        public async Task<IEnumerable<Palestrante>> ObterTodosPalestrantesPorNomeAsync(string nome, bool incluirEventos = false)
        {
            IQueryable<Palestrante> consulta = Consulta(incluirEventos);
            
            consulta = consulta.OrderBy(p => p.Id)
                                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await consulta.ToListAsync();
        }
        private IQueryable<Palestrante> Consulta(bool incluirEventos){

            IQueryable<Palestrante> consulta = _context.Palestrantes.AsNoTracking()
                                                .Include(p => p.RedesSocias);

            if(incluirEventos)
            {
                consulta = consulta.Include(p => p.PalestrantesEventos)
                                .ThenInclude(pe => pe.Evento);
            }
            return consulta;
        }
    }    
}