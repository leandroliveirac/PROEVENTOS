using System;
using System.Collections.Generic;

namespace ProEventos.Domain.Entities
{
    public class Evento : Base
    {
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Lote> Lotes { get; set; } = new List<Lote>();
        public virtual IEnumerable<RedeSocial> RedesSocias { get; set; } = new List<RedeSocial>();
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}