namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Intro = c.String(),
                        Text = c.String(),
                        Picture = c.String(),
                        AuthorId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        Text = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Reported = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Picture = c.String(),
                        Role = c.Int(nullable: false),
                        CanComment = c.Int(nullable: false),
                        CanRate = c.Int(nullable: false),
                        CanWrite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
