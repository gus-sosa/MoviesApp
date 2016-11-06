namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInDataContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AwardDirectors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Category = c.String(),
                        DirectorId = c.Int(nullable: false),
                        AwardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Awards", t => t.AwardId, cascadeDelete: true)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .Index(t => t.DirectorId)
                .Index(t => t.AwardId);
            
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        AwardID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AwardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AwardDirectors", "DirectorId", "dbo.Directors");
            DropForeignKey("dbo.AwardDirectors", "AwardId", "dbo.Awards");
            DropIndex("dbo.AwardDirectors", new[] { "AwardId" });
            DropIndex("dbo.AwardDirectors", new[] { "DirectorId" });
            DropTable("dbo.Awards");
            DropTable("dbo.AwardDirectors");
        }
    }
}
