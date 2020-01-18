namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        clientId = c.Int(nullable: false),
                        descriere = c.String(),
                    })
                .PrimaryKey(t => t.clientId)
                .ForeignKey("dbo.Vanzares", t => t.clientId)
                .Index(t => t.clientId);
            
            CreateTable(
                "dbo.Vanzares",
                c => new
                    {
                        vanzareId = c.Int(nullable: false, identity: true),
                        produsId = c.Int(nullable: false),
                        locatieId = c.Int(nullable: false),
                        dataId = c.Int(nullable: false),
                        clientId = c.Int(nullable: false),
                        pret = c.Int(nullable: false),
                        cantitate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.vanzareId);
            
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        dataId = c.Int(nullable: false),
                        descriere = c.String(),
                    })
                .PrimaryKey(t => t.dataId)
                .ForeignKey("dbo.Vanzares", t => t.dataId)
                .Index(t => t.dataId);
            
            CreateTable(
                "dbo.Locaties",
                c => new
                    {
                        locatieId = c.Int(nullable: false),
                        descriere = c.String(),
                    })
                .PrimaryKey(t => t.locatieId)
                .ForeignKey("dbo.Vanzares", t => t.locatieId)
                .Index(t => t.locatieId);
            
            CreateTable(
                "dbo.Produs",
                c => new
                    {
                        produsId = c.Int(nullable: false),
                        descriere = c.String(),
                    })
                .PrimaryKey(t => t.produsId)
                .ForeignKey("dbo.Vanzares", t => t.produsId)
                .Index(t => t.produsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "clientId", "dbo.Vanzares");
            DropForeignKey("dbo.Produs", "produsId", "dbo.Vanzares");
            DropForeignKey("dbo.Locaties", "locatieId", "dbo.Vanzares");
            DropForeignKey("dbo.Data", "dataId", "dbo.Vanzares");
            DropIndex("dbo.Produs", new[] { "produsId" });
            DropIndex("dbo.Locaties", new[] { "locatieId" });
            DropIndex("dbo.Data", new[] { "dataId" });
            DropIndex("dbo.Clients", new[] { "clientId" });
            DropTable("dbo.Produs");
            DropTable("dbo.Locaties");
            DropTable("dbo.Data");
            DropTable("dbo.Vanzares");
            DropTable("dbo.Clients");
        }
    }
}
