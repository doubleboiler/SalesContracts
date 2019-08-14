namespace SellContracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSaleMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AgentId = c.Int(),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.AgentId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Company = c.String(),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Sales", "AgentId", "dbo.Agents");
            DropIndex("dbo.Clients", new[] { "CityId" });
            DropIndex("dbo.Sales", new[] { "ClientId" });
            DropIndex("dbo.Sales", new[] { "AgentId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Clients");
            DropTable("dbo.Sales");
            DropTable("dbo.Agents");
        }
    }
}
