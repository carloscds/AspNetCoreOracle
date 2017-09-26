namespace ExemploEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.Cliente",
                c => new
                    {
                        Codigo = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("SYSTEM.Cliente");
        }
    }
}
