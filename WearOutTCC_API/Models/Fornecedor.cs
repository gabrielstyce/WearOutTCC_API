using System;

namespace WearOutTCC_API.Models
{
    public class Fornecedor : User
    {
        public long Phone { get; set; }
        public Produto Produto { get; set; }
        public DateTime DtFornecida { get; set; }
        public long QtdFornecida { get; set; }

        public Fornecedor()
        {
            Produto = new Produto();
        }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
