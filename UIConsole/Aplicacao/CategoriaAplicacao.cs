using Dominio;
using Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao
{
    public class CategoriaAplicacao
    {
        public DbProduto Banco { get; set; }
        public CategoriaAplicacao()
        {
            Banco = new DbProduto();
        }

        public void Salvar(Categoria categoria)
        {
            Banco.Categorias.Add(categoria);
            Banco.SaveChanges();
        }

        public IEnumerable<Categoria> Listar()
        {
            return Banco.Categorias.ToList();
        }

        public void Alterar(Categoria categoria)
        {
            Categoria categoriaSalvar = Banco.Categorias.Where(x => x.Id == categoria.Id).First();
            categoriaSalvar.Descricao = categoria.Descricao;

            Banco.SaveChanges();
            
        }

        public void Excluir(int id)
        {
            Categoria categoriaExcluir = Banco.Categorias.Where(x => x.Id == id).First();
            Banco.Set<Categoria>().Remove(categoriaExcluir);

            Banco.SaveChanges();
        }
    }
}
