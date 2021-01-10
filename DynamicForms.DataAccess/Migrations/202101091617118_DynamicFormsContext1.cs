namespace DynamicForms.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DynamicFormsContext1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Required = c.Boolean(nullable: false),
                        Name = c.String(),
                        DataType = c.String(),
                        Form_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.Form_Id)
                .Index(t => t.Form_Id);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fields", "Form_Id", "dbo.Forms");
            DropIndex("dbo.Fields", new[] { "Form_Id" });
            DropTable("dbo.Forms");
            DropTable("dbo.Fields");
        }
    }
}
