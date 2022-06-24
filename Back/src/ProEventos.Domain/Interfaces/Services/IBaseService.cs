using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEventos.Domain.Interfaces.Services
{
    public interface IBaseSevice<T> where T : class
    {
        Task<T> ObterPorId(int id);
        Task Adicionar(T entidade);
        Task Atualizar(T entidade);
        Task Excluir(T entidade);
        Task Excluir(IEnumerable<T> entidades);   
    }
}