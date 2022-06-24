
namespace ProEventos.Domain.Entities
{
    public class RedeSocial : Base
    {
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public int? PalestranteId { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual Palestrante Palestrante { get; set; }
    }
}