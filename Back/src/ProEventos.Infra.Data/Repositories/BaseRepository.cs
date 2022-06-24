using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Domain.Interfaces.Repositories;

namespace ProEventos.Infra.Data.Repositories
{
    public class BaseRepository<TContext, T> : IBaseRepository<T>
     where TContext : DbContext
     where T : Base
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual async Task Adicionar(T entidade)
        {
            _context.Add(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Atualizar(T entidade)
        {
            _context.Update(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Excluir(T entidade)
        {
            _context.Remove(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Excluir(IEnumerable<T> entidades)
        {
            _context.RemoveRange(entidades);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> ObterPorId(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}