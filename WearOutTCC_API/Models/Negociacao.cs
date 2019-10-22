using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WearOutTCC_API.Models
{
    public class Negociacao
    {
        public long NegociacaoId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtNegociacao { get; set; }
        public decimal ValorTotal { get; set; }
        public long ClienteID { get; set; }
        public long VendedorID { get; set; }
        public string ProdutosID { get; set; }
    }
}
