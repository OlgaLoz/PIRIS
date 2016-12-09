namespace Lab1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountCodes",
                c => new
                    {
                        AccountCodeId = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountCodeId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        AccountCodeId = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        AccountActivity = c.Byte(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.AccountCodes", t => t.AccountCodeId, cascadeDelete: true)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.AccountCodeId)
                .Index(t => t.CurrencyId)
                .Index(t => t.AccountTypeId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        AccountTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MidName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        PassportNumber = c.String(nullable: false),
                        PassportIssuedBy = c.String(nullable: false),
                        PassportIssueDate = c.DateTime(nullable: false),
                        PassrortIdNumber = c.String(nullable: false),
                        BirthPlace = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        HomePhone = c.String(),
                        MobilePhone = c.String(),
                        Mail = c.String(),
                        WorkPlace = c.String(),
                        WorkPosition = c.String(),
                        RegistrationAddress = c.String(nullable: false),
                        Pensioner = c.Boolean(nullable: false),
                        MounthIncome = c.Decimal(precision: 18, scale: 2),
                        FamilyStatusId = c.Int(nullable: false),
                        NationalityId = c.Int(nullable: false),
                        DisabilityId = c.Int(nullable: false),
                        TownId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disabilities", t => t.DisabilityId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyStatus", t => t.FamilyStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId, cascadeDelete: true)
                .ForeignKey("dbo.Towns", t => t.TownId, cascadeDelete: true)
                .Index(t => t.FamilyStatusId)
                .Index(t => t.NationalityId)
                .Index(t => t.DisabilityId)
                .Index(t => t.TownId);
            
            CreateTable(
                "dbo.ClientDepositCredits",
                c => new
                    {
                        ClientDepositCreditId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        DepositCreditId = c.Int(nullable: false),
                        MainAccountId = c.Int(nullable: false),
                        PersentAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientDepositCreditId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.DepositCredits", t => t.DepositCreditId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.MainAccountId)
                .ForeignKey("dbo.Accounts", t => t.PersentAccountId)
                .Index(t => t.ClientId)
                .Index(t => t.DepositCreditId)
                .Index(t => t.MainAccountId)
                .Index(t => t.PersentAccountId);
            
            CreateTable(
                "dbo.DepositCredits",
                c => new
                    {
                        DepositCreditId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PerSent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DaysCount = c.Int(nullable: false),
                        DepositCreditType = c.Byte(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepositCreditId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId, cascadeDelete: true)
                .Index(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Disabilities",
                c => new
                    {
                        DisabilityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DisabilityId);
            
            CreateTable(
                "dbo.FamilyStatus",
                c => new
                    {
                        FamilyStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FamilyStatusId);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NationalityId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        TownId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TownId);
            
            CreateTable(
                "dbo.ClientCards",
                c => new
                    {
                        ClientCardId = c.Int(nullable: false, identity: true),
                        PinCode = c.Int(nullable: false),
                        ClientCardNumber = c.String(),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientCardId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.ExchangeRates",
                c => new
                    {
                        ExchangeRateId = c.Int(nullable: false, identity: true),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartCurrencyId = c.Int(nullable: false),
                        FinishCurrencyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExchangeRateId)
                .ForeignKey("dbo.Currencies", t => t.FinishCurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.Currencies", t => t.StartCurrencyId)
                .Index(t => t.StartCurrencyId)
                .Index(t => t.FinishCurrencyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExchangeRates", "StartCurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.ExchangeRates", "FinishCurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Accounts", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.ClientCards", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Clients", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Clients", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Clients", "FamilyStatusId", "dbo.FamilyStatus");
            DropForeignKey("dbo.Clients", "DisabilityId", "dbo.Disabilities");
            DropForeignKey("dbo.ClientDepositCredits", "PersentAccountId", "dbo.Accounts");
            DropForeignKey("dbo.ClientDepositCredits", "MainAccountId", "dbo.Accounts");
            DropForeignKey("dbo.ClientDepositCredits", "DepositCreditId", "dbo.DepositCredits");
            DropForeignKey("dbo.DepositCredits", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.ClientDepositCredits", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Accounts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Accounts", "AccountTypeId", "dbo.AccountTypes");
            DropForeignKey("dbo.Accounts", "AccountCodeId", "dbo.AccountCodes");
            DropIndex("dbo.ExchangeRates", new[] { "FinishCurrencyId" });
            DropIndex("dbo.ExchangeRates", new[] { "StartCurrencyId" });
            DropIndex("dbo.ClientCards", new[] { "AccountId" });
            DropIndex("dbo.DepositCredits", new[] { "CurrencyId" });
            DropIndex("dbo.ClientDepositCredits", new[] { "PersentAccountId" });
            DropIndex("dbo.ClientDepositCredits", new[] { "MainAccountId" });
            DropIndex("dbo.ClientDepositCredits", new[] { "DepositCreditId" });
            DropIndex("dbo.ClientDepositCredits", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "TownId" });
            DropIndex("dbo.Clients", new[] { "DisabilityId" });
            DropIndex("dbo.Clients", new[] { "NationalityId" });
            DropIndex("dbo.Clients", new[] { "FamilyStatusId" });
            DropIndex("dbo.Accounts", new[] { "ClientId" });
            DropIndex("dbo.Accounts", new[] { "AccountTypeId" });
            DropIndex("dbo.Accounts", new[] { "CurrencyId" });
            DropIndex("dbo.Accounts", new[] { "AccountCodeId" });
            DropTable("dbo.ExchangeRates");
            DropTable("dbo.ClientCards");
            DropTable("dbo.Towns");
            DropTable("dbo.Nationalities");
            DropTable("dbo.FamilyStatus");
            DropTable("dbo.Disabilities");
            DropTable("dbo.Currencies");
            DropTable("dbo.DepositCredits");
            DropTable("dbo.ClientDepositCredits");
            DropTable("dbo.Clients");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountCodes");
        }
    }
}
