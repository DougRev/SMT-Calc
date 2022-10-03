namespace CalcData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Franchise", "FranchiseeId", "dbo.Franchisee");
            AddColumn("dbo.Franchisee", "Franchise_Id", c => c.Int());
            AddColumn("dbo.Franchise", "Franchisee_Id", c => c.Int());
            CreateIndex("dbo.Franchisee", "Franchise_Id");
            CreateIndex("dbo.Franchise", "Franchisee_Id");
            AddForeignKey("dbo.Franchisee", "Franchise_Id", "dbo.Franchise", "Id");
            AddForeignKey("dbo.Franchise", "Franchisee_Id", "dbo.Franchisee", "Id");
            DropColumn("dbo.Franchisee", "FranchiseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Franchisee", "FranchiseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Franchise", "Franchisee_Id", "dbo.Franchisee");
            DropForeignKey("dbo.Franchisee", "Franchise_Id", "dbo.Franchise");
            DropIndex("dbo.Franchise", new[] { "Franchisee_Id" });
            DropIndex("dbo.Franchisee", new[] { "Franchise_Id" });
            DropColumn("dbo.Franchise", "Franchisee_Id");
            DropColumn("dbo.Franchisee", "Franchise_Id");
            AddForeignKey("dbo.Franchise", "FranchiseeId", "dbo.Franchisee", "Id", cascadeDelete: true);
        }
    }
}
