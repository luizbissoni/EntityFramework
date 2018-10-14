namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListaProdutos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Categoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.Categoria_Id)
                .Index(t => t.Categoria_Id);
            
            CreateTable(
                "dbo.ProdutoListaProdutos",
                c => new
                    {
                        Produto_Id = c.Int(nullable: false),
                        ListaProdutos_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_Id, t.ListaProdutos_Id })
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.ListaProdutos", t => t.ListaProdutos_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.ListaProdutos_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoListaProdutos", "ListaProdutos_Id", "dbo.ListaProdutos");
            DropForeignKey("dbo.ProdutoListaProdutos", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.ProdutoListaProdutos", new[] { "ListaProdutos_Id" });
            DropIndex("dbo.ProdutoListaProdutos", new[] { "Produto_Id" });
            DropIndex("dbo.Produtoes", new[] { "Categoria_Id" });
            DropTable("dbo.ProdutoListaProdutos");
            DropTable("dbo.Produtoes");
            DropTable("dbo.ListaProdutos");
            DropTable("dbo.Categorias");
        }
    }
}
