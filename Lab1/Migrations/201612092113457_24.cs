namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountOperations",
                c => new
                    {
                        AccountOperationId = c.Int(nullable: false, identity: true),
                        OperationType = c.String(),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperationDate = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountOperationId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountOperations", "AccountId", "dbo.Accounts");
            DropIndex("dbo.AccountOperations", new[] { "AccountId" });
            DropTable("dbo.AccountOperations");
        }
    }
}
