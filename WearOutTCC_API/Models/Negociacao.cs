using System;

namespace WearOutTCC_API.Models
{
    public class Negociacao
    {
        public long Id { get; set; }
        public long QtdProduto { get; set; }
        public DateTime DtNegociacao { get; set; }
        public decimal ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public Produto Produto { get; set; }

        public Negociacao()
        {
            Cliente = new Cliente();
            Produto = new Produto();
            Vendedor = new Vendedor();
        }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
