using System;

namespace WearOutTCC_API.Models
{
    public class Produto
    {
        public long ProdutoId { get; set; }
        public long Codigo { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public long QtdProduto { get; set; }
        public long IdEstoque { get; set; }
        public string NomeEstoque { get; set; }
        public long QtdFornecida { get; set; }
        public DateTime DtFornecida { get; set; }
        public long VendedorID { get; set; }
        public long FornecedorID { get; set; }

    }
}
