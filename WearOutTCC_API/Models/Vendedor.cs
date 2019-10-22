using System.Collections.Generic;

namespace WearOutTCC_API.Models
{
    public class Vendedor : User
    {
        public string ProdutosID { get; set; }
        public string FornecedoresID { get; set; }

        public Vendedor()
        {

        }

    }
}
