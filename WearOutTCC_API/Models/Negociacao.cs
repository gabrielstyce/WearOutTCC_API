using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WearOutTCC_API.Models
{
    public class Negociacao
    {
        [Key]
        public long Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtNegociacao { get; set; }
        public decimal ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }

        
    }
}
