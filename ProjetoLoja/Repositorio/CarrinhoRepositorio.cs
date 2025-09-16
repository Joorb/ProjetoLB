using ProjetoLoja.Models;

namespace ProjetoLoja.Repositorio
{
    public class CarrinhoRepositorio
    {
        public int ProdutoId { get; set; }
        public ProdutoRepositorio Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public decimal Total => Quantidade * Preco;
    }
}
