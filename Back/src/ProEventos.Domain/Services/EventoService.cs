using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Interfaces.Services;

namespace ProEventos.Domain.Services
{
    public class EventoService : BaseService<Evento>, IEventoService
    {        
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository) : base(eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> ObterEventoPorId(int id, bool incluirPalestrantes = false)
        {
            return await _eventoRepository.ObterEventoPorId(id,incluirPalestrantes);
        }

        public async Task<IEnumerable<Evento>> ObterTodosEventoAsync(bool incluirPalestrantes = false)
        {
            return await _eventoRepository.ObterTodosEventoAsync(incluirPalestrantes);
        }

        public async Task<IEnumerable<Evento>> ObterTodosEventoPorTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            return await _eventoRepository.ObterTodosEventoPorTemaAsync(tema,incluirPalestrantes);
        }
    }
}