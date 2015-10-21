namespace EFInheritanceTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataFileEditor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MyDataField = c.Int(nullable: false),
                        MyOtherDataField = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataFileStore",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MyDataField = c.Int(nullable: false),
                        MyOtherDataField = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DataFileStore");
            DropTable("dbo.DataFileEditor");
        }
    }
}
