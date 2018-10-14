using Aplicacao;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListaDePodutoAplicacao appLista = new ListaDePodutoAplicacao();
            //ProdutoAplicacao appProduto = new ProdutoAplicacao();

            //var lista01 = appLista.Listar().LastOrDefault();
            //lista01.Descricao = "Cesta Basica de Rico";
            //lista01.Produtos = appProduto.Listar().ToList();

            //appLista.Excluir(lista01.Id);

            //var listas = appLista.Listar();

            //foreach (var lista in listas)
            //{
            //    Console.WriteLine("{0} - {1}", lista.Id, lista.Descricao);
            //    foreach (var produto in lista.Produtos)
            //    {
            //        Console.WriteLine("     {0} - {1}", produto.Id, produto.Nome);
            //    }
            //}

            //Console.ReadKey();

            var appCategoria = new CategoriaAplicacao();
            //var objCategoria = new Categoria
            //{
            //    Descricao = "Enlatados"
            //};

            //appCategoria.Salvar(objCategoria);

            //var listaDeCategorias = appCategoria.Listar();
            //foreach (var listaDecategoria in listaDeCategorias)
            //{
            //    Console.WriteLine("{0}", listaDecategoria.Descricao);
            //}

            //Console.ReadKey();




            //Produto

            var appProduto = new ProdutoAplicacao();

            //var objProduto = new Produto()
            //{
            //    Nome = "Sardinha",
            //    Categoria = appCategoria.Listar().FirstOrDefault()
            //};

            //appProduto.Salvar(objProduto);

            //var listaDeProdutos = appProduto.Listar();

            //foreach (var listaDeProduto in listaDeProdutos)
            //{
            //    Console.WriteLine("{0} - {1}", listaDeProduto.Nome, listaDeProduto.Categoria.Descricao);
            //}

            //Console.ReadKey();




            //Lista de Produtos

            var appLista = new ListaDePodutoAplicacao();
            var objListaDeProdutos = new ListaProdutos
            {
                Descricao = "Lista de comprasdo fulano"
            };

            var produto01 = appProduto.Listar().FirstOrDefault();

            objListaDeProdutos.Produtos = new List<Produto>
            {
                produto01
            };

            appLista.Salvar(objListaDeProdutos);

            var listas = appLista.Listar();
            foreach (var listaDeProduto in listas)
            {
                Console.WriteLine("{0}", listaDeProduto.Descricao);
                foreach (var produto in listaDeProduto.Produtos)
                {
                    Console.WriteLine("    {0} - {1}", produto.Nome, produto.Categoria.Descricao);
                }
            }
            Console.ReadKey();
        }
    }
}
