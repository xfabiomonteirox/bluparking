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
        public string Placa { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Entrada { get; set; }
        [DisplayName("Saída")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? Saida { get; set; }
        [DisplayName("Duração")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public string Duracao { get; set; }
        public int? Tempo { get; set; }
        [DisplayName("Valor a Pagar")]
        public double? ValorPagar { get; set; }
        public int? TabelaPrecoID { get; set; }
        
        [ForeignKey("TabelaPrecoID")]
        public virtual TabelaPreco TabelaPreco { get; set; }

        public virtual ICollection<TabelaPreco> TabelaPrecos { get; set; }

    }
}