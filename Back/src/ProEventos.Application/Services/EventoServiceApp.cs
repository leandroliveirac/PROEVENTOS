
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces.Services;
using ProEventos.Domain.Entities;
using ProEventos.Domain.Interfaces.Services;

namespace ProEventos.Application.Services
{
    public class EventoServiceApp : IEventoServiceApp
    {
        private readonly IEventoService _eventoService;

        public EventoServiceApp(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        public async Task Adicionar(Evento model)
        {
            try
            {
                await _eventoService.Adicionar(model);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
            
        }

        public async Task Atualizar(int id,Evento model)
        {
            try
            {
                var evento = _eventoService.ObterPorId(id);
                
                if(evento == null) throw new Exception("Evento não encontrado na base de dados.");

                model.Id = evento.Id;

                await _eventoService.Atualizar(model);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task Excluir(int id,Evento model)
        {
            try
            {
                var evento = _eventoService.ObterPorId(id);
                
                if(evento == null) throw new Exception("Evento não encontrado na base de dados.");

                model.Id = evento.Id;

                await _eventoService.Excluir(model);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public Task<Evento> ObterEventoPorId(int id, bool incluirPalestrantes = false)
        {
            try
            {
                return _eventoService.ObterEventoPorId(id,incluirPalestrantes);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Evento>> ObterTodosEventoAsync(bool incluirPalestrantes = false)
        {
            try
            {
                return _eventoService.ObterTodosEventoAsync(incluirPalestrantes);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Evento>> ObterTodosEventoPorTemaAsync(string tema, bool incluirPalestrantes = false)
        {
            try
            {
                return _eventoService.ObterTodosEventoPorTemaAsync(tema,incluirPalestrantes);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}