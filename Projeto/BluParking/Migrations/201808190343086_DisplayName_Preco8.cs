namespace BluParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisplayName_Preco8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaga", "Duracao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaga", "Duracao", c => c.Time(precision: 7));
        }
    }
}
