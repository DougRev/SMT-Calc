namespace CalcData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Franchise", "FranchiseeId", "dbo.Franchisee");
            AddColumn("dbo.Franchise", "Franchisee_FranchiseeId", c => c.Int());
            AddColumn("dbo.Franchisee", "FranchiseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Franchise", "Franchisee_FranchiseeId");
            CreateIndex("dbo.Franchisee", "FranchiseId");
            AddForeignKey("dbo.Franchise", "Franchisee_FranchiseeId", "dbo.Franchisee", "FranchiseeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Franchise", "Franchisee_FranchiseeId", "dbo.Franchisee");
            DropForeignKey("dbo.Franchisee", "FranchiseId", "dbo.Franchise");
            DropIndex("dbo.Franchisee", new[] { "FranchiseId" });
            DropIndex("dbo.Franchise", new[] { "Franchisee_FranchiseeId" });
            DropColumn("dbo.Franchisee", "FranchiseId");
            DropColumn("dbo.Franchise", "Franchisee_FranchiseeId");
            AddForeignKey("dbo.Franchise", "FranchiseeId", "dbo.Franchisee", "FranchiseeId", cascadeDelete: true);
        }
    }
}
