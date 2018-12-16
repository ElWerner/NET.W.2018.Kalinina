namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBankAccountNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "BankAccountNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankAccounts", "BankAccountNumber");
        }
    }
}
