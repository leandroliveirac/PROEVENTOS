

using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Application.Interfaces.Services
{
    public interface IEventoServiceApp
    {
        Task Adicionar(Evento model);
        Task Atualizar(int id,Evento model);
        Task Excluir(int id,Evento model);

        Task<IEnumerable<Evento>> ObterTodosEventoPorTemaAsync(string tema, bool incluirPalestrantes = false);
        Task<IEnumerable<Evento>> ObterTodosEventoAsync(bool incluirPalestrantes = false);        
        Task<Evento> ObterEventoPorId(int id, bool incluirPalestrantes = false);
    }
}