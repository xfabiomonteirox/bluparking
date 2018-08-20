namespace BluParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisplayName_Preco9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaga", "Duracao", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaga", "Duracao", c => c.DateTime());
        }
    }
}
