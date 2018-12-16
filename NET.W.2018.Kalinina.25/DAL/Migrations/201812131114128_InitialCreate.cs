namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountID = c.Int(nullable: false, identity: true),
                        InvoiceAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonusScores = c.Double(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        AccountType = c.Int(nullable: false),
                        AccountOwner_AccountOwnerID = c.Int(),
                    })
                .PrimaryKey(t => t.BankAccountID)
                .ForeignKey("dbo.AccountOwners", t => t.AccountOwner_AccountOwnerID)
                .Index(t => t.AccountOwner_AccountOwnerID);
            
            CreateTable(
                "dbo.AccountOwners",
                c => new
                    {
                        AccountOwnerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AccountOwnerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "AccountOwner_AccountOwnerID", "dbo.AccountOwners");
            DropIndex("dbo.BankAccounts", new[] { "AccountOwner_AccountOwnerID" });
            DropTable("dbo.AccountOwners");
            DropTable("dbo.BankAccounts");
        }
    }
}
