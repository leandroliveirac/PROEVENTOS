using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Interfaces.Services;

namespace ProEventos.Domain.Services
{
    public class BaseService<T> : IBaseSevice<T>
    where T : Base
    {
        protected readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task Adicionar(T entidade)
        {
           await _baseRepository.Adicionar(entidade);
        }

        public virtual async Task Atualizar(T entidade)
        {
            await _baseRepository.Atualizar(entidade);
        }

        public virtual async Task Excluir(T entidade)
        {
           await _baseRepository.Excluir(entidade);
        }

        public virtual async Task Excluir(IEnumerable<T> entidades)
        {
            await _baseRepository.Excluir(entidades);
        }

        public virtual async Task<T> ObterPorId(int id)
        {
            return await _baseRepository.ObterPorId(id);
        }
    }
}