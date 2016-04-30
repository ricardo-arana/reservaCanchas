namespace DatosRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio_tipo_FechVen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampoSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Estado = c.String(),
                        Fecha_Creacion = c.DateTime(nullable: false),
                        Fecha_Mod = c.DateTime(nullable: false),
                        Tipo_campo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo_campoSet", t => t.Tipo_campo_Id)
                .Index(t => t.Tipo_campo_Id);
            
            CreateTable(
                "dbo.FotoSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        URL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReservaSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Estado = c.String(nullable: false),
                        CreadoPor = c.String(nullable: false),
                        FechaHoraAlquiler = c.DateTime(nullable: false),
                        MontoAlquiler = c.Decimal(nullable: false, precision: 18, scale: 0),
                        MontoPagado = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FechaHoraVencimiento = c.DateTime(nullable: false),
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                        Campo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UsuarioSet", t => t.Usuario_Id)
                .ForeignKey("dbo.CampoSet", t => t.Campo_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Campo_Id);
            
            CreateTable(
                "dbo.PagoSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoPago = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioSet",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Documento_Tipo_Documento = c.String(nullable: false, maxLength: 3),
                        Documento_Nro_Documento = c.String(nullable: false, maxLength: 12),
                        Datos_Adicionales = c.String(nullable: false),
                        Fecha_Registro = c.DateTime(nullable: false),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tipo_campoSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FotoCampo",
                c => new
                    {
                        Campo_Id = c.Int(nullable: false),
                        Foto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Campo_Id, t.Foto_Id })
                .ForeignKey("dbo.CampoSet", t => t.Campo_Id, cascadeDelete: true)
                .ForeignKey("dbo.FotoSet", t => t.Foto_Id, cascadeDelete: true)
                .Index(t => t.Campo_Id)
                .Index(t => t.Foto_Id);
            
            CreateTable(
                "dbo.PagoReserva",
                c => new
                    {
                        Pago_Id = c.Int(nullable: false),
                        Reserva_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pago_Id, t.Reserva_Id })
                .ForeignKey("dbo.PagoSet", t => t.Pago_Id, cascadeDelete: true)
                .ForeignKey("dbo.ReservaSet", t => t.Reserva_Id, cascadeDelete: true)
                .Index(t => t.Pago_Id)
                .Index(t => t.Reserva_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampoSet", "Tipo_campo_Id", "dbo.Tipo_campoSet");
            DropForeignKey("dbo.ReservaSet", "Campo_Id", "dbo.CampoSet");
            DropForeignKey("dbo.ReservaSet", "Usuario_Id", "dbo.UsuarioSet");
            DropForeignKey("dbo.PagoReserva", "Reserva_Id", "dbo.ReservaSet");
            DropForeignKey("dbo.PagoReserva", "Pago_Id", "dbo.PagoSet");
            DropForeignKey("dbo.FotoCampo", "Foto_Id", "dbo.FotoSet");
            DropForeignKey("dbo.FotoCampo", "Campo_Id", "dbo.CampoSet");
            DropIndex("dbo.PagoReserva", new[] { "Reserva_Id" });
            DropIndex("dbo.PagoReserva", new[] { "Pago_Id" });
            DropIndex("dbo.FotoCampo", new[] { "Foto_Id" });
            DropIndex("dbo.FotoCampo", new[] { "Campo_Id" });
            DropIndex("dbo.ReservaSet", new[] { "Campo_Id" });
            DropIndex("dbo.ReservaSet", new[] { "Usuario_Id" });
            DropIndex("dbo.CampoSet", new[] { "Tipo_campo_Id" });
            DropTable("dbo.PagoReserva");
            DropTable("dbo.FotoCampo");
            DropTable("dbo.Tipo_campoSet");
            DropTable("dbo.UsuarioSet");
            DropTable("dbo.PagoSet");
            DropTable("dbo.ReservaSet");
            DropTable("dbo.FotoSet");
            DropTable("dbo.CampoSet");
        }
    }
}
