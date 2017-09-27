namespace ExemploEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.CLIENTE",
                c => new
                    {
                        CLIENTEID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        NOME = c.String(),
                    })
                .PrimaryKey(t => t.CLIENTEID);
            
            CreateTable(
                "SYSTEM.PEDIDO",
                c => new
                    {
                        PEDIDOID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        DATA = c.DateTime(nullable: false),
                        VALOR = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CLIENTEID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.PEDIDOID)
                .ForeignKey("SYSTEM.CLIENTE", t => t.CLIENTEID, cascadeDelete: true)
                .Index(t => t.CLIENTEID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SYSTEM.PEDIDO", "CLIENTEID", "SYSTEM.CLIENTE");
            DropIndex("SYSTEM.PEDIDO", new[] { "CLIENTEID" });
            DropTable("SYSTEM.PEDIDO");
            DropTable("SYSTEM.CLIENTE");
        }
    }
}
