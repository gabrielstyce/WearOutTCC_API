using System;
using System.Collections.Generic;

namespace WearOutTCC_API.Models
{
    public class Fornecedor : User
    {
        public long Phone { get; set; }
        public string ProdutosID { get; set; }
        public long VendedorID { get; set; }

        public Fornecedor()
        {

        }

    }
}
