using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Infra.Data.Contexts;

namespace ProEventos.Infra.Data.Repositories
{
    public class EventoRepository : BaseRepository<ProEventosContext, Evento>, IEventoRepository
    {
        public EventoRepository(ProEventosContext context) : base(context)
        {
        }

        public async Task<Evento> ObterEventoPorId(int id, bool incluirPalestrantes = false)
        {
            IQueryable<Evento> consulta = Consulta(incluirPalestrantes);
            
            consulta = consulta.OrderBy( e=> e.Id);

            return await consulta.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Evento>> ObterTodosEventoAsync(bool incluirPalestrantes = false)
        {
            IQueryable<Evento> consulta = Consulta(incluirPalestrantes);
            
            consulta = consulta.OrderBy( e=> e.Id);

            return await consulta.ToListAsync();
        }

        public async Task<IEnumerable<Evento>> ObterTodosEventoPorTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            IQueryable<Evento> consulta = Consulta(incluirPalestrantes);
            
            consulta = consulta.OrderBy( e=> e.Id)
                                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await consulta.ToListAsync();            
        }

        private IQueryable<Evento> Consulta(bool incluirPalestrantes){

            IQueryable<Evento> consulta = _context.Eventos.AsNoTracking()
                                                .Include(e => e.Lotes)
                                                .Include(e => e.RedesSocias);

            if(incluirPalestrantes)
            {
                consulta = consulta.Include( e => e.PalestrantesEventos)
                                .ThenInclude(pe => pe.Palestrante);
            }
            return consulta;
        }
    }
}