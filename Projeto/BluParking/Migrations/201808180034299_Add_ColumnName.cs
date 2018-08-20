namespace BluParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ColumnName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TabelaPreco", name: "DataInicio", newName: "Data Início");
            RenameColumn(table: "dbo.TabelaPreco", name: "DataFim", newName: "Data Fim");
            RenameColumn(table: "dbo.TabelaPreco", name: "Preco", newName: "Preço");
            RenameColumn(table: "dbo.Vaga", name: "Duracao", newName: "Duração");
            RenameColumn(table: "dbo.Vaga", name: "ValorPagar", newName: "Valor a Pagar");
            RenameColumn(table: "dbo.Vaga", name: "TabelaPrecoID", newName: "Preço");
            RenameIndex(table: "dbo.Vaga", name: "IX_TabelaPrecoID", newName: "IX_Preço");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vaga", name: "IX_Preço", newName: "IX_TabelaPrecoID");
            RenameColumn(table: "dbo.Vaga", name: "Preço", newName: "TabelaPrecoID");
            RenameColumn(table: "dbo.Vaga", name: "Valor a Pagar", newName: "ValorPagar");
            RenameColumn(table: "dbo.Vaga", name: "Duração", newName: "Duracao");
            RenameColumn(table: "dbo.TabelaPreco", name: "Preço", newName: "Preco");
            RenameColumn(table: "dbo.TabelaPreco", name: "Data Fim", newName: "DataFim");
            RenameColumn(table: "dbo.TabelaPreco", name: "Data Início", newName: "DataInicio");
        }
    }
}
