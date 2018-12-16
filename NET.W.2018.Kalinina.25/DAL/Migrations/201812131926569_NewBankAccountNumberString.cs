namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewBankAccountNumberString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "BankAccountNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankAccounts", "BankAccountNumber");
        }
    }
}
