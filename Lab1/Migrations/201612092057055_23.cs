namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientDepositCredits", "StartSum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientDepositCredits", "StartSum");
        }
    }
}
