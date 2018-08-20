namespace BluParking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required_Placa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vaga", "Placa", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vaga", "Placa", c => c.String());
        }
    }
}
