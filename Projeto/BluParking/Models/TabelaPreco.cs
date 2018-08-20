using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluParking.Models
{
    public class TabelaPreco
    {
        [DisplayName("Preço")]
        public int TabelaPrecoID { get; set; }
        [DisplayName("Data Início")]
        public DateTime DataInicio { get; set; }
        [DisplayName("Data Fim")]
        public DateTime DataFim { get; set; }
        [DisplayName("Preço Hora")]
        public double Preco { get; set; }
        [DisplayName("Preço Hora Adicional")]
        public double PrecoHoraAdicional { get; set; }
    }
}