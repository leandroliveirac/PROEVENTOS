using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Interfaces.Services;
using ProEventos.Domain.Entities;
using ProEventos.Infra.Data.Contexts;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : Controller
    {
        private readonly IEventoServiceApp _eventoServiceApp;

        public EventoController(IEventoServiceApp eventoServiceApp)
        {
            _eventoServiceApp = eventoServiceApp;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public async Task<IActionResult> ObterTodos(){
            
            try
            {
                var eventos = await _eventoServiceApp.ObterTodosEventoAsync(true);

                if(eventos == null) return NotFound("Nenhum evento encontrado.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
            }            
        }

        [HttpGet]
        [Route("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId(int id){
            try
            {
                var evento = await _eventoServiceApp.ObterEventoPorId(id);

                if(evento == null) return NotFound("Evento por id não encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ObterPorTema/{tema}")]
        public async Task<IActionResult> ObterPorTema(string tema){
            try
            {
                var eventos = await _eventoServiceApp.ObterTodosEventoPorTemaAsync(tema);

                if(eventos == null) return NotFound("Eventos por tema não encontrados.");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar(Evento model){
            
            try
            {
                await _eventoServiceApp.Adicionar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id,Evento model){
            
            try
            {
                await _eventoServiceApp.Atualizar(id,model);

                return Ok();
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id,Evento model){
            
            try
            {
                await _eventoServiceApp.Excluir(id, model);

                return Ok();
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar adicionar evento. Erro: {ex.Message}");
            }
        }

    }
}