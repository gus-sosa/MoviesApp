namespace MoviesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInDirectorModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Biography = c.String(),
                    })
                .PrimaryKey(t => t.DirectorID);
            
            AddColumn("dbo.Movies", "DirectorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "DirectorId");
            AddForeignKey("dbo.Movies", "DirectorId", "dbo.Directors", "DirectorID", cascadeDelete: true);
            DropColumn("dbo.Movies", "Director");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Director", c => c.String());
            DropForeignKey("dbo.Movies", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectorId" });
            DropColumn("dbo.Movies", "DirectorId");
            DropTable("dbo.Directors");
        }
    }
}
