namespace DAL_Kvest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        min = c.Int(nullable: false),
                        max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KvestRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UsersValueId = c.Int(nullable: false),
                        AgeCategoryId = c.Int(nullable: false),
                        PriceForOneUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgeCategories", t => t.AgeCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.UsersValues", t => t.UsersValueId, cascadeDelete: true)
                .Index(t => t.UsersValueId)
                .Index(t => t.AgeCategoryId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeCategoryId = c.Int(nullable: false),
                        KvestRoomId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KvestRooms", t => t.KvestRoomId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.TimeCategories", t => t.TimeCategoryId, cascadeDelete: true)
                .Index(t => t.TimeCategoryId)
                .Index(t => t.KvestRoomId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        SertificateId = c.Int(nullable: false),
                        NumberOfUsers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sertificates", t => t.SertificateId, cascadeDelete: true)
                .Index(t => t.SertificateId);
            
            CreateTable(
                "dbo.Sertificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SertificateNumber = c.Int(nullable: false),
                        Shown = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersValues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        min = c.Int(nullable: false),
                        max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KvestRooms", "UsersValueId", "dbo.UsersValues");
            DropForeignKey("dbo.Status", "TimeCategoryId", "dbo.TimeCategories");
            DropForeignKey("dbo.Status", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "SertificateId", "dbo.Sertificates");
            DropForeignKey("dbo.Status", "KvestRoomId", "dbo.KvestRooms");
            DropForeignKey("dbo.KvestRooms", "AgeCategoryId", "dbo.AgeCategories");
            DropIndex("dbo.Orders", new[] { "SertificateId" });
            DropIndex("dbo.Status", new[] { "OrderId" });
            DropIndex("dbo.Status", new[] { "KvestRoomId" });
            DropIndex("dbo.Status", new[] { "TimeCategoryId" });
            DropIndex("dbo.KvestRooms", new[] { "AgeCategoryId" });
            DropIndex("dbo.KvestRooms", new[] { "UsersValueId" });
            DropTable("dbo.UsersValues");
            DropTable("dbo.TimeCategories");
            DropTable("dbo.Sertificates");
            DropTable("dbo.Orders");
            DropTable("dbo.Status");
            DropTable("dbo.KvestRooms");
            DropTable("dbo.AgeCategories");
            DropTable("dbo.Administrators");
        }
    }
}
