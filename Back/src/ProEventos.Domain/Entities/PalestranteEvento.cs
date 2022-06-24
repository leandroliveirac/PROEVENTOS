

namespace ProEventos.Domain.Entities
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual Palestrante Palestrante { get; set; }
    }
}