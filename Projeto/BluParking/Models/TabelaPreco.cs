using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BluParking.Models
{
    public class TabelaPreco
    {
        [DisplayName("Preço")]
        public int TabelaPrecoID { get; set; }
        [DisplayName("Data Início")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        [DisplayName("Data Fim")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }
        [DisplayName("Preço Hora")]
        public double Preco { get; set; }
        [DisplayName("Preço Hora Adicional")]
        public double PrecoHoraAdicional { get; set; }
    }
}