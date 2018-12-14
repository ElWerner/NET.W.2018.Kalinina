namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropBankAccountNumber : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BankAccounts", "BankAccountNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankAccounts", "BankAccountNumber", c => c.String());
        }
    }
}
