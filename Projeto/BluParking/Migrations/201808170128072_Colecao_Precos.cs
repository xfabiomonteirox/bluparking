namespace BluParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Colecao_Precos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TabelaPreco", "Vaga_VagaID", c => c.Int());
            CreateIndex("dbo.TabelaPreco", "Vaga_VagaID");
            AddForeignKey("dbo.TabelaPreco", "Vaga_VagaID", "dbo.Vaga", "VagaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TabelaPreco", "Vaga_VagaID", "dbo.Vaga");
            DropIndex("dbo.TabelaPreco", new[] { "Vaga_VagaID" });
            DropColumn("dbo.TabelaPreco", "Vaga_VagaID");
        }
    }
}
