namespace DevDay.Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Speaker = c.String(),
                        Track = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "SessionId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Questions", "SessionId", "dbo.Sessions", "Id", cascadeDelete: true);
            CreateIndex("dbo.Questions", "SessionId");
            DropColumn("dbo.Questions", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Path", c => c.Int(nullable: false));
            DropIndex("dbo.Questions", new[] { "SessionId" });
            DropForeignKey("dbo.Questions", "SessionId", "dbo.Sessions");
            DropColumn("dbo.Questions", "SessionId");
            DropTable("dbo.Sessions");
        }
    }
}
