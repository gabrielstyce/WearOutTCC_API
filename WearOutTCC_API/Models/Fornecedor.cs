using System;
using System.Collections.Generic;

namespace WearOutTCC_API.Models
{
    public class Fornecedor : User
    {
        public long Phone { get; set; }
        public IList<Produto> Produtos { get; set; }
        public Vendedor Vendedor { get; set; }

    }
}
