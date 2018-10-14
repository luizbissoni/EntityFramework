using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Repositorio;
using Dominio;

namespace Aplicacao
{
    public class ListaDePodutoAplicacao
    {
        public DbProduto Banco { get; set; }

        public ListaDePodutoAplicacao()
        {
            Banco = new DbProduto();
        }

        public void Salvar(ListaProdutos listaDeProduto)
        {
            listaDeProduto.Produtos = listaDeProduto.Produtos.Select(produto => Banco.Produtos.FirstOrDefault(x=> x.Id == produto.Id)).ToList();
            Banco.ListaDeProdutos.Add(listaDeProduto);
            Banco.SaveChanges();
        }
        public IEnumerable<ListaProdutos> Listar() 
        {
            return Banco.ListaDeProdutos
                .Include(x => x.Produtos)
                .Include(x => x.Produtos.Select(c => c.Categoria))
                .ToList();
        }

        public void Alterar(ListaProdutos listaDeProduto)
        {
            ListaProdutos listaSalvar = Banco.ListaDeProdutos.Where(x=> x.Id == listaDeProduto.Id).First();
            listaSalvar.Produtos = listaDeProduto.Produtos.Select(produto => Banco.Produtos.FirstOrDefault(x => x.Id == produto.Id)).ToList();

            listaSalvar.Descricao = listaDeProduto.Descricao;
            Banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            ListaProdutos listaExcluir = Banco.ListaDeProdutos.Where(x => x.Id == id).First();
            listaExcluir.Produtos = null;
            Banco.Set<ListaProdutos>().Remove(listaExcluir);
            Banco.SaveChanges();

        }
    }
}
