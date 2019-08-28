using System.Collections.Generic;

namespace WearOutTCC_API.Models
{
    public class Vendedor : User
    {
        public List<Produto> Produtos { get; set; }
        public List<Fornecedor> Fornecedor { get; set; }

    }
}
