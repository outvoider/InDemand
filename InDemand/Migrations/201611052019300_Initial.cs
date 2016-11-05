namespace InDemand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Postings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsProvider = c.Boolean(nullable: false),
                        Location = c.String(nullable: false, maxLength: 20),
                        Title = c.String(nullable: false, maxLength: 20),
                        Description = c.String(),
                        Tags = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Postings");
        }
    }
}
