namespace BluParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_HoraAdicional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TabelaPreco", "PrecoHoraAdicional", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TabelaPreco", "PrecoHoraAdicional");
        }
    }
}
