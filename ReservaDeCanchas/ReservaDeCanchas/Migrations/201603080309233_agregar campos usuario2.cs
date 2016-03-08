namespace ReservaDeCanchas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregarcamposusuario2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Apellido", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "TipoDocumento", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.AspNetUsers", "NroDocumento", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.AspNetUsers", "superuser", c => c.Boolean(nullable: false));
            CreateIndex("dbo.AspNetUsers", new[] { "TipoDocumento", "NroDocumento" }, unique: true, name: "IX_DocumentoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", "IX_DocumentoId");
            DropColumn("dbo.AspNetUsers", "superuser");
            DropColumn("dbo.AspNetUsers", "NroDocumento");
            DropColumn("dbo.AspNetUsers", "TipoDocumento");
            DropColumn("dbo.AspNetUsers", "Apellido");
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
    }
}
