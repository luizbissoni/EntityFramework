using System.Collections.Generic;

namespace Dominio
{
    public class ListaProdutos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
