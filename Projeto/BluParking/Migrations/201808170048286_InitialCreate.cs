namespace BluParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabelaPreco",
                c => new
                    {
                        TabelaPrecoID = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Preco = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TabelaPrecoID);
            
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        VagaID = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Entrada = c.DateTime(nullable: false),
                        Saida = c.DateTime(),
                        Duracao = c.Time(precision: 7),
                        Tempo = c.Int(),
                        ValorPagar = c.Double(),
                        TabelaPrecoID = c.Int(),
                    })
                .PrimaryKey(t => t.VagaID)
                .ForeignKey("dbo.TabelaPreco", t => t.TabelaPrecoID)
                .Index(t => t.TabelaPrecoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaga", "TabelaPrecoID", "dbo.TabelaPreco");
            DropIndex("dbo.Vaga", new[] { "TabelaPrecoID" });
            DropTable("dbo.Vaga");
            DropTable("dbo.TabelaPreco");
        }
    }
}
