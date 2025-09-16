using MySql.Data.MySqlClient;
using Dapper;
using ProjetoLoja.Models;

namespace ProjetoLoja.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly string _connectionString;

        public ProdutoRepositorio(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Produto>> TodosProdutos()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM Produtos";
            return await connection.QueryAsync<Produto>(sql);
        }
        public async Task<Produto?> ProdutosPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "select Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM produtos WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
        }
    }
}
