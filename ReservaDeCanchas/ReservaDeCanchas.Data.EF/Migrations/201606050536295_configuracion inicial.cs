namespace ReservaDeCanchas.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configuracioninicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampoSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Estado = c.String(),
                        Fecha_Creacion = c.DateTime(nullable: false),
                        Fecha_Mod = c.DateTime(nullable: false),
                        Tipo_campo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tipo_campoSet", t => t.Tipo_campo_Id)
                .Index(t => t.Tipo_campo_Id);
            
            CreateTable(
                "dbo.FotoSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        URL = c.String(),
                        Campo_Id = c.Int(nullable: false),
                        CampoSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CampoSets", t => t.CampoSet_Id)
                .Index(t => t.CampoSet_Id);
            
            CreateTable(
                "dbo.ReservaSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Estado = c.String(),
                        CreadoPor = c.String(),
                        FechaHoraAlquiler = c.DateTime(nullable: false),
                        MontoAlquiler = c.Decimal(nullable: false, precision: 18, scale: 0),
                        MontoPagado = c.Decimal(nullable: false, precision: 18, scale: 0),
                        FechaHoraVencimiento = c.DateTime(nullable: false),
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                        Campo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UsuarioSets", t => t.Usuario_Id)
                .ForeignKey("dbo.CampoSets", t => t.Campo_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Campo_Id);
            
            CreateTable(
                "dbo.PagoSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoPago = c.String(),
                        Descripcion = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioSets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Documento_Tipo_Documento = c.String(),
                        Documento_Nro_Documento = c.String(),
                        Datos_Adicionales = c.String(),
                        Fecha_Registro = c.DateTime(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tipo_campoSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PagoReserva",
                c => new
                    {
                        Pago_Id = c.Int(nullable: false),
                        Reserva_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pago_Id, t.Reserva_Id })
                .ForeignKey("dbo.PagoSets", t => t.Pago_Id, cascadeDelete: true)
                .ForeignKey("dbo.ReservaSets", t => t.Reserva_Id, cascadeDelete: true)
                .Index(t => t.Pago_Id)
                .Index(t => t.Reserva_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampoSets", "Tipo_campo_Id", "dbo.Tipo_campoSet");
            DropForeignKey("dbo.ReservaSets", "Campo_Id", "dbo.CampoSets");
            DropForeignKey("dbo.ReservaSets", "Usuario_Id", "dbo.UsuarioSets");
            DropForeignKey("dbo.PagoReserva", "Reserva_Id", "dbo.ReservaSets");
            DropForeignKey("dbo.PagoReserva", "Pago_Id", "dbo.PagoSets");
            DropForeignKey("dbo.FotoSets", "CampoSet_Id", "dbo.CampoSets");
            DropIndex("dbo.PagoReserva", new[] { "Reserva_Id" });
            DropIndex("dbo.PagoReserva", new[] { "Pago_Id" });
            DropIndex("dbo.ReservaSets", new[] { "Campo_Id" });
            DropIndex("dbo.ReservaSets", new[] { "Usuario_Id" });
            DropIndex("dbo.FotoSets", new[] { "CampoSet_Id" });
            DropIndex("dbo.CampoSets", new[] { "Tipo_campo_Id" });
            DropTable("dbo.PagoReserva");
            DropTable("dbo.Tipo_campoSet");
            DropTable("dbo.UsuarioSets");
            DropTable("dbo.PagoSets");
            DropTable("dbo.ReservaSets");
            DropTable("dbo.FotoSets");
            DropTable("dbo.CampoSets");
        }
    }
}
