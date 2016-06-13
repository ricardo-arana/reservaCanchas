namespace ReservaDeCanchas.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fotopordefecto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FotoSets", "Principal", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FotoSets", "Principal");
        }
    }
}
