namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableKeys : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BankAccounts", newName: "DalBankAccounts");
            RenameTable(name: "dbo.AccountOwners", newName: "DalAccountOwners");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DalAccountOwners", newName: "AccountOwners");
            RenameTable(name: "dbo.DalBankAccounts", newName: "BankAccounts");
        }
    }
}
