using System.Data.Entity;
using Dominio;

namespace Repositorio
{
    public class DbProduto : DbContext
    {
        public DbProduto():base("CadastroDeProdutos")
        {
                
        }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ListaProdutos> ListaDeProdutos { get; set; }
    }
}
