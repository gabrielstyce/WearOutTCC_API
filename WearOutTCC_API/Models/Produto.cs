using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WearOutTCC_API.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public long Codigo { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public long QtdProduto { get; set; }
        public long IdEstoque { get; set; }
        public string NomeEstoque { get; set; }

        public Vendedor Vendedor { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Produto()
        {
            Vendedor = new Vendedor();
            Fornecedor = new Fornecedor();
        }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
