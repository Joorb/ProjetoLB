using ProjetoLoja.Repositorio;

namespace ProjetoLoja.Models
{
    public class ItemCarrinho
    {
        public int ProdutoId { get; set; }
        public ProdutoRepositorio Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public decimal Total => Quantidade * Preco;
    }
}
