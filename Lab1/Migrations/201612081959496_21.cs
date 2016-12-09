namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Accounts", new[] { "ClientId" });
            AlterColumn("dbo.Accounts", "ClientId", c => c.Int());
            CreateIndex("dbo.Accounts", "ClientId");
            AddForeignKey("dbo.Accounts", "ClientId", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "ClientId", "dbo.Clients");
            DropIndex("dbo.Accounts", new[] { "ClientId" });
            AlterColumn("dbo.Accounts", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "ClientId");
            AddForeignKey("dbo.Accounts", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
