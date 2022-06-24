
using System;

namespace ProEventos.Domain.Entities
{
    public class Lote : Base
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }
    }
}