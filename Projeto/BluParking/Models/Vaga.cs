using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluParking.Models
{
    public class Vaga
    {
        public int VagaID { get; set; }
        [Required]
        [Column(Order = 1)]
        public string Placa { get; set; }
        [Column(Order = 2)]
        public DateTime Entrada { get; set; }
        [Column(Order = 3)]
        [DisplayName("Saída")]
        public DateTime? Saida { get; set; }
        [Column(Order = 4)]
        [DisplayName("Duração")]
        public string Duracao { get; set; }
        [Column(Order = 5)]
        public int? Tempo { get; set; }
        [Column(Order = 7)]
        [DisplayName("Valor a Pagar")]
        public double? ValorPagar { get; set; }
        [Column(Order = 6)]
        public int? TabelaPrecoID { get; set; }
        
        [ForeignKey("TabelaPrecoID")]
        public virtual TabelaPreco TabelaPreco { get; set; }

        public virtual ICollection<TabelaPreco> TabelaPrecos { get; set; }

    }
}