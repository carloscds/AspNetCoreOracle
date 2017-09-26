namespace ExemploEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criar_pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.Pedido",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Data = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_Codigo = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SYSTEM.Cliente", t => t.Cliente_Codigo)
                .Index(t => t.Cliente_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SYSTEM.Pedido", "Cliente_Codigo", "SYSTEM.Cliente");
            DropIndex("SYSTEM.Pedido", new[] { "Cliente_Codigo" });
            DropTable("SYSTEM.Pedido");
        }
    }
}
