namespace ReservaDeCanchas.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadodepago : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PagoSets", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PagoSets", "Estado");
        }
    }
}
