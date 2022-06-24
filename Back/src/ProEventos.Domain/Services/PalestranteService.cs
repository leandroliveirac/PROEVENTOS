using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Interfaces.Services;

namespace ProEventos.Domain.Services
{
    public class PalestranteService : BaseService<Palestrante>, IPalestranteService
    {
        private readonly IPalestranteRepository _palestranteRepository;

        public PalestranteService(IPalestranteRepository palestranteRepository) : base(palestranteRepository)
        {
            _palestranteRepository = palestranteRepository;
        }

        public async Task<Palestrante> ObterPalestrantePorId(int id, bool incluirEventos = false)
        {
            return await _palestranteRepository.ObterPalestrantePorId(id, incluirEventos);
        }

        public async Task<IEnumerable<Palestrante>> ObterTodosPalestrantesAsync(bool incluirEventos = false)
        {
            return await _palestranteRepository.ObterTodosPalestrantesAsync(incluirEventos);
        }

        public async Task<IEnumerable<Palestrante>> ObterTodosPalestrantesPorNomeAsync(string nome, bool incluirEventos = false)
        {
            return await _palestranteRepository.ObterTodosPalestrantesPorNomeAsync(nome, incluirEventos);
        }
    }
}